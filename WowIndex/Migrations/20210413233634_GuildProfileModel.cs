using Microsoft.EntityFrameworkCore.Migrations;

namespace WowIndex.Migrations
{
    public partial class GuildProfileModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GuildProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GuildId = table.Column<int>(type: "int", nullable: true),
                    Biography = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsRecruiting = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuildProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GuildProfiles_Guilds_GuildId",
                        column: x => x.GuildId,
                        principalTable: "Guilds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GuildProfiles_GuildId",
                table: "GuildProfiles",
                column: "GuildId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GuildProfiles");
        }
    }
}
