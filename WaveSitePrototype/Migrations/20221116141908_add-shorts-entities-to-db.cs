using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WaveBand.Web.Migrations
{
    public partial class addshortsentitiestodb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShortDescription",
                table: "NewsModel");

            migrationBuilder.AddColumn<int>(
                name: "NewsShortId",
                table: "NewsModel",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "NewsShortsModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShortDescription = table.Column<string>(type: "nvarchar(280)", maxLength: 280, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsShortsModel", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NewsModel_NewsShortId",
                table: "NewsModel",
                column: "NewsShortId");

            migrationBuilder.AddForeignKey(
                name: "FK_NewsModel_NewsShortsModel_NewsShortId",
                table: "NewsModel",
                column: "NewsShortId",
                principalTable: "NewsShortsModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NewsModel_NewsShortsModel_NewsShortId",
                table: "NewsModel");

            migrationBuilder.DropTable(
                name: "NewsShortsModel");

            migrationBuilder.DropIndex(
                name: "IX_NewsModel_NewsShortId",
                table: "NewsModel");

            migrationBuilder.DropColumn(
                name: "NewsShortId",
                table: "NewsModel");

            migrationBuilder.AddColumn<string>(
                name: "ShortDescription",
                table: "NewsModel",
                type: "nvarchar(280)",
                maxLength: 280,
                nullable: false,
                defaultValue: "");
        }
    }
}
