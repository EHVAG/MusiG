using System;
using System.Collections;
using System.Collections.Generic;

namespace MusiGModel.Model
{
    internal class Album
    {
        public Album()
        {
            Songs = new List<Song>();
        }

        public int AlbumId { get; set; }
        public string Title { get; set; }
        public Artist ArtistId { get; set; }
        public DateTime ReleaseDate { get; set; }

        public virtual ICollection Songs { get; set; }
    }
}