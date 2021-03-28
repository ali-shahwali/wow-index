using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WowIndex.Data.Migrations
{
    public partial class Model1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "guildRankings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    age = table.Column<DateTime>(type: "datetime2", nullable: false),
                    guildid = table.Column<long>(type: "bigint", nullable: true),
                    factionId = table.Column<int>(type: "int", nullable: true),
                    timestamp = table.Column<long>(type: "bigint", nullable: false),
                    region = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    rank = table.Column<long>(type: "bigint", nullable: false)
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "guildRankings");

            migrationBuilder.DropTable(
                name: "Faction");

            migrationBuilder.DropTable(
                name: "Guild");

            migrationBuilder.DropTable(
                name: "Realm");
        }
    }
}
