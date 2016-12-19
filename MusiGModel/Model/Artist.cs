using System.Collections;
using System.Collections.Generic;

namespace MusiGModel
{
    public class Artist
    {
        public Artist()
        {
            Songs = new List<Song>();
        }

        public int ArtistId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Song> Songs { get; set; }
    }
}