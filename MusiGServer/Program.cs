using StatsHelix.Charizard;
using System.Net;
using System;
using Newtonsoft.Json;
using System.IO;

namespace EHVAG.MusiGServer
{
    class Program
    {
        public static readonly dynamic googleClientSecrets;

        static void Main(string[] args)
        {
            var server = new HttpServer(new IPEndPoint(IPAddress.Loopback, 80), typeof(Program).Assembly);
            // server.UnexpectedException += e => Console.WriteLine(e);
            server.Run().Wait();
        }

        static Program()
        {
            googleClientSecrets = JsonConvert.DeserializeObject(File.ReadAllText(@"Config\GoogleAPIClientSecret.json"));
        }
    }
}
