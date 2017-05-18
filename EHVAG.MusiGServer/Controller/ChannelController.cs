using Newtonsoft.Json.Linq;
using StatsHelix.Charizard;
using System;
using System.Linq;
using static StatsHelix.Charizard.HttpResponse;
using EHVAG.MusiGModel;
using System.Data.Entity;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace EHVAG.MusiGServer.Controller
{
    [Controller]
    public class ChannelController : Authenticated
    {
        public HttpResponse AddChannel(string channelName)
        {
            switch (channelName)
            {
                case "YouTube": return Redirect(GetYouTubeAuthUri());
                case "SoundCloud": return Redirect("");
                default: return Redirect(StaticPages.BadRequest);
            }
        }

        // https://developers.google.com/identity/protocols/OAuth2InstalledApp#tokenrevoke
        public HttpResponse RemoveChannel(string channelName, string userId)
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
            return $@"{YouTubeClientSecret.AuthUri}" +
                    $@"?scope={ue(YouTubeClientSecret.Scope)}" +
                    $@"&access_type={ue(YouTubeClientSecret.AccessType)}" +
                    $@"&redirect_uri={ue(YouTubeClientSecret.RedirectUris)}" +
                    $@"&response_type={ue(YouTubeClientSecret.Response)}" +
                    $@"&client_id={ ue(YouTubeClientSecret.ClientId)}";
        }

        public async Task<HttpResponse> GetChannels()
        {
            using (var context = new MusiGDBContext())
            {
                var channels = await context.Channel.ToListAsync();
                return HttpResponse.Json(JArray.FromObject(channels), HttpStatus.Ok);
            }
        }
    }
}