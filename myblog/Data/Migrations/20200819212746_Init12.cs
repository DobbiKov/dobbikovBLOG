using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace myblog.Data.Migrations
{
    public partial class Init12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserRoleId",
                table: "users",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserRoleId",
                table: "users");
        }
    }
}
