namespace Tunify_Platform.Models
{
    public class Songs
    {
        public int SongsId { get; set; }
        public string Title { get; set; }
        public int ArtistsId {  get; set; }
        public int AlbumsId { get; set; }
        public int Duration { get; set; }
        public int Genre {  get; set; }
        public ICollection<PlaylistSongs> songs { get; set; }
    }
}
