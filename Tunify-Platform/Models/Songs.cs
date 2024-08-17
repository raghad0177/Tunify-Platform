namespace Tunify_Platform.Models
{
    public class Songs
    {
        public int SongsId { get; set; }
        public string Title { get; set; }
        public int ArtistsId {  get; set; }
        public Artists Artists { get; set; }
        public int AlbumsId { get; set; }
        public Albums Albums { get; set; }
        public int Duration { get; set; }
        public int Genre {  get; set; }
        public ICollection<PlaylistSongs> PlaylistSongs { get; set; }
    }
}
