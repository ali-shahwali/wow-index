using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WowIndex.Migrations
{
    public partial class NewLeaderboardModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExpirationTime",
                table: "RankedCastleNathriaLeaderboard");

            migrationBuilder.DropColumn(
                name: "RankRealm",
                table: "RankedCastleNathriaLeaderboard");

            migrationBuilder.RenameColumn(
                name: "RankWorld",
                table: "RankedCastleNathriaLeaderboard",
                newName: "Score");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Score",
                table: "RankedCastleNathriaLeaderboard",
                newName: "RankWorld");

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpirationTime",
                table: "RankedCastleNathriaLeaderboard",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "RankRealm",
                table: "RankedCastleNathriaLeaderboard",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
