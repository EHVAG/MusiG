using StatsHelix.Charizard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EHVAG.MusiGServer.Controller
{
    [Controller]
    class LiveFeedController
    {
        // TODO again. How to Identify a user???
        public HttpResponse GetUserLiveFeed(HttpRequest req)
        {
            var cookie = req.GetCookie();
        }
    }
}
