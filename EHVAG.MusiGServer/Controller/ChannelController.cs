using StatsHelix.Charizard;
using static StatsHelix.Charizard.HttpResponse;
using System;
using System.IO;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Collections.Specialized;
using System.Linq;

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

        public string GetYouTubeAuthUri()
        {
            Func<string, string> ue = System.Web.HttpUtility.UrlEncode;
            dynamic web = Program.googleClientSecrets.web;
            return $@"{web.auth_uri}?scope={ue(web.scope.ToString())}&access_type={ue(web.access_type.ToString())}&redirect_uri={ue(web.redirect_uris[0].ToString())}&response_type={ue(web.response.ToString())}&client_id={ ue(web.client_id.ToString())}";
        }
    }
}
