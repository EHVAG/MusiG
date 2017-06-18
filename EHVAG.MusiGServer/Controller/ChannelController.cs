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

        // https://developers.google.com/identity/protocols/OAuth2WebServer#tokenrevoke
        private async Task<HttpResponse> RevokeOAuth2Token(Channels channel)
        {
            // Get the users OAuth2 token
            using (MusiGDBContext context = new MusiGDBContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var oAuth2Token = await (from token in context.OAuth2Token
                                                 where token.ChannelId == channel
                                                 && token.UserId == this.GoogleId
                                                 select token).FirstOrDefaultAsync();

                        if (oAuth2Token != null)
                        {
                            // Send the token to Google
                            using (HttpClient client = new HttpClient())
                            using (HttpResponseMessage response = await client.GetAsync($"{YouTubeClientSecret.TokenRevokeUri}?token={oAuth2Token.AccessToken}"))

                            // Everything is fine. Access is revoked. Remove token from our database
                            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                            {
                                context.OAuth2Token.Remove(oAuth2Token);
                                transaction.Commit();
                                return Redirect("/channel");
                            }
                            else
                            {
                                using (HttpContent content = response.Content)
                                {
                                    string result = await content.ReadAsStringAsync();
                                    return Redirect(StaticPages.InternalServerError);
                                }
                            }
                        }
                        else
                        {
                            return Redirect(StaticPages.BadRequest);
                        }
                    }
                    catch
                    {
                        transaction.Rollback();
                        return Redirect(StaticPages.InternalServerError);
                    }
                }
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