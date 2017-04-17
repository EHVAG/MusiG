using StatsHelix.Charizard;
using System;
using System.Threading.Tasks;

namespace EHVAG.MusiGServer
{
    public class Authenticated
    {
        [Middleware]
        public async static Task<HttpResponse> Test(HttpRequest req)
        {
            Console.WriteLine("test");
            return HttpResponse.String("test");
        }
    }
}
