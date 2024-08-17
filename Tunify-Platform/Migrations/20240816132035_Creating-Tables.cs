using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tunify_Platform.Migrations
{
    /// <inheritdoc />
    public partial class CreatingTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "artists",
                columns: table => new
                {
                    ArtistsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArtistsName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArtistsBio = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_artists", x => x.ArtistsId);
                });

            migrationBuilder.CreateTable(
                name: "subscriptions",
                columns: table => new
                {
                    SubscriptionsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubscriptionsType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubscriptionsPrice = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subscriptions", x => x.SubscriptionsId);
                });

            migrationBuilder.CreateTable(
                name: "albums",
                columns: table => new
                {
                    AlbumsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlbumName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReleaseDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArtistsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_albums", x => x.AlbumsId);
                    table.ForeignKey(
                        name: "FK_albums_artists_ArtistsId",
                        column: x => x.ArtistsId,
                        principalTable: "artists",
                        principalColumn: "ArtistsId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    UsersId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JoinDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubscriptionsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.UsersId);
                    table.ForeignKey(
                        name: "FK_users_subscriptions_SubscriptionsId",
                        column: x => x.SubscriptionsId,
                        principalTable: "subscriptions",
                        principalColumn: "SubscriptionsId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "songs",
                columns: table => new
                {
                    SongsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArtistsId = table.Column<int>(type: "int", nullable: false),
                    AlbumsId = table.Column<int>(type: "int", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    Genre = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_songs", x => x.SongsId);
                    table.ForeignKey(
                        name: "FK_songs_albums_AlbumsId",
                        column: x => x.AlbumsId,
                        principalTable: "albums",
                        principalColumn: "AlbumsId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_songs_artists_ArtistsId",
                        column: x => x.ArtistsId,
                        principalTable: "artists",
                        principalColumn: "ArtistsId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "playlists",
                columns: table => new
                {
                    PlaylistsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsersId = table.Column<int>(type: "int", nullable: false),
                    PlaylistsName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_playlists", x => x.PlaylistsId);
                    table.ForeignKey(
                        name: "FK_playlists_users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "users",
                        principalColumn: "UsersId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "playlistSongs",
                columns: table => new
                {
                    PlaylistSongsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SongsId = table.Column<int>(type: "int", nullable: false),
                    PlaylistsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_playlistSongs", x => x.PlaylistSongsId);
                    table.ForeignKey(
                        name: "FK_playlistSongs_playlists_PlaylistsId",
                        column: x => x.PlaylistsId,
                        principalTable: "playlists",
                        principalColumn: "PlaylistsId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_playlistSongs_songs_SongsId",
                        column: x => x.SongsId,
                        principalTable: "songs",
                        principalColumn: "SongsId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_albums_ArtistsId",
                table: "albums",
                column: "ArtistsId");

            migrationBuilder.CreateIndex(
                name: "IX_playlists_UsersId",
                table: "playlists",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_playlistSongs_PlaylistsId",
                table: "playlistSongs",
                column: "PlaylistsId");

            migrationBuilder.CreateIndex(
                name: "IX_playlistSongs_SongsId",
                table: "playlistSongs",
                column: "SongsId");

            migrationBuilder.CreateIndex(
                name: "IX_songs_AlbumsId",
                table: "songs",
                column: "AlbumsId");

            migrationBuilder.CreateIndex(
                name: "IX_songs_ArtistsId",
                table: "songs",
                column: "ArtistsId");

            migrationBuilder.CreateIndex(
                name: "IX_users_SubscriptionsId",
                table: "users",
                column: "SubscriptionsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "playlistSongs");

            migrationBuilder.DropTable(
                name: "playlists");

            migrationBuilder.DropTable(
                name: "songs");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "albums");

            migrationBuilder.DropTable(
                name: "subscriptions");

            migrationBuilder.DropTable(
                name: "artists");
        }
    }
}
