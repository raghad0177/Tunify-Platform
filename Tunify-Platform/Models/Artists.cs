namespace Tunify_Platform.Models
{
    public class Artists
    {
        public int ArtistsId { get; set; }
        public string ArtistsName { get; set; }
        public string ArtistsBio{get; set; }
        public ICollection<Songs> Songs { get; set; }
        public ICollection<Albums> Albums { get; set; }
    }
}

