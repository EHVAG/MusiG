using EHVAG.MusiGModel.Model;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace EHVAG.MusiGModel
{
    public class GoogleUser
    {
        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("email_verified")]
        public bool EmailVerified { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("family_name")]
        public string FamilyName { get; set; }

        [JsonProperty("given_name")]
        public string GivenName { get; set; }

        [JsonProperty("picture")]
        public string Picture { get; set; }

        [JsonProperty("locale")]
        public IsoLocales Locale { get; set; }

        // Stuff we get from Google and keep it for...research
        [JsonProperty("sub")]
        public string Sub { get; set; }

        [JsonProperty("azp")]
        public string Azp { get; set; }

        [Key]
        [JsonProperty("aud")]
        public string Aud { get; set; }

        [JsonProperty("iat")]
        public string Iat { get; set; }

        [JsonProperty("exp")]
        public string Exp { get; set; }

        [JsonProperty("iss")]
        public string Iss { get; set; }

        public virtual ICollection<OAuth2Token> Channels { get; set; } = new List<OAuth2Token>();
    }
}