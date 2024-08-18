using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tunify_Platform.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedingData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "artists",
                columns: new[] { "ArtistsId", "ArtistsBio", "ArtistsName" },
                values: new object[] { 1, "no bio", "First Artist" });

            migrationBuilder.InsertData(
                table: "subscriptions",
                columns: new[] { "SubscriptionsId", "SubscriptionsPrice", "SubscriptionsType" },
                values: new object[] { 1, 1, "Basic" });

            migrationBuilder.InsertData(
                table: "albums",
                columns: new[] { "AlbumsId", "AlbumName", "ArtistsId", "ReleaseDate" },
                values: new object[] { 1, "First Album", 1, "2000" });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "UsersId", "Email", "JoinDate", "SubscriptionsId", "UserName" },
                values: new object[] { 1, "raghad@gmail.com", "2024", 1, "Raghad" });

            migrationBuilder.InsertData(
                table: "playlists",
                columns: new[] { "PlaylistsId", "CreatedDate", "PlaylistsName", "UsersId" },
                values: new object[] { 1, "2024", "First Playlist", 1 });

            migrationBuilder.InsertData(
                table: "songs",
                columns: new[] { "SongsId", "AlbumsId", "ArtistsId", "Duration", "Genre", "Title" },
                values: new object[] { 1, 1, 1, 30, 1, "First Song" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "playlists",
                keyColumn: "PlaylistsId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "songs",
                keyColumn: "SongsId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "albums",
                keyColumn: "AlbumsId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "UsersId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "artists",
                keyColumn: "ArtistsId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "subscriptions",
                keyColumn: "SubscriptionsId",
                keyValue: 1);
        }
    }
}
