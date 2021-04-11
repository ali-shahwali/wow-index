using Microsoft.EntityFrameworkCore.Migrations;

namespace WowIndex.Migrations
{
    public partial class realmRanks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Rank",
                table: "RankedCastleNathriaLeaderboard",
                newName: "RankWorld");

            migrationBuilder.AddColumn<int>(
                name: "RankRealm",
                table: "RankedCastleNathriaLeaderboard",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RankRealm",
                table: "RankedCastleNathriaLeaderboard");

            migrationBuilder.RenameColumn(
                name: "RankWorld",
                table: "RankedCastleNathriaLeaderboard",
                newName: "Rank");
        }
    }
}
