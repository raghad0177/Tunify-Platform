using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tunify_Platform.Migrations
{
    /// <inheritdoc />
    public partial class AddOnDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_playlists_users_UsersId",
                table: "playlists");

            migrationBuilder.DropForeignKey(
                name: "FK_playlistSongs_playlists_PlaylistsId",
                table: "playlistSongs");

            migrationBuilder.DropForeignKey(
                name: "FK_playlistSongs_songs_SongsId",
                table: "playlistSongs");

            migrationBuilder.DropForeignKey(
                name: "FK_songs_albums_AlbumsId",
                table: "songs");

            migrationBuilder.DropForeignKey(
                name: "FK_users_subscriptions_SubscriptionsId",
                table: "users");

            migrationBuilder.AddForeignKey(
                name: "FK_playlists_users_UsersId",
                table: "playlists",
                column: "UsersId",
                principalTable: "users",
                principalColumn: "UsersId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_playlistSongs_playlists_PlaylistsId",
                table: "playlistSongs",
                column: "PlaylistsId",
                principalTable: "playlists",
                principalColumn: "PlaylistsId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_playlistSongs_songs_SongsId",
                table: "playlistSongs",
                column: "SongsId",
                principalTable: "songs",
                principalColumn: "SongsId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_songs_albums_AlbumsId",
                table: "songs",
                column: "AlbumsId",
                principalTable: "albums",
                principalColumn: "AlbumsId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_users_subscriptions_SubscriptionsId",
                table: "users",
                column: "SubscriptionsId",
                principalTable: "subscriptions",
                principalColumn: "SubscriptionsId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_playlists_users_UsersId",
                table: "playlists");

            migrationBuilder.DropForeignKey(
                name: "FK_playlistSongs_playlists_PlaylistsId",
                table: "playlistSongs");

            migrationBuilder.DropForeignKey(
                name: "FK_playlistSongs_songs_SongsId",
                table: "playlistSongs");

            migrationBuilder.DropForeignKey(
                name: "FK_songs_albums_AlbumsId",
                table: "songs");

            migrationBuilder.DropForeignKey(
                name: "FK_users_subscriptions_SubscriptionsId",
                table: "users");

            migrationBuilder.AddForeignKey(
                name: "FK_playlists_users_UsersId",
                table: "playlists",
                column: "UsersId",
                principalTable: "users",
                principalColumn: "UsersId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_playlistSongs_playlists_PlaylistsId",
                table: "playlistSongs",
                column: "PlaylistsId",
                principalTable: "playlists",
                principalColumn: "PlaylistsId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_playlistSongs_songs_SongsId",
                table: "playlistSongs",
                column: "SongsId",
                principalTable: "songs",
                principalColumn: "SongsId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_songs_albums_AlbumsId",
                table: "songs",
                column: "AlbumsId",
                principalTable: "albums",
                principalColumn: "AlbumsId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_users_subscriptions_SubscriptionsId",
                table: "users",
                column: "SubscriptionsId",
                principalTable: "subscriptions",
                principalColumn: "SubscriptionsId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
