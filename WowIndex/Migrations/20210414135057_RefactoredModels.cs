using Microsoft.EntityFrameworkCore.Migrations;

namespace WowIndex.Migrations
{
    public partial class RefactoredModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Faction",
                table: "RankedCastleNathriaLeaderboard");

            migrationBuilder.DropColumn(
                name: "GuildName",
                table: "RankedCastleNathriaLeaderboard");

            migrationBuilder.DropColumn(
                name: "GuildSlug",
                table: "RankedCastleNathriaLeaderboard");

            migrationBuilder.DropColumn(
                name: "Realm",
                table: "RankedCastleNathriaLeaderboard");

            migrationBuilder.DropColumn(
                name: "RealmSlug",
                table: "RankedCastleNathriaLeaderboard");

            migrationBuilder.DropColumn(
                name: "Region",
                table: "RankedCastleNathriaLeaderboard");

            migrationBuilder.AddColumn<int>(
                name: "GuildId",
                table: "RankedCastleNathriaLeaderboard",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RankedCastleNathriaLeaderboard_GuildId",
                table: "RankedCastleNathriaLeaderboard",
                column: "GuildId");

            migrationBuilder.AddForeignKey(
                name: "FK_RankedCastleNathriaLeaderboard_Guilds_GuildId",
                table: "RankedCastleNathriaLeaderboard",
                column: "GuildId",
                principalTable: "Guilds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RankedCastleNathriaLeaderboard_Guilds_GuildId",
                table: "RankedCastleNathriaLeaderboard");

            migrationBuilder.DropIndex(
                name: "IX_RankedCastleNathriaLeaderboard_GuildId",
                table: "RankedCastleNathriaLeaderboard");

            migrationBuilder.DropColumn(
                name: "GuildId",
                table: "RankedCastleNathriaLeaderboard");

            migrationBuilder.AddColumn<string>(
                name: "Faction",
                table: "RankedCastleNathriaLeaderboard",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GuildName",
                table: "RankedCastleNathriaLeaderboard",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GuildSlug",
                table: "RankedCastleNathriaLeaderboard",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Realm",
                table: "RankedCastleNathriaLeaderboard",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RealmSlug",
                table: "RankedCastleNathriaLeaderboard",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Region",
                table: "RankedCastleNathriaLeaderboard",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
