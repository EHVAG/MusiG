using StatsHelix.Charizard;
using System.Text;
using EHVAG.MusiGModel;
using static StatsHelix.Charizard.HttpResponse;
using System;
using System.Data.Entity;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace EHVAG.MusiGServer.Controller
{
    [Controller]
    public class ChannelController
    {
        public async Task<HttpResponse> Add(string channelName)
        {
            if (channelName == string.Empty)
                return HttpResponse.Data(Encoding.Unicode.GetBytes("Channel required"), HttpStatus.BadRequest);

            using (var context = new DBContext())
            {
                var channelExists = await context.Channel.AnyAsync(c => c.Name == channelName);

                if (channelExists)
                {
                    switch (channelName)
                    {
                        case "YouTube": return Redirect(GetYouTubeAuthUri());
                        case "SoundCloud": return Redirect("");
                    }
                }
            }
            return Redirect("/ChannelNotFound.html");
        }

        public string GetYouTubeAuthUri()
        {
            using (StreamReader reader = File.OpenText(@"config\GoogleAPIClientSecret.json"))
            {
                try
                {
                    JObject clientSecrets = (JObject)JToken.ReadFrom(new JsonTextReader(reader));
                    var auth_uri = (string)clientSecrets["web"]["auth_uri"];
                    var client_id = (string)clientSecrets["web"]["client_id"];
                    var redirect_uris = (string)clientSecrets["web"]["redirect_uris"][0]; // Just select the first one
                    var scope = (string)clientSecrets["web"]["scope"];
                    var response = (string)clientSecrets["web"]["response"];
                    var access_type = (string)clientSecrets["web"]["access_type"];

                    return auth_uri + "?" +
                            "client_id=" + client_id + "&" +
                            "redirect_uri=" + redirect_uris + "&" +
                            "scope=" + scope + "&" +
                            "response_type=" + response + "&" +
                            "access_type=" + access_type;
                }
                catch (Exception exep)
                {
                    Console.WriteLine(exep.Message);
                    return (@"\InternalServerError.html");
                }
            }
        }
    }
}
