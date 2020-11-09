using Microsoft.EntityFrameworkCore.Migrations;

namespace MyProject.Entities.Migrations
{
    public partial class RemovedColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Surname",
                table: "Employees");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Surname",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
