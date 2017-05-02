using EHVAG.MusiGModel;
using Newtonsoft.Json;
using StatsHelix.Charizard;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using static StatsHelix.Charizard.HttpResponse;

namespace EHVAG.MusiGServer.Controller
{
    [Controller]
    public class OAuth2CallbackController : Authenticated
    {
        // TODO: Check who is calling this endpoint. Cookies?
        public async Task<HttpResponse> YouTubeResponse(string code = null, string error = null)
        {
            // Check for bad requests
            if (string.IsNullOrEmpty(code) && string.IsNullOrEmpty(error))
                return Redirect(StaticPages.BadRequest);

            // User gave us no access
            // TODO: We need a redirect and message
            if (!string.IsNullOrEmpty(error))
                return String("Fells bad man");

            dynamic responseJson;
            using (var client = new HttpClient())
            {
                var values = new Dictionary<string, string>
                {
                    { "code", code},
                    { "client_id", YouTubeClientSecret.ClientId},
                    { "client_secret", YouTubeClientSecret.ClientSecret},
                    { "redirect_uri", YouTubeClientSecret.RedirectUris },
                    { "grant_type", YouTubeClientSecret.GrantType }
                };

                // Exchange AuthCode for AccessToken and RefreshToken
                var response = await client.PostAsync(YouTubeClientSecret.TokenUri, new FormUrlEncodedContent(values));
                responseJson = JsonConvert.SerializeObject(await response.Content.ReadAsStringAsync());
            }

            if (responseJson.error == null)
            {
                using (var context = new MusiGDBContext())
                {
                    // Check if user has already a valid Token.
                    // This could be the case if the user manually calls this controller.
                    if (!await OAuth2TokenFind(context, this.GoogleId, "YouTube"))
                    {
                        using (var transaction = context.Database.BeginTransaction())
                        {
                            try
                            {
                                context.OAuth2Token.Add(
                                    new OAuth2Token
                                    {
                                        Channel = await context.Channel.Where(c => c.Name == "YouTube").FirstOrDefaultAsync(),
                                        UserId = this.GoogleId,
                                        AccessToken = responseJson.access_token,
                                        TokenExpiresAt = DateTimeOffset.UtcNow.AddSeconds(Convert.ToDouble(responseJson.expires_in)),
                                        TokenType = responseJson.token_type,
                                        RefreshToken = responseJson.refresh_token,
                                    }
                                );
                                await context.SaveChangesAsync();
                                transaction.Commit();
                            }
                            catch (Exception e)
                            {
                                transaction.Rollback();
                                Console.WriteLine(e.Message);
                            }
                        }
                    }
                    else
                    {
                        // User has channel already authenticated.
                        // Maybe present an usefull help page?
                        Redirect(StaticPages.AlreadyAuthenticated);
                    }
                }
                // TODO: Add Redirect with meaningfull message
                Redirect("/channel");
            }
            // If we get here; Something went wrong. Present answer from the server. Google knows whats up.
            return Json(responseJson, HttpStatus.InternalServerError);
        }

        private async Task<bool> OAuth2TokenFind(MusiGDBContext context, string userId, string channelName)
        {
            return await (from token in context.OAuth2Token
                          from channel in context.Channel
                          where channel.Name == channelName
                          && token.ChannelId == channel.Id
                          && token.UserId == userId
                          select token).AnyAsync();
        }
    }
}