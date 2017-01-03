using System;
using System.Collections;
using System.Collections.Generic;

namespace MusiGModel
{
    public class Source
    {
        public int SourceId { get; set; }
        public string Name { get; set; }
        public int UserAccountId { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }

        public virtual ICollection<UserAccount> UserAccounts { get; set; } = new List<UserAccount>();
    }
}