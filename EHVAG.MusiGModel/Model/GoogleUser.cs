using EHVAG.MusiGModel.Model;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace EHVAG.MusiGModel
{
    public class GoogleUser
    {
        public string Email { get; set; }

        public bool EmailVerified { get; set; }

        public string Name { get; set; }

        public string FamilyName { get; set; }

        public string GivenName { get; set; }

        public string Picture { get; set; }

        public IsoLocales Locale { get; set; }

        public string Sub { get; set; }

        public string Azp { get; set; }

        [Key]
        public string Aud { get; set; }

        public string Iat { get; set; }

        public string Exp { get; set; }

        public string Iss { get; set; }

        public virtual ICollection<OAuth2Token> Channels { get; set; } = new List<OAuth2Token>();
    }
}