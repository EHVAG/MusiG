using static StatsHelix.Charizard.HttpResponse;
using StatsHelix.Charizard;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using EHVAG.MusiGModel;
using System.Linq;

namespace EHVAG.MusiGServer.Controller
{
    [Controller]
    class LoginController
    {
        public async Task<HttpResponse> GoogleLogin(GoogleTokenId token)
        {
            if (!string.IsNullOrEmpty(token.TokenId))
            {
                using (var client = new HttpClient())
                {
                    var values = new Dictionary<string, string>
                    {
                        { "id_token", token.TokenId}
                    };

                    // Verify tokenId
                    var response = await client.PostAsync(@"https://www.googleapis.com/oauth2/v3/tokeninfo", new FormUrlEncodedContent(values));
                    dynamic responseJson = JsonConvert.SerializeObject(await response.Content.ReadAsStringAsync());

                    // Check if request was successful and if our ClientId matches with the one in the response
                    if (response.IsSuccessStatusCode && responseJson.aud == YouTubeClientSecret.ClientId)
                    {
                        using (MusiGDBContext context = new MusiGDBContext())
                        {
                            using (var transaction = context.Database.BeginTransaction())
                            {
                                string sub = responseJson.sub;
                                if (!context.User.Any(u => u.sub == sub))
                                {
                                    // Create new user
                                    User user = new User();
                                    user.azp = responseJson.azp;
                                    user.sub = sub;
                                    user.iss = responseJson.iss;
                                    user.aud = responseJson.aud;
                                    user.iat = responseJson.iat;
                                    user.exp = responseJson.exp;

                                    user.TokenId = responseJson.TokenId;
                                    user.Email = responseJson.email;
                                    user.EmailVerified = responseJson.email_verified;
                                    user.Name = responseJson.name;
                                    user.Picture = responseJson.picture;
                                    user.GivenName = responseJson.given_name;
                                    user.FamilyName = responseJson.family_name;
                                }
                                var signatureString = Session.GenerateSessionCookie(sub);

                                return Redirect("/");
                            }
                        }
                    }
                    
                }
            }
            return HttpResponse.Redirect(StaticPages.BadRequest, false);
        }
    }
}
