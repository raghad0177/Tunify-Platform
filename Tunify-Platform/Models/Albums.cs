﻿namespace Tunify_Platform.Models
{
    public class Albums
    {
        public int AlbumsId { get; set; }
        public string AlbumName { get; set; }
        public string ReleaseDate { get; set; } 
        public int ArtistsId { get; set; }   
        public Artists Artists { get; set; }
        public ICollection<Songs> Songs { get; set; }
    }
}
