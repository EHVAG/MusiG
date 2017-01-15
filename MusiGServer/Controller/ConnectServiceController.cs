using StatsHelix.Charizard;
using static StatsHelix.Charizard.HttpResponse;

namespace EHVAG.MusiGServer.Controller
{
    [Controller]
    public class ConnectChannel
    {
        public HttpResponse Add(string channelId)
        {
            if (channelId == System.String.Empty)
                return String("Channel name is required");

                return Redirect(@"https://accounts.google.com/AccountChooser?continue=https://accounts.google.com/o/oauth2/auth?access_type%3Doffline%26approval_prompt%3Dforce%26client_id%3D427071021612.apps.googleusercontent.com%26redirect_uri%3Dhttp://ifttt.com/channels/google_callback%26response_type%3Dcode%26scope%3Dhttps://www.googleapis.com/auth/drive%2Bhttps://www.googleapis.com/auth/userinfo.email%2Bhttps://www.googleapis.com/auth/userinfo.profile%2Bhttps://spreadsheets.google.com/feeds%2Bhttps://docs.google.com/feeds%2Bhttps://www.googleapis.com/auth/spreadsheets%2Bhttps://www.googleapis.com/auth/documents%2Bhttps://www.googleapis.com/auth/script.external_request%2Bhttps://www.googleapis.com/auth/script.scriptapp%26from_login%3D1%26as%3D-a8cb78afadb11eb&ltmpl=nosignup&btmpl=authsub&scc=1&oauth=1");
        }

        public void Soundcloud()
        {

        }
    }
}
