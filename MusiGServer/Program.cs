using StatsHelix.Charizard;
using System.Net;

namespace EHVAG.MusiGServer
{
    class Program
    {
        public const string GoogleClientId = "621236350765-15njpt6aaf05jtmoag5n1igd4oa6idjj.apps.googleusercontent.com";

        static void Main(string[] args)
        {
            var server = new HttpServer(new IPEndPoint(IPAddress.Loopback, 80), typeof(Program).Assembly);
            // server.UnexpectedException += e => Console.WriteLine(e);
            server.Run().Wait();
        }
    }
}
