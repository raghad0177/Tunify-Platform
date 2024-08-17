namespace Tunify_Platform.Models
{
    public class PlaylistSongs
    {
        public int PlaylistSongsId { get; set; }
        public int SongsId { get; set; }
        public Songs Songs { get; set; }
        public int  PlaylistsId { get; set; }
        public Playlists Playlists { get; set; }
    }
}
