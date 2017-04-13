using EHVAG.MusiGModel.Model;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EHVAG.MusiGModel
{
    public class User
    {
        public string TokenId { get; set; }
        public string Email { get; set; }
        public bool EmailVerified { get; set; }
        public string Name { get; set; }
        public string FamilyName { get; set; }
        public string GivenName { get; set; }
        public string Picture { get; set; }
        public IsoLocales Locale { get; set; }

        // Stuff we get from Google and keep it for...research
        public string sub { get; set; }
        public string azp { get; set; }
        [Key]
        public string aud { get; set; }
        public string iat { get; set; }
        public string exp { get; set; }
        public string iss { get; set; }


        public virtual ICollection<Channel> Channels { get; set; } = new List<Channel>();
    }
}