using Microsoft.EntityFrameworkCore.Migrations;

namespace myblog.Data.Migrations
{
    public partial class Init7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Portfolio",
                table: "Portfolio");

            migrationBuilder.RenameTable(
                name: "Portfolio",
                newName: "Portfolios");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Portfolios",
                table: "Portfolios",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Portfolios",
                table: "Portfolios");

            migrationBuilder.RenameTable(
                name: "Portfolios",
                newName: "Portfolio");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Portfolio",
                table: "Portfolio",
                column: "Id");
        }
    }
}
