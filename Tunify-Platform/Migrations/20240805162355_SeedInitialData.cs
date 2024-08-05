using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tunify_Platform.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "playlists",
                columns: new[] { "PlaylistsId", "CreatedDate", "PlaylistsName", "UsersId" },
                values: new object[] { 1, "2024", "first song", 1 });

            migrationBuilder.InsertData(
                table: "songs",
                columns: new[] { "SongsId", "AlbumsId", "ArtistsId", "Duration", "Genre", "Title" },
                values: new object[] { 1, 1, 1, 30, 1, "first song" });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "UsersId", "Email", "JoinDate", "SubscriptionId", "UserName" },
                values: new object[] { 1, "raghad@gmail.com", "2024", 1, "Raghad" });
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
                table: "users",
                keyColumn: "UsersId",
                keyValue: 1);
        }
    }
}
