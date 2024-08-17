using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tunify_Platform.Migrations
{
    /// <inheritdoc />
    public partial class AddSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "artists",
                columns: new[] { "ArtistsId", "ArtistsBio", "ArtistsName" },
                values: new object[] { 2, "no bio", "Second Artist" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "artists",
                keyColumn: "ArtistsId",
                keyValue: 2);
        }
    }
}
