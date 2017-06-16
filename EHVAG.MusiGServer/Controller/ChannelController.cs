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
using System.Net.Http;

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
        public void RemoveChannel(string channelName)
        {
            switch (channelName)
            {
                case "YouTube":
                    RevokeOAuth2Token(Channels.YouTube);
                    break;

                    //case "SoundCloud": return Redirect("");
                    //default: return Redirect(StaticPages.BadRequest);
            }
        }

        private async void RevokeOAuth2Token(Channels channel)
        {
            // TODO
            // Transaction
            // Result handling
            // Refactor so we can make it more universal

            // Get User Token
            using (MusiGDBContext context = new MusiGDBContext())
            {
                var token = await (from tokens in context.OAuth2Token
                                   where tokens.ChannelId == channel
                                   && tokens.UserId == this.GoogleId
                                   select tokens.AccessToken).FirstOrDefaultAsync();

                if (!string.IsNullOrEmpty(token))
                {
                    //curl - H "Content-type:application/x-www-form-urlencoded" \
                    using (HttpClient client = new HttpClient())
                    using (HttpResponseMessage response = await client.GetAsync($"{YouTubeClientSecret.TokenRevokeUri}?token={token}"))

                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                        }
                        else
                        {
                            using (HttpContent content = response.Content)
                            {
                                string result = await content.ReadAsStringAsync();

                                // What to do with result?
                            }
                        }
                }
                else
                {
                    //No token
                }
            }

            //YouTubeClientSecret.TokenRevokeUri
            //https://accounts.google.com/o/oauth2/revoke?token={token}

            //this.GoogleId
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
                var channels = await (from channel in context.Channel
                                      join token in context.OAuth2Token
                                      on new { key1 = channel.Id, key2 = GoogleId } equals new { key1 = token.ChannelId, key2 = token.UserId } into result
                                      from r in result.DefaultIfEmpty()
                                      select new
                                      {
                                          channel.Id,
                                          channel.Name,
                                          channel.FontAwesomeIconClass,
                                          channel.URL,
                                          State = (r == null ? "add" : "remove")
                                      }).ToArrayAsync();

                return HttpResponse.Json(JArray.FromObject(channels), HttpStatus.Ok);
            }
        }
    }
}