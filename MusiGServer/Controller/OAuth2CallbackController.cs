using EHVAG.MusiGModel;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using StatsHelix.Charizard;
using System.Collections.Generic;
using static StatsHelix.Charizard.HttpResponse;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System;

namespace EHVAG.MusiGServer.Controller
{
    [Controller]
    public class oAuth2CallbackController
    {
        // Security issue. Everybody can access this and potentialy flood the database
        // Is it enough if we validate the sessions via e.g cookies?
        public async Task<HttpResponse> Response(HttpRequest request)
        {
            var queryStringColl = System.Web.HttpUtility.ParseQueryString(request.Querystring.ToString());

            //TODO: How to tell apart if the request came from YouTube or else where?
            if (queryStringColl.Keys[0] == "code")
            {
                var success = await GetYouTubeAccessToken(queryStringColl.GetValues("code")[0].ToString());
                return HttpResponse.String("success");
            }
            else
            {
                //User wont give us access :(
                return HttpResponse.String("You shall not pass");
            }
        }

        private async Task<bool> GetYouTubeAccessToken(string authCode)
        {
            using (StreamReader reader = File.OpenText(@"config\GoogleAPIClientSecret.json"))
            {
                JObject clientSecrets = (JObject)JToken.ReadFrom(new JsonTextReader(reader));
                var token_uri = (string)clientSecrets["web"]["token_uri"];

                using (var client = new HttpClient())
                {
                    var values = new Dictionary<string, string>
                        {
                           { "code", authCode},
                           { "client_id", (string)clientSecrets["web"]["client_id"] },
                           { "client_secret", (string)clientSecrets["web"]["client_secret"] },
                           { "redirect_uri", (string)clientSecrets["web"]["redirect_uris"][0] },
                           { "grant_type", (string)clientSecrets["web"]["grant_type"] }
                        };

                    var content = new FormUrlEncodedContent(values);

                    var response = await client.PostAsync(new Uri(token_uri), content);

                    var responseString = await response.Content.ReadAsStringAsync();

                    //handle response
                    var responseJson = JObject.Parse(responseString);
                    if (responseJson["error"] == null)
                    {
                        using (var context = new DBContext())
                        {
                            var token = new oAuth2Token();
                            token.Channel = await context.Channel.Where(c => c.Name == "YouTube").FirstOrDefaultAsync();
                            // TODO: We dont know the user yet
                            // token.UserId =
                            token.AccessToken = (string)responseJson["access_token"];
                            token.TokenExpiresAt = DateTimeOffset.UtcNow.AddSeconds(Convert.ToDouble((string)responseJson["expires_in"]));
                            token.TokenType = (string)responseJson["token_type"];
                            token.RefreshToken = (string)responseJson["refresh_token"];

                            await SaveoAuth2TokenAsync(token);

                            return true;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }

        private async Task SaveoAuth2TokenAsync(oAuth2Token token)
        {
            using (var context = new DBContext())
            {
                context.oAuth2Token.Add(token);
                try
                {
                    await context.SaveChangesAsync();
                }
                catch (Exception exep)
                {
                    // TODO: Handle exceptions.
                }
            }
        }
    }
}
