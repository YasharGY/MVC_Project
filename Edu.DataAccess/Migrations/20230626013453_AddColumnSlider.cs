using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Edu.DataAccess.Migrations
{
    public partial class AddColumnSlider : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title2",
                table: "Sliders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title2",
                table: "Sliders");
        }
    }
}
