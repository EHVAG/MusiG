using System.Collections;
using System.Collections.Generic;

namespace MusiGModel
{
    public class Playlist
    {
        public int PlaylistId { get; set; }
        public int SongId { get; set; }


        public virtual ICollection<Song> Songs { get; set; } = new List<Song>();
    }
}