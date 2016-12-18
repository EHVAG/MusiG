using System;
using System.Collections;
using System.Collections.Generic;

namespace MusiGModel.Model
{
    internal class Source
    {
        public Source()
        {
            UserAccounts = new List<UserAccount>();
        }

        public int SourceId { get; set; }
        public string Name { get; set; }
        public int UserAccountId { get; set; }
        public string Description { get; set; }
        public Uri Link { get; set; }

        public virtual ICollection UserAccounts { get; set; }
    }
}