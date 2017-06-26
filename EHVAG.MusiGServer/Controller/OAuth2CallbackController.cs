using EHVAG.MusiGModel;
using Newtonsoft.Json.Linq;
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
        // https://developers.google.com/youtube/v3/guides/auth/server-side-web-apps#handlingresponse
        public async Task<HttpResponse> YouTubeResponse(string code = null, string error = null)
        {
            // Check for bad requests
            if (string.IsNullOrEmpty(code) && string.IsNullOrEmpty(error))
                return Redirect(StaticPages.BadRequest);

            // User gave us no access
            // TODO: We need a redirect and message
            if (!string.IsNullOrEmpty(error))
                return Redirect(StaticPages.Channel);

            JObject responseJson;
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
                // https://developers.google.com/youtube/v3/guides/auth/server-side-web-apps#exchange-authorization-code
                var response = await client.PostAsync(YouTubeClientSecret.TokenUri, new FormUrlEncodedContent(values));
                responseJson = JObject.Parse(await response.Content.ReadAsStringAsync());
            }

            if (responseJson["error"] == null)
            {
                using (var context = new MusiGDBContext())
                {
                    // Check if user has already a valid Token.
                    // This could be the case if the user manually calls this controller.
                    if (!await OAuth2TokenFind(context, this.GoogleUserId, Channels.YouTube))
                    {
                        using (var transaction = context.Database.BeginTransaction())
                        {
                            try
                            {
                                context.OAuth2Token.Add(new OAuth2Token
                                {
                                    ChannelId = Channels.YouTube,
                                    GoogleUserId = this.GoogleUserId,
                                    AccessToken = responseJson["access_token"].ToString(),
                                    TokenExpiresAt = DateTimeOffset.UtcNow.AddSeconds(Convert.ToDouble(responseJson["expires_in"].ToString())),
                                    TokenType = responseJson["token_type"].ToString()
                                });
                                await context.SaveChangesAsync();
                                transaction.Commit();
                            }
                            catch (Exception e)
                            {
                                transaction.Rollback();
                                Console.WriteLine(e.Message);
                                return Redirect(StaticPages.InternalServerError);
                            }
                        }
                    }
                    else
                    {
                        // User has channel already authenticated.
                        // Maybe present an usefull help page?
                        return Redirect(StaticPages.AlreadyAuthenticated);
                    }
                }
                // TODO: Add Redirect with meaningfull message
                return Redirect(StaticPages.Channel);
            }
            // If we get here; Something went wrong. Present answer from the Google server. Google knows what's up.
            return Json(responseJson, HttpStatus.InternalServerError);
        }

        private async Task<bool> OAuth2TokenFind(MusiGDBContext context, string userId, Channels channelId)
        {
            return await (from token in context.OAuth2Token
                          from channel in context.Channel
                          where token.ChannelId == channel.Id
                          && token.GoogleUserId == userId
                          select token).AnyAsync();
        }
    }
}