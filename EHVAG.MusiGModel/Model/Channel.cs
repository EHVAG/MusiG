using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EHVAG.MusiGModel
{
    public class Channel
    {
        
        public Channels Id { get; set; }
        public string Name { get; set; }
        public string FontAwesomeIconClass { get; set; }
        public string URL { get; set; }


        public virtual ICollection<OAuth2Token> Channels { get; set; } = new List<OAuth2Token>();
    }

    public enum Channels
    {
        YouTube,
        Soundcloud,
        Spotify,
        USB,
        Twitch
    }
}