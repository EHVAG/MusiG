using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using StatsHelix.Charizard;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace EHVAG.MusiGServer.Controller
{
    [Controller]
    public class oAuth2CallbackController
    {
        public HttpResponse Response(string code)
        {
            //TODO: How to tell apart where it came from?
            using (StreamReader reader = File.OpenText(@"config\GoogleAPIClientSecret.json"))
            {
                try
                {
                    JObject clientSecrets = (JObject)JToken.ReadFrom(new JsonTextReader(reader));
                    var token_uri = (string)clientSecrets["web"]["token_uri"];

                    List<HttpHeader> headers = new List<HttpHeader>();
                    headers.Add(new HttpHeader { Name = "code", Value = code });
                    headers.Add(new HttpHeader { Name = "client_id", Value = (string)clientSecrets["web"]["client_id"] });
                    headers.Add(new HttpHeader { Name = "client_secret", Value = (string)clientSecrets["web"]["client_secret"] });
                    headers.Add(new HttpHeader { Name = "redirect_uri", Value = (string)clientSecrets["web"]["redirect_uris"][1] });
                    headers.Add(new HttpHeader { Name = "grant_type", Value = (string)clientSecrets["web"]["grant_type"] });

                    HttpRequest request = new HttpRequest(HttpMethod.Post, new StringSegment(token_uri), headers, Encoding.Default);
                    request.
                }
                catch (Exception exep)
                {
                    Console.WriteLine(exep.Message);
                }
            }
            return HttpResponse.String("yay");
        }
    }
}
