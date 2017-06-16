using static StatsHelix.Charizard.HttpResponse;
using StatsHelix.Charizard;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using EHVAG.MusiGModel;
using System.Linq;
using System;

namespace EHVAG.MusiGServer.Controller
{
    [Controller]
    public class LoginController
    {
        /// <summary>
        /// https://developers.google.com/identity/sign-in/web/backend-auth
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public async Task<HttpResponse> GoogleLogin(GoogleIdToken token)
        {
            if (!string.IsNullOrEmpty(token.IdToken))
            {
                using (var client = new HttpClient())
                {
                    var values = new Dictionary<string, string>
                    {
                        { "id_token", token.IdToken}
                    };

                    // Verify IdToken against Google endpoint
                    // More details: https://developers.google.com/identity/sign-in/web/backend-auth#calling-the-tokeninfo-endpoint
                    var response = await client.PostAsync(YouTubeClientSecret.TokenInfo, new FormUrlEncodedContent(values));
                    var responseJson = JsonConvert.DeserializeObject<GoogleUser>(await response.Content.ReadAsStringAsync());

                    // Check if request was successful and if our Google ClientId matches with the one in the response
                    if (response.IsSuccessStatusCode && responseJson.Aud == YouTubeClientSecret.ClientId)
                    {
                        using (MusiGDBContext context = new MusiGDBContext())
                        {
                            try
                            {
                                using (var transaction = context.Database.BeginTransaction())
                                {
                                    // The sub field is the users unique Google Id
                                    string sub = responseJson.Sub;
                                    if (!context.GoogleUser.Any(u => u.Sub == sub))
                                    {
                                        // Create new user
                                        GoogleUser user = responseJson;
                                        user.Sub = sub;

                                        context.GoogleUser.Add(user);

                                        await context.SaveChangesAsync();
                                        transaction.Commit();
                                    }

                                    var signatureString = Session.SignSession(sub);
                                    return Redirect("/").SetCookie(Session.GoogleIdHeader, sub, false)
                                                        .SetCookie(Session.AuthHeader, signatureString, true);
                                }
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine($"Exception: ${e.Message}");
                                if (e.InnerException != null)
                                    Console.WriteLine($"Exception: ${e.InnerException}");
                                Console.WriteLine($"Exception: ${e.StackTrace}");
                            }
                        }
                    }
                }
            }
            return Redirect(StaticPages.BadRequest, false);
        }
    }
}