using System;
using System.Collections;
using System.Collections.Generic;

namespace EHVAG.MusiGModel
{
    public class Album
    {
        public int AlbumId { get; set; }
        public string Title { get; set; }
        public int ArtistId { get; set; }
        public DateTimeOffset ReleaseDate { get; set; }


        public virtual Artist Artist { get; set; }
        public virtual ICollection<Song> Songs { get; set; } = new List<Song>();
    }
}