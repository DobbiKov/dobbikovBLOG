using Microsoft.EntityFrameworkCore.Migrations;

namespace myblog.Data.Migrations
{
    public partial class Init11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "CanBanUsers",
                table: "roles",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "CanCreate",
                table: "roles",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "CanCreateRoles",
                table: "roles",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "CanDelete",
                table: "roles",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "CanEdit",
                table: "roles",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "CanEditMainPage",
                table: "roles",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "roles",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CanBanUsers",
                table: "roles");

            migrationBuilder.DropColumn(
                name: "CanCreate",
                table: "roles");

            migrationBuilder.DropColumn(
                name: "CanCreateRoles",
                table: "roles");

            migrationBuilder.DropColumn(
                name: "CanDelete",
                table: "roles");

            migrationBuilder.DropColumn(
                name: "CanEdit",
                table: "roles");

            migrationBuilder.DropColumn(
                name: "CanEditMainPage",
                table: "roles");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "roles");
        }
    }
}
