using System.Collections;
using System.Collections.Generic;

namespace EHVAG.MusiGModel
{
    public class Artist
    {
        public int ArtistId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Song> Songs { get; set; } = new List<Song>();
    }
}