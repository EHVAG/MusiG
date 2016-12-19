using System.Collections;
using System.Collections.Generic;

namespace MusiGModel
{
    public class User
    {
        public User()
        {
            UserPlaylists = new List<UserPlaylist>();
            UserAccounts = new List<UserAccount>();
        }

        public int UserId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string UserName { get; set; }

        public virtual ICollection<UserPlaylist> UserPlaylists { get; set; }
        public virtual ICollection<UserAccount> UserAccounts { get; set; }
    }
}