namespace Tunify_Platform.Models
{
    public class Playlists
    {
        public int PlaylistsId { get; set; }
        public int UsersId { get; set; }
        public string PlaylistsName { get; set; }
        public string CreatedDate { get; set; }
        public ICollection<PlaylistSongs> playlists { get; set; }
    }
}
