using EHVAG.MusiGModel;
using Newtonsoft.Json.Linq;
using StatsHelix.Charizard;
using System.Collections.Generic;
using static StatsHelix.Charizard.HttpResponse;
using System.Data.Entity;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System;

namespace EHVAG.MusiGServer.Controller
{
    [Controller]
    public class oAuth2CallbackController
    {
        // TODO: Check who is calling this endpoint. Cookies?
        public async Task<HttpResponse> YouTubeResponse(string code = null, string error = null)
        {
            // Check for bad requests
            if (System.String.IsNullOrEmpty(code) && System.String.IsNullOrEmpty(error))
                return Redirect(StaticPages.BadRequest);

            // User gave us no access
            if (!string.IsNullOrEmpty(error))
                return String("Fells bad man");

            dynamic responseJson;
            using (var client = new HttpClient())
            {
                var values = new Dictionary<string, string>
                {
                    { "code", code},
                    { "client_id", Program.GoogleClientSecrets.web.client_id.ToString()},
                    { "client_secret", Program.GoogleClientSecrets.web.client_secret.ToString() },
                    { "redirect_uri", Program.GoogleClientSecrets.web.redirect_uris[0].ToString() },
                    { "grant_type", Program.GoogleClientSecrets.web.grant_type.ToString() }
                };

                // Exchange AuthCode for AccessToken and RefreshToken
                var response = await client.PostAsync(Program.GoogleClientSecrets.web.token_uri.ToString(), new FormUrlEncodedContent(values));
                responseJson = JObject.Parse(await response.Content.ReadAsStringAsync());
            }

            // Handle response
            if (responseJson.error == null)
            {
                var token = new OAuth2Token();
                using (var context = new MusiGDBContext())
                {
                    if (await OAuth2TokenFind(context) != null)
                    {
                        token.Channel = await context.Channel.Where(c => c.Name == "YouTube").FirstOrDefaultAsync();
                        // TODO: We don't know the user yet. Add it later.
                        token.UserId = 1;
                        token.AccessToken = responseJson.access_token;
                        token.TokenExpiresAt = DateTimeOffset.UtcNow.AddSeconds(Convert.ToDouble(responseJson.expires_in));
                        token.TokenType = responseJson.token_type;
                        token.RefreshToken = responseJson.refresh_token;

                        using (var transaction = context.Database.BeginTransaction())
                        {
                            try
                            {
                                context.OAuth2Token.Add(token);
                                await context.SaveChangesAsync();

                                transaction.Commit();
                            }
                            catch (Exception excep)
                            {
                                transaction.Rollback();
                                Console.WriteLine(excep.Message);
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
                // TODO: What do we do if this succeeds? Redirect? Where?
            }
            // If we get here; Something went wrong. Present answer from the server. Google knows whats up.
            return Json(responseJson, HttpStatus.InternalServerError);
        }

        private async Task<OAuth2Token> OAuth2TokenFind(MusiGDBContext context)
        {
            using (context)
            {
                // TODO: Add logic here.
                return await context.OAuth2Token.SingleOrDefaultAsync();
            }
        }
    }
}
