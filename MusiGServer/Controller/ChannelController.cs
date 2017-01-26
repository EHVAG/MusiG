using StatsHelix.Charizard;
using System.Text;
using static StatsHelix.Charizard.HttpResponse;

namespace EHVAG.MusiGServer.Controller
{
    [Controller]
    public class ChannelController
    {
        public HttpResponse Add(string channelId)
        {
            if (channelId == System.String.Empty)
                return HttpResponse.Data(Encoding.Unicode.GetBytes("Channel required"), HttpStatus.BadRequest);

            return HttpResponse.Redirect(@"http://google.de");
        }

        //public HttpResponse Remove(string channelId)
        //{

        //}
    }
}
