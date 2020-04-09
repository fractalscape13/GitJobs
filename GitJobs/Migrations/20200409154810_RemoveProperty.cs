using Microsoft.EntityFrameworkCore.Migrations;

namespace GitJobs.Migrations
{
    public partial class RemoveProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Jobs");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Jobs",
                nullable: true);
        }
    }
}
