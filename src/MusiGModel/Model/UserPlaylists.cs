namespace MusiGModel.Model
{
    internal class UserPlaylist
    {
        public int UserPlaylistId { get; set; }
        public int UserId { get; set; }
        public string PlaylistTitle { get; set; }
        public string PlaylistDescription { get; set; }

        public User User { get; set; }
    }
}