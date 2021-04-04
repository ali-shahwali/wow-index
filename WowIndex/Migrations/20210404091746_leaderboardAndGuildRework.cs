using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WowIndex.Migrations
{
    public partial class leaderboardAndGuildRework : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Guilds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GuildId = table.Column<int>(type: "int", nullable: false),
                    RecordCreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameSlug = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Region = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Realm = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RealmSlug = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RealmId = table.Column<int>(type: "int", nullable: false),
                    FactionType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FactionName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guilds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LeaderboardCastleNathria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GuildId = table.Column<int>(type: "int", nullable: false),
                    Progress = table.Column<int>(type: "int", nullable: false),
                    RecordCreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Boss1KillTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Boss2KillTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Boss3KillTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Boss4KillTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Boss5KillTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Boss6KillTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Boss7KillTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Boss8KillTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Boss9KillTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Boss10KillTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaderboardCastleNathria", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Guilds");

            migrationBuilder.DropTable(
                name: "LeaderboardCastleNathria");
        }
    }
}
