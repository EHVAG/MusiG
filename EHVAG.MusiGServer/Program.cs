using Newtonsoft.Json;
using StatsHelix.Charizard;
using System;
using System.IO;
using System.Net;
using System.Reflection;

namespace EHVAG.MusiGServer
{
    internal class Program
    {
        private static int Main(string[] args)
        {
            var server = new HttpServer(new IPEndPoint(IPAddress.Loopback, 80), typeof(Program).Assembly);

            try
            {
                PopulateYouTubeClientSecrets();
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Server startup failed!");
                Console.WriteLine(e.Message);
                Console.WriteLine("Press any key to exit the application.");
                Console.ResetColor();
                Console.ReadLine();
                return -1;
            }

            server.Run().Wait();
            return 0;
        }

         public static void PopulateYouTubeClientSecrets()
        {
            dynamic googleClientSecrets = JsonConvert.DeserializeObject(File.ReadAllText(@"Config\APIConfigs\YouTubeClientSecret.json"));

            YouTubeClientSecret.AuthUri = googleClientSecrets.web.auth_uri;
            YouTubeClientSecret.ClientId = googleClientSecrets.web.client_id;
            YouTubeClientSecret.ProjectId = googleClientSecrets.web.project_id;
            YouTubeClientSecret.TokenUri = googleClientSecrets.web.token_uri;
            YouTubeClientSecret.AuthProviderX509CertUrl = googleClientSecrets.web.auth_provider_x509_cert_url;
            YouTubeClientSecret.ClientSecret = googleClientSecrets.web.client_secret;
            YouTubeClientSecret.RedirectUris = googleClientSecrets.web.redirect_uris[0];
            YouTubeClientSecret.JavascriptOrigins = googleClientSecrets.web.javascript_origins[0];
            YouTubeClientSecret.Scope = googleClientSecrets.web.scope;
            YouTubeClientSecret.Response = googleClientSecrets.web.response;
            YouTubeClientSecret.AccessType = googleClientSecrets.web.access_type;
            YouTubeClientSecret.GrantType = googleClientSecrets.web.grant_type;

            // Check if every propty of <code>YouTubeClientSecret</code> is set
            foreach (PropertyInfo prop in typeof(YouTubeClientSecret).GetProperties())
            {
                if (prop.GetValue(null) == null || prop.GetValue(null).ToString() == string.Empty)
                {
                    throw new ArgumentException("The following paramter in YouTubeClientSecret.json is either empty or could not be found", prop.Name);
                }
            }
        }
    }
}