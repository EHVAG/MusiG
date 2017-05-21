using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EHVAG.MusiGModel
{
    public class OAuth2Token
    {
        [Key]
        [Column(Order = 1)]
        public Channels ChannelId { get; set; }
        [Key]
        [Column(Order = 2)]
        public string UserId { get; set; }
        public string AccessToken { get; set; }
        public string TokenType { get; set; }
        public string RefreshToken { get; set; }
        public DateTimeOffset TokenExpiresAt { get; set; }

        // Navigation properties and relations
        public virtual Channel Channel { get; set; }
        public virtual GoogleUser GoogleUser { get; set; }
    }
}
