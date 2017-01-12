using StatsHelix.Charizard;
using System.Net;

namespace MusiGServer
{
    class Program
    {
        static void Main(string[] args)
        {
            var server = new HttpServer(new IPEndPoint(IPAddress.Loopback, 80), typeof(Program).Assembly);
            // server.UnexpectedException += e => Console.WriteLine(e);
            server.Run().Wait();
        }
    }
}
