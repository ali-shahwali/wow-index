using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WowIndex.Data.Migrations
{
    public partial class Model3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "guildRankings");

            migrationBuilder.DropTable(
                name: "Faction");

            migrationBuilder.DropTable(
                name: "Guild");

            migrationBuilder.DropTable(
                name: "LastEntry");

            migrationBuilder.DropTable(
                name: "Realm");

            migrationBuilder.DropTable(
                name: "JournalInstance");

            migrationBuilder.DropTable(
                name: "Links");

            migrationBuilder.DropTable(
                name: "Self");

            migrationBuilder.CreateTable(
                name: "Records",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    age = table.Column<DateTime>(type: "datetime2", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    region = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    realm = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    faction = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    progress = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Records", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Records");

            migrationBuilder.CreateTable(
                name: "Faction",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faction", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Realm",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    slug = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Realm", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Self",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    href = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Self", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Guild",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    realmid = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guild", x => x.id);
                    table.ForeignKey(
                        name: "FK_Guild_Realm_realmid",
                        column: x => x.realmid,
                        principalTable: "Realm",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "JournalInstance",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KeyId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JournalInstance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JournalInstance_Self_KeyId",
                        column: x => x.KeyId,
                        principalTable: "Self",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Links",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    selfId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Links", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Links_Self_selfId",
                        column: x => x.selfId,
                        principalTable: "Self",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LastEntry",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JournalInstanceId = table.Column<long>(type: "bigint", nullable: true),
                    _linksId = table.Column<int>(type: "int", nullable: true),
                    age = table.Column<DateTime>(type: "datetime2", nullable: false),
                    criteria_type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    slug = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LastEntry", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LastEntry_JournalInstance_JournalInstanceId",
                        column: x => x.JournalInstanceId,
                        principalTable: "JournalInstance",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LastEntry_Links__linksId",
                        column: x => x._linksId,
                        principalTable: "Links",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "guildRankings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LeaderboardEntriesId = table.Column<int>(type: "int", nullable: true),
                    factionId = table.Column<int>(type: "int", nullable: true),
                    guildid = table.Column<long>(type: "bigint", nullable: true),
                    rank = table.Column<long>(type: "bigint", nullable: false),
                    region = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    timestamp = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_guildRankings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_guildRankings_Faction_factionId",
                        column: x => x.factionId,
                        principalTable: "Faction",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_guildRankings_Guild_guildid",
                        column: x => x.guildid,
                        principalTable: "Guild",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_guildRankings_LastEntry_LeaderboardEntriesId",
                        column: x => x.LeaderboardEntriesId,
                        principalTable: "LastEntry",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Guild_realmid",
                table: "Guild",
                column: "realmid");

            migrationBuilder.CreateIndex(
                name: "IX_guildRankings_factionId",
                table: "guildRankings",
                column: "factionId");

            migrationBuilder.CreateIndex(
                name: "IX_guildRankings_guildid",
                table: "guildRankings",
                column: "guildid");

            migrationBuilder.CreateIndex(
                name: "IX_guildRankings_LeaderboardEntriesId",
                table: "guildRankings",
                column: "LeaderboardEntriesId");

            migrationBuilder.CreateIndex(
                name: "IX_JournalInstance_KeyId",
                table: "JournalInstance",
                column: "KeyId");

            migrationBuilder.CreateIndex(
                name: "IX_LastEntry__linksId",
                table: "LastEntry",
                column: "_linksId");

            migrationBuilder.CreateIndex(
                name: "IX_LastEntry_JournalInstanceId",
                table: "LastEntry",
                column: "JournalInstanceId");

            migrationBuilder.CreateIndex(
                name: "IX_Links_selfId",
                table: "Links",
                column: "selfId");
        }
    }
}
