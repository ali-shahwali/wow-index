using Microsoft.EntityFrameworkCore.Migrations;

namespace WowIndex.Migrations
{
    public partial class LeaderboardRankingsModel2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CastleNathriaLeaderboards",
                table: "CastleNathriaLeaderboards");

            migrationBuilder.RenameTable(
                name: "CastleNathriaLeaderboards",
                newName: "RankedCastleNathriaLeaderboard");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RankedCastleNathriaLeaderboard",
                table: "RankedCastleNathriaLeaderboard",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RankedCastleNathriaLeaderboard",
                table: "RankedCastleNathriaLeaderboard");

            migrationBuilder.RenameTable(
                name: "RankedCastleNathriaLeaderboard",
                newName: "CastleNathriaLeaderboards");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CastleNathriaLeaderboards",
                table: "CastleNathriaLeaderboards",
                column: "Id");
        }
    }
}
