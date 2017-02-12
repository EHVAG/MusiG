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
using System.Collections.Specialized;
using System.Linq;
using System.Web;

namespace EHVAG.MusiGServer.Controller
{
    [Controller]
    public class ChannelController
    {
        public async Task<HttpResponse> Add(string channelName)
        {
            if (channelName == string.Empty)
                return HttpResponse.String("Channel required", HttpStatus.BadRequest, ContentType.Plaintext);

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
                    var authUri = (string)clientSecrets["web"]["auth_uri"];

                    NameValueCollection queryString = new NameValueCollection();
                    queryString.Add("client_id", (string)clientSecrets["web"]["client_id"]);
                    queryString.Add("redirect_uris", (string)clientSecrets["web"]["redirect_uris"][0]);
                    queryString.Add("scope", (string)clientSecrets["web"]["scope"]);
                    queryString.Add("response", (string)clientSecrets["web"]["response"]);
                    queryString.Add("access_type", (string)clientSecrets["web"]["access_type"]);

                    var array = (from key in queryString.AllKeys
                                 from value in queryString.GetValues(key)
                                 select string.Format("{0}={1}", HttpUtility.UrlEncode(key), HttpUtility.UrlEncode(value))).ToArray();

                    return authUri += string.Join("&", array);
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
