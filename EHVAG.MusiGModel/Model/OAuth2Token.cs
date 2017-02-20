using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EHVAG.MusiGModel
{
    public class OAuth2Token
    {
        public int OAuth2TokenId { get; set; }
        [Index("IX_User_Channel", 1, IsUnique = true)]
        public int ChannelId { get; set; }
        [Index("IX_User_Channel", 2, IsUnique = true)]
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
