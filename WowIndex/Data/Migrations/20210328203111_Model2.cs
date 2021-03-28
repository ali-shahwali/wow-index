using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WowIndex.Data.Migrations
{
    public partial class Model2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "age",
                table: "guildRankings");

            migrationBuilder.AddColumn<int>(
                name: "LeaderboardEntriesId",
                table: "guildRankings",
                type: "int",
                nullable: true);

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
                    age = table.Column<DateTime>(type: "datetime2", nullable: false),
                    _linksId = table.Column<int>(type: "int", nullable: true),
                    slug = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    criteria_type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JournalInstanceId = table.Column<long>(type: "bigint", nullable: true)
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

            migrationBuilder.AddForeignKey(
                name: "FK_guildRankings_LastEntry_LeaderboardEntriesId",
                table: "guildRankings",
                column: "LeaderboardEntriesId",
                principalTable: "LastEntry",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_guildRankings_LastEntry_LeaderboardEntriesId",
                table: "guildRankings");

            migrationBuilder.DropTable(
                name: "LastEntry");

            migrationBuilder.DropTable(
                name: "JournalInstance");

            migrationBuilder.DropTable(
                name: "Links");

            migrationBuilder.DropTable(
                name: "Self");

            migrationBuilder.DropIndex(
                name: "IX_guildRankings_LeaderboardEntriesId",
                table: "guildRankings");

            migrationBuilder.DropColumn(
                name: "LeaderboardEntriesId",
                table: "guildRankings");

            migrationBuilder.AddColumn<DateTime>(
                name: "age",
                table: "guildRankings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
