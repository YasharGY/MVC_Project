using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Edu.DataAccess.Migrations
{
    public partial class EventSpeakerTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_EventDetailes_LeftEventsId",
                table: "EventDetailes");

            migrationBuilder.CreateTable(
                name: "Speakers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Postions = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JobName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Speakers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EventSpeakers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventsId = table.Column<int>(type: "int", nullable: false),
                    SpeakersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventSpeakers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventSpeakers_LEvents_EventsId",
                        column: x => x.EventsId,
                        principalTable: "LEvents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventSpeakers_Speakers_SpeakersId",
                        column: x => x.SpeakersId,
                        principalTable: "Speakers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventDetailes_LeftEventsId",
                table: "EventDetailes",
                column: "LeftEventsId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EventSpeakers_EventsId",
                table: "EventSpeakers",
                column: "EventsId");

            migrationBuilder.CreateIndex(
                name: "IX_EventSpeakers_SpeakersId",
                table: "EventSpeakers",
                column: "SpeakersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventSpeakers");

            migrationBuilder.DropTable(
                name: "Speakers");

            migrationBuilder.DropIndex(
                name: "IX_EventDetailes_LeftEventsId",
                table: "EventDetailes");

            migrationBuilder.CreateIndex(
                name: "IX_EventDetailes_LeftEventsId",
                table: "EventDetailes",
                column: "LeftEventsId");
        }
    }
}
