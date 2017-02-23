using StatsHelix.Charizard;
using System.Net;
using Newtonsoft.Json;
using System.IO;

namespace EHVAG.MusiGServer
{
    class Program
    {
        public static readonly dynamic GoogleClientSecrets;

        static void Main(string[] args)
        {
            var server = new HttpServer(new IPEndPoint(IPAddress.Loopback, 80), typeof(Program).Assembly);
            //server.UnexpectedException += e => Console.WriteLine(e);
            var YouTubeClientSecret = JsonConvert.DeserializeObject<YouTubeClientSecret>(File.ReadAllText(@"Config\GoogleAPIClientSecret.json"));
            server.Run().Wait();
        }
    }
}
