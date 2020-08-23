using Microsoft.EntityFrameworkCore.Migrations;

namespace myblog.Data.Migrations
{
    public partial class Init16 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Token",
                table: "postComments",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Token",
                table: "postComments");
        }
    }
}
