using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Edu.DataAccess.Migrations
{
    public partial class TeacherTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "teachers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(22)", maxLength: 22, nullable: false),
                    Posistion = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_teachers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "teacherDetailes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Degree = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Experince = table.Column<int>(type: "int", nullable: false),
                    Hobbies = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Facultry = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(125)", maxLength: 125, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Skaype = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LanguageDegree = table.Column<int>(type: "int", nullable: false),
                    TeamLeaderDegree = table.Column<int>(type: "int", nullable: false),
                    DevelopmentDegree = table.Column<int>(type: "int", nullable: false),
                    DesignDegree = table.Column<int>(type: "int", nullable: false),
                    InnovationDegree = table.Column<int>(type: "int", nullable: false),
                    CommunicationDegree = table.Column<int>(type: "int", nullable: false),
                    TeacherId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_teacherDetailes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_teacherDetailes_teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_teacherDetailes_TeacherId",
                table: "teacherDetailes",
                column: "TeacherId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "teacherDetailes");

            migrationBuilder.DropTable(
                name: "teachers");
        }
    }
}
