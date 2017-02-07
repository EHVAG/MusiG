using System;
using System.Collections;
using System.Collections.Generic;

namespace EHVAG.MusiGModel
{
    public class Channel
    {
        public int ChannelId { get; set; }
        public string Name { get; set; }
        public int ChannelAuthMethodId { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }


        public virtual ChannelAuthMethod ChannelAuthMethod { get; set; }
    }
}