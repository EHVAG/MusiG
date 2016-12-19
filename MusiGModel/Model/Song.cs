using System;

namespace MusiGModel
{
    public class Song
    {
        public int SongId { get; set; }
        public string Title { get; set; }
        public int AlbumId { get; set; }
        public int ArtistId { get; set; }
        public DateTime ReleaseDate { get; set; }

        public virtual Album Album { get; set; }
        public virtual Artist Artist { get; set; }
    }
}