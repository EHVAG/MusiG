using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EHVAG.MusiGModel.Model
{
    class ChannelState
    {
        public int Id { get; set; }
        public int ChannelId { get; set; }
        public int GoogleUserId { get; set; }
        public string Message { get; set; }
        public DateTimeOffset CreatedDate { get; set; }

        // Navigation properties and relations
        public virtual Channel Channel { get; set; }
        public virtual GoogleUser GoogleUser { get; set; }
    }
}
