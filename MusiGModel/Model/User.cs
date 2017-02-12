using System.Collections;
using System.Collections.Generic;

namespace EHVAG.MusiGModel
{
    public class User
    {
        public int UserId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string UserName { get; set; }

        public virtual ICollection<UserPlaylist> UserPlaylists { get; set; } = new List<UserPlaylist>();
        public virtual ICollection<Channel> Channels { get; set; } = new List<Channel>();
    }
}