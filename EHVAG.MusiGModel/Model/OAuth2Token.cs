using System;
using System.ComponentModel.DataAnnotations;

namespace EHVAG.MusiGModel
{
    public class OAuth2Token
    {
        public int OAuth2TokenId { get; set; }
        public int ChannelId { get; set; }
        public int UserId { get; set; }
        public string AccessToken { get; set; }
        public string TokenType { get; set; }
        public string RefreshToken { get; set; }
        public DateTimeOffset TokenExpiresAt { get; set; }

        // Navigation properties and relations
        public virtual Channel Channel { get; set; }
        public virtual User User { get; set; }
    }
}
