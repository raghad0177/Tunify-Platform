﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Tunify_Platform.Data;

#nullable disable

namespace Tunify_Platform.Migrations
{
    [DbContext(typeof(TunifyDbContext))]
    [Migration("20240816132035_Creating-Tables")]
    partial class CreatingTables
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Tunify_Platform.Models.Albums", b =>
                {
                    b.Property<int>("AlbumsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AlbumsId"));

                    b.Property<string>("AlbumName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ArtistsId")
                        .HasColumnType("int");

                    b.Property<string>("ReleaseDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AlbumsId");

                    b.HasIndex("ArtistsId");

                    b.ToTable("albums");
                });

            modelBuilder.Entity("Tunify_Platform.Models.Artists", b =>
                {
                    b.Property<int>("ArtistsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ArtistsId"));

                    b.Property<string>("ArtistsBio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ArtistsName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ArtistsId");

                    b.ToTable("artists");
                });

            modelBuilder.Entity("Tunify_Platform.Models.PlaylistSongs", b =>
                {
                    b.Property<int>("PlaylistSongsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PlaylistSongsId"));

                    b.Property<int>("PlaylistsId")
                        .HasColumnType("int");

                    b.Property<int>("SongsId")
                        .HasColumnType("int");

                    b.HasKey("PlaylistSongsId");

                    b.HasIndex("PlaylistsId");

                    b.HasIndex("SongsId");

                    b.ToTable("playlistSongs");
                });

            modelBuilder.Entity("Tunify_Platform.Models.Playlists", b =>
                {
                    b.Property<int>("PlaylistsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PlaylistsId"));

                    b.Property<string>("CreatedDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PlaylistsName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UsersId")
                        .HasColumnType("int");

                    b.HasKey("PlaylistsId");

                    b.HasIndex("UsersId");

                    b.ToTable("playlists");
                });

            modelBuilder.Entity("Tunify_Platform.Models.Songs", b =>
                {
                    b.Property<int>("SongsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SongsId"));

                    b.Property<int>("AlbumsId")
                        .HasColumnType("int");

                    b.Property<int>("ArtistsId")
                        .HasColumnType("int");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<int>("Genre")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SongsId");

                    b.HasIndex("AlbumsId");

                    b.HasIndex("ArtistsId");

                    b.ToTable("songs");
                });

            modelBuilder.Entity("Tunify_Platform.Models.Subscriptions", b =>
                {
                    b.Property<int>("SubscriptionsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SubscriptionsId"));

                    b.Property<int>("SubscriptionsPrice")
                        .HasColumnType("int");

                    b.Property<string>("SubscriptionsType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SubscriptionsId");

                    b.ToTable("subscriptions");
                });

            modelBuilder.Entity("Tunify_Platform.Models.Users", b =>
                {
                    b.Property<int>("UsersId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UsersId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JoinDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SubscriptionsId")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UsersId");

                    b.HasIndex("SubscriptionsId");

                    b.ToTable("users");
                });

            modelBuilder.Entity("Tunify_Platform.Models.Albums", b =>
                {
                    b.HasOne("Tunify_Platform.Models.Artists", "Artists")
                        .WithMany("Albums")
                        .HasForeignKey("ArtistsId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Artists");
                });

            modelBuilder.Entity("Tunify_Platform.Models.PlaylistSongs", b =>
                {
                    b.HasOne("Tunify_Platform.Models.Playlists", "Playlists")
                        .WithMany("PlaylistSongs")
                        .HasForeignKey("PlaylistsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tunify_Platform.Models.Songs", "Songs")
                        .WithMany("PlaylistSongs")
                        .HasForeignKey("SongsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Playlists");

                    b.Navigation("Songs");
                });

            modelBuilder.Entity("Tunify_Platform.Models.Playlists", b =>
                {
                    b.HasOne("Tunify_Platform.Models.Users", "Users")
                        .WithMany("Playlists")
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Users");
                });

            modelBuilder.Entity("Tunify_Platform.Models.Songs", b =>
                {
                    b.HasOne("Tunify_Platform.Models.Albums", "Albums")
                        .WithMany("Songs")
                        .HasForeignKey("AlbumsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tunify_Platform.Models.Artists", "Artists")
                        .WithMany("Songs")
                        .HasForeignKey("ArtistsId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Albums");

                    b.Navigation("Artists");
                });

            modelBuilder.Entity("Tunify_Platform.Models.Users", b =>
                {
                    b.HasOne("Tunify_Platform.Models.Subscriptions", "Subscriptions")
                        .WithMany("Users")
                        .HasForeignKey("SubscriptionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Subscriptions");
                });

            modelBuilder.Entity("Tunify_Platform.Models.Albums", b =>
                {
                    b.Navigation("Songs");
                });

            modelBuilder.Entity("Tunify_Platform.Models.Artists", b =>
                {
                    b.Navigation("Albums");

                    b.Navigation("Songs");
                });

            modelBuilder.Entity("Tunify_Platform.Models.Playlists", b =>
                {
                    b.Navigation("PlaylistSongs");
                });

            modelBuilder.Entity("Tunify_Platform.Models.Songs", b =>
                {
                    b.Navigation("PlaylistSongs");
                });

            modelBuilder.Entity("Tunify_Platform.Models.Subscriptions", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("Tunify_Platform.Models.Users", b =>
                {
                    b.Navigation("Playlists");
                });
#pragma warning restore 612, 618
        }
    }
}
