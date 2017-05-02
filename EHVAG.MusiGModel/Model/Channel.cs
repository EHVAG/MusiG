using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EHVAG.MusiGModel
{
    public class Channel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("fontAwesomeIconClass")]
        public string FontAwesomeIconClass { get; set; }

        [JsonProperty("state")]
        public ChannelState State { get; set; }

        [JsonProperty("url")]
        public string URL { get; set; }

        public virtual ICollection<OAuth2Token> Channels { get; set; } = new List<OAuth2Token>();
    }

    public enum ChannelState
    {
        NotConnected,
        Connected,
        CommingSoon
    }
}