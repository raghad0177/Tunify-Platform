using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Drawing.Printing;
using System.Security.Principal;
using Tunify_Platform.Models;
using Tunify_Platform.Repositories.Interfaces;

namespace Tunify_Platform.Data
{
    public class TunifyDbContext: IdentityDbContext<IdentityUser> { 

       public TunifyDbContext(DbContextOptions<TunifyDbContext>  options) : base(options)
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
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Albums>()
                .HasOne(a => a.Artists)
                .WithMany(b => b.Albums)
                .HasForeignKey(a => a.ArtistsId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Playlists>()
                .HasOne(a => a.Users)
                .WithMany(b => b.Playlists)
                .HasForeignKey(a => a.UsersId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<PlaylistSongs>()
                .HasOne(a => a.Songs)
                .WithMany(b => b.PlaylistSongs)
                .HasForeignKey(a => a.SongsId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<PlaylistSongs>()
                .HasOne(a => a.Playlists)
                .WithMany(b => b.PlaylistSongs)
                .HasForeignKey(a => a.PlaylistsId)
               .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Songs>()
                .HasOne(a => a.Artists)
                .WithMany(b => b.Songs)
                .HasForeignKey(a => a.ArtistsId)
                .OnDelete(DeleteBehavior.Restrict);                
            modelBuilder.Entity<Songs>()
              .HasOne(a => a.Albums)
              .WithMany(b => b.Songs)
              .HasForeignKey(a => a.AlbumsId)
             .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Users>()
                .HasOne(a => a.Subscriptions)
                .WithMany(b => b.Users)
                .HasForeignKey(a => a.SubscriptionsId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Albums>().HasData(
                  new Albums { AlbumsId = 1, AlbumName = "First Album", ArtistsId = 1 , ReleaseDate="2000"}
            );
            modelBuilder.Entity<Artists>().HasData(
                new Artists { ArtistsId = 1,  ArtistsName = "First Artist" , ArtistsBio="no bio" },
                new Artists { ArtistsId = 2, ArtistsName = "Second Artist", ArtistsBio = "no bio" }
            );
            modelBuilder.Entity<Songs>().HasData(
                new Songs { SongsId = 1, AlbumsId = 1, ArtistsId = 1, Duration = 30, Title = "First Song", Genre = 1 }
            );
            modelBuilder.Entity<Users>().HasData(
                new Users { UsersId = 1, UserName = "Raghad", Email = "raghad@gmail.com", JoinDate = "2024", SubscriptionsId = 1 }
            );
            modelBuilder.Entity<Playlists>().HasData(
                new Playlists { PlaylistsId = 1, CreatedDate = "2024", PlaylistsName = "First Playlist", UsersId = 1 }
            );
            modelBuilder.Entity<Subscriptions>().HasData(
                new Subscriptions { SubscriptionsId = 1, SubscriptionsPrice = 1, SubscriptionsType="Basic" }
            );
            seedRoles(modelBuilder, "Admin", "update","read","delete","create");
            seedRoles(modelBuilder, "User", "update");
            // Seed the default admin user
            // seedAdminUser(modelBuilder);
        }
        //seedRoles(modelBuilder , Admin , [create, update, delete])
        private void seedRoles(ModelBuilder modelBuilder, string roleName, params string[] permission)
        {
            var role = new IdentityRole
            {
                Id = roleName.ToLower(),
                Name = roleName,
                NormalizedName = roleName.ToUpper(),
                ConcurrencyStamp = Guid.Empty.ToString()
            };
            // add claims for the users
            var claims = permission.Select(permission => new IdentityRoleClaim<string>
            {
                Id = Guid.NewGuid().GetHashCode(),
                // Unique identifier
                RoleId = role.Id,
                ClaimType = "permission",
                ClaimValue = permission
            });
            // Seed the role and its claims
            modelBuilder.Entity<IdentityRole>().HasData(role);
            modelBuilder.Entity<IdentityRoleClaim<string>>().HasData(claims);
        }
        //private void seedAdminUser(ModelBuilder modelBuilder)
        //{
        //    var adminUser = new IdentityUser
        //    {
        //        Id = "admin_user_id",
        //        UserName = "admin",
        //        NormalizedUserName = "ADMIN",
        //        Email = "admin@example.com",
        //        NormalizedEmail = "ADMIN@EXAMPLE.COM",
        //        EmailConfirmed = true,
        //        SecurityStamp = Guid.NewGuid().ToString("D"),
        //        ConcurrencyStamp = Guid.NewGuid().ToString("D"),
        //    };
        //    // Set password for the admin user
        //    var passwordHasher = new PasswordHasher<IdentityUser>();
        //    adminUser.PasswordHash = passwordHasher.HashPassword(adminUser, "AdminPassword123!");

        //    modelBuilder.Entity<IdentityUser>().HasData(adminUser);

        //    // Assign the admin role to the admin user
        //     modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
        //     {
        //         RoleId = "admin",
        //         UserId = adminUser.Id
        //     });

        //    // Add any necessary claims to the admin user
        //    modelBuilder.Entity<IdentityUserClaim<string>>().HasData(new IdentityUserClaim<string>
        //    {
        //        Id = Guid.NewGuid().GetHashCode(),
        //        UserId = adminUser.Id,
        //        ClaimType = "permission",
        //        ClaimValue = "full_access"
        //    });
        //}
    }
}