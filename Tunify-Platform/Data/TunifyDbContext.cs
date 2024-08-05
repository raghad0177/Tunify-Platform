using Microsoft.EntityFrameworkCore;
using System.Drawing.Printing;
using Tunify_Platform.Models;

namespace Tunify_Platform.Data
{
    public class TunifyDbContext: DbContext
    {
       public TunifyDbContext(DbContextOptions <TunifyDbContext> options) : base(options)
       { 
       }
        public DbSet<Albums> albums { get; set; }
        public DbSet<Artists> artists { get; set; }
        public DbSet<Playlists> playlists { get; set; }
        public DbSet<PlaylistSongs> playlistSongs { get; set; }
        public DbSet<Songs> songs { get; set; } 
        public DbSet<Subscriptions> subscriptions { get; set; }
        public DbSet<Users> users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>().HasData(
            new Users { UsersId=1,UserName="Raghad",Email="raghad@gmail.com",JoinDate="2024",SubscriptionId=1}
            );
            modelBuilder.Entity<Songs>().HasData(
            new Songs { SongsId=1,AlbumsId=1,ArtistsId=1,Duration=30,Title="first song",Genre=1 }
            );
            modelBuilder.Entity<Playlists>().HasData(
            new Playlists { PlaylistsId=1,CreatedDate="2024",PlaylistsName="first song",UsersId=1 }
            );
        }
    }
}