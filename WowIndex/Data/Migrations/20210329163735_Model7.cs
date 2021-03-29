using Microsoft.EntityFrameworkCore.Migrations;

namespace WowIndex.Data.Migrations
{
    public partial class Model7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "raidName",
                table: "Records",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "raidName",
                table: "Records");
        }
    }
}
