using System.Collections;
using System.Collections.Generic;

namespace MusiGModel.Model
{
    public class Artist
    {
        public Artist()
        {
            Songs = new List<Song>();
        }

        public int ArtistId { get; set; }
        public string Name { get; set; }

        public virtual ICollection Songs { get; set; }
    }
}