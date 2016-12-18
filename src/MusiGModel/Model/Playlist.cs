using System.Collections;
using System.Collections.Generic;

namespace MusiGModel.Model
{
    internal class Playlist
    {
        public Playlist()
        {
            Songs = new List<Song>();
        }

        public int PlaylistId { get; set; }
        public int SongId { get; set; }


        public virtual ICollection Songs { get; set; }
    }
}