using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Edu.DataAccess.Migrations
{
    public partial class CourseDetaileTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategorieId",
                table: "Courses",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Blogs",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Categories = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CourseDetailes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AboutCours = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AboutCoursDescription = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: false),
                    ToApply = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ToApplyDescription = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: false),
                    Certification = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CertificationDescription = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    Starts = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Month = table.Column<int>(type: "int", nullable: false),
                    Hours = table.Column<int>(type: "int", nullable: false),
                    Level = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Language = table.Column<string>(type: "nvarchar(22)", maxLength: 22, nullable: false),
                    Students = table.Column<int>(type: "int", nullable: false),
                    Assesments = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CourseFee = table.Column<int>(type: "int", nullable: false),
                    CoursesOfferId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseDetailes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseDetailes_Courses_CoursesOfferId",
                        column: x => x.CoursesOfferId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CategorieId",
                table: "Courses",
                column: "CategorieId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Categories_CategorieId",
                table: "Courses");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "CourseDetailes");

            migrationBuilder.DropIndex(
                name: "IX_Courses_CategorieId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "CategorieId",
                table: "Courses");

            migrationBuilder.AlterColumn<string>(
                name: "Date",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }
    }
}
