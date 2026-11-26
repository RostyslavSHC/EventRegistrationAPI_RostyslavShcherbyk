using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EventRegistrationAPI_RostyslavShcherbyk.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    EventId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EventDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.EventId);
                });

            migrationBuilder.CreateTable(
                name: "Registrations",
                columns: table => new
                {
                    RegistrationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventId = table.Column<int>(type: "int", nullable: false),
                    StudentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegisteredOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registrations", x => x.RegistrationId);
                    table.ForeignKey(
                        name: "FK_Registrations_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "EventId", "Capacity", "EventDate", "Location", "Title" },
                values: new object[,]
                {
                    { 1, 50, new DateTime(2026, 9, 15, 10, 0, 0, 0, DateTimeKind.Unspecified), "Davis Campus", "Campus Welcome Day" },
                    { 2, 30, new DateTime(2027, 1, 20, 12, 0, 0, 0, DateTimeKind.Unspecified), "Trafalgar Campus", "Game Development Workshop" },
                    { 3, 2, new DateTime(2027, 2, 10, 14, 0, 0, 0, DateTimeKind.Unspecified), "Hazel McCallion Campus", "Career Networking Event" },
                    { 4, 40, new DateTime(2027, 3, 15, 11, 0, 0, 0, DateTimeKind.Unspecified), "Davis Campus", "Programming Competition" }
                });

            migrationBuilder.InsertData(
                table: "Registrations",
                columns: new[] { "RegistrationId", "Email", "EventId", "RegisteredOn", "StudentName" },
                values: new object[,]
                {
                    { 1, "alex@example.com", 3, new DateTime(2026, 11, 20, 10, 0, 0, 0, DateTimeKind.Unspecified), "Alex Smith" },
                    { 2, "daniel@example.com", 3, new DateTime(2026, 11, 21, 12, 0, 0, 0, DateTimeKind.Unspecified), "Daniel Brown" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Registrations_EventId",
                table: "Registrations",
                column: "EventId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Registrations");

            migrationBuilder.DropTable(
                name: "Events");
        }
    }
}
