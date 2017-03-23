using Newtonsoft.Json.Linq;
using StatsHelix.Charizard;
using System;
using System.Linq;
using static StatsHelix.Charizard.HttpResponse;
using EHVAG.MusiGModel;
using System.Data.Entity;
using System.Threading.Tasks;

namespace EHVAG.MusiGServer.Controller
{
    [Controller]
    public class ChannelController
    {
        public HttpResponse Add(string channelName)
        {
            switch (channelName)
            {
                case "YouTube": return Redirect(GetYouTubeAuthUri());
                case "SoundCloud": return Redirect("");
                default: return Redirect(StaticPages.BadRequest);
            }
        }

        // https://developers.google.com/identity/protocols/OAuth2InstalledApp#tokenrevoke
        public HttpResponse Remove(string channelName, string userId)
        {
            switch (channelName)
            {
                case "YouTube": return Redirect(GetYouTubeAuthUri());
                case "SoundCloud": return Redirect("");
                default: return Redirect(StaticPages.BadRequest);
            }
        }

        private string GetYouTubeAuthUri()
        {
            Func<string, string> ue = System.Web.HttpUtility.UrlEncode;
            return $@"{YouTubeClientSecret.AuthUri}?scope={ue(YouTubeClientSecret.Scope)}&access_type={ue(YouTubeClientSecret.AccessType)}&redirect_uri={ue(YouTubeClientSecret.RedirectUris)}&response_type={ue(YouTubeClientSecret.Response)}&client_id={ ue(YouTubeClientSecret.ClientId)}";
        }

        public async Task<HttpResponse> GetChannels()
        {
            JArray o;
            using (var context = new MusiGDBContext())
            {
                //var channels = await (from c in context.Channel select new { c.Id, c.Name, c.URL, c.State, c.FontAwesomeIconClass }).ToListAsync();
                var channels = await context.Channel.ToListAsync();
                o = JArray.FromObject(channels);
            }

            //return Json(o, HttpStatus.Ok, );
            return HttpResponse.Json(o, HttpStatus.Ok).AddHeader("Access-Control-Allow-Origin", @"http://localhost:8080");
        }
    }
}