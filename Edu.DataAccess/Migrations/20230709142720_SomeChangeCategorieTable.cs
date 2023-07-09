using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Edu.DataAccess.Migrations
{
    public partial class SomeChangeCategorieTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Categories_CategorieId",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_CourseDetailes_CoursesOfferId",
                table: "CourseDetailes");

            migrationBuilder.AlterColumn<int>(
                name: "CategorieId",
                table: "Courses",
                type: "int",
                nullable: true,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CategoriesId",
                table: "Courses",
                type: "int",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CourseDetailes_CoursesOfferId",
                table: "CourseDetailes",
                column: "CoursesOfferId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Categories_CategorieId",
                table: "Courses",
                column: "CategorieId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Categories_CategorieId",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_CourseDetailes_CoursesOfferId",
                table: "CourseDetailes");

            migrationBuilder.DropColumn(
                name: "CategoriesId",
                table: "Courses");

            migrationBuilder.AlterColumn<int>(
                name: "CategorieId",
                table: "Courses",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_CourseDetailes_CoursesOfferId",
                table: "CourseDetailes",
                column: "CoursesOfferId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Categories_CategorieId",
                table: "Courses",
                column: "CategorieId",
                principalTable: "Categories",
                principalColumn: "Id");
        }
    }
}
