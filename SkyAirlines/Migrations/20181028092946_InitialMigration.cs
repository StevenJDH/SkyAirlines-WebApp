using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SkyAirlines.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aircrafts",
                columns: table => new
                {
                    AircraftId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AircraftModel = table.Column<string>(maxLength: 10, nullable: false),
                    AircraftCapacity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aircrafts", x => x.AircraftId);
                });

            migrationBuilder.CreateTable(
                name: "Airports",
                columns: table => new
                {
                    AirportId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AirportCode = table.Column<string>(maxLength: 5, nullable: false),
                    AirportName = table.Column<string>(maxLength: 45, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airports", x => x.AirportId);
                });

            migrationBuilder.CreateTable(
                name: "Passengers",
                columns: table => new
                {
                    PassengerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(maxLength: 30, nullable: false),
                    LastName = table.Column<string>(maxLength: 30, nullable: false),
                    Passport = table.Column<string>(maxLength: 10, nullable: false),
                    DOB = table.Column<DateTime>(type: "Date", nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 20, nullable: false),
                    Email = table.Column<string>(maxLength: 254, nullable: true),
                    CheckedBaggage = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passengers", x => x.PassengerId);
                });

            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    FlightPrefix = table.Column<string>(maxLength: 4, nullable: false),
                    FlightId = table.Column<int>(nullable: false),
                    AircraftId = table.Column<int>(nullable: false),
                    AirportId = table.Column<int>(nullable: false),
                    Departure = table.Column<DateTime>(type: "DateTime2", nullable: false),
                    Arrival = table.Column<DateTime>(type: "DateTime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => new { x.FlightPrefix, x.FlightId });
                    table.ForeignKey(
                        name: "FK_Flights_Aircrafts_AircraftId",
                        column: x => x.AircraftId,
                        principalTable: "Aircrafts",
                        principalColumn: "AircraftId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Flights_Airports_AirportId",
                        column: x => x.AirportId,
                        principalTable: "Airports",
                        principalColumn: "AirportId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Manifests",
                columns: table => new
                {
                    FlightPrefix = table.Column<string>(maxLength: 4, nullable: false),
                    FlightId = table.Column<int>(nullable: false),
                    PassengerId = table.Column<int>(nullable: false),
                    Seat = table.Column<string>(maxLength: 4, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manifests", x => new { x.FlightPrefix, x.FlightId, x.PassengerId });
                    table.ForeignKey(
                        name: "FK_Manifests_Passengers_PassengerId",
                        column: x => x.PassengerId,
                        principalTable: "Passengers",
                        principalColumn: "PassengerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Manifests_Flights_FlightPrefix_FlightId",
                        columns: x => new { x.FlightPrefix, x.FlightId },
                        principalTable: "Flights",
                        principalColumns: new[] { "FlightPrefix", "FlightId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Aircrafts",
                columns: new[] { "AircraftId", "AircraftCapacity", "AircraftModel" },
                values: new object[,]
                {
                    { 1, 853, "A380-800" },
                    { 2, 700, "747-8" },
                    { 3, 624, "747-400" },
                    { 4, 550, "777-300" },
                    { 5, 440, "777-200" },
                    { 6, 150, "A320" },
                    { 7, 126, "A319" },
                    { 8, 192, "A321" },
                    { 9, 150, "A320" },
                    { 10, 150, "A320" }
                });

            migrationBuilder.InsertData(
                table: "Airports",
                columns: new[] { "AirportId", "AirportCode", "AirportName" },
                values: new object[,]
                {
                    { 10, "HBH", "Hobart Bay" },
                    { 9, "GFK", "Grand Forks" },
                    { 8, "FRF", "Rhein-Main AFB" },
                    { 7, "ESR", "El Salvador" },
                    { 6, "DDP", "Dorado Beach" },
                    { 5, "CDG", "Charles De Gaulle" },
                    { 4, "BEO", "Belmont" },
                    { 3, "AOK", "Karpathos" },
                    { 2, "LAS", "Mccarran International" },
                    { 1, "ATT", "Atmautluak" }
                });

            migrationBuilder.InsertData(
                table: "Passengers",
                columns: new[] { "PassengerId", "CheckedBaggage", "DOB", "Email", "FirstName", "LastName", "Passport", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, true, new DateTime(1980, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "jdoe@mail.com", "John", "Doe", "837568289", "15005550000" },
                    { 2, true, new DateTime(1981, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "jdowers@mail.com", "Jenny", "Dowers", "385648365", "15015550001" },
                    { 3, true, new DateTime(1982, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "drow@mail.com", "David", "Row", "121493498", "15025550002" },
                    { 4, true, new DateTime(1983, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "ajones@mail.com", "Anny", "Jones", "982433847", "15035550003" },
                    { 5, true, new DateTime(1984, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "sjenkins@mail.com", "Steven", "Jenkins", "999999999", "15045550004" },
                    { 6, true, new DateTime(1985, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rdoe@email.com", "Rachel ", "Doe", "123456789", "15055550005" },
                    { 7, true, new DateTime(1986, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "fstanly@mail.com", "Frank", "Stanly", "111111111", "15065550006" },
                    { 8, true, new DateTime(1987, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "jbowe@mail.com", "Jack", "Bowe", "101010101", "15075550007" },
                    { 9, true, new DateTime(1988, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "clake@mail.com", "Christina", "Lake", "987654321", "15085550008" },
                    { 10, true, new DateTime(1989, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "jdivers@mail.com", "Jenny", "Divers", "567894321", "15095550009" }
                });

            migrationBuilder.InsertData(
                table: "Flights",
                columns: new[] { "FlightPrefix", "FlightId", "AircraftId", "AirportId", "Arrival", "Departure" },
                values: new object[,]
                {
                    { "SA", 11000, 10, 1, new DateTime(2017, 7, 1, 19, 50, 0, 0, DateTimeKind.Unspecified), new DateTime(2017, 6, 1, 17, 20, 0, 0, DateTimeKind.Unspecified) },
                    { "SA", 11010, 9, 2, new DateTime(2017, 7, 1, 18, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2017, 7, 1, 16, 15, 0, 0, DateTimeKind.Unspecified) },
                    { "SA", 11020, 8, 3, new DateTime(2017, 7, 1, 17, 40, 0, 0, DateTimeKind.Unspecified), new DateTime(2017, 7, 1, 15, 10, 0, 0, DateTimeKind.Unspecified) },
                    { "SA", 11030, 7, 4, new DateTime(2017, 7, 1, 17, 50, 0, 0, DateTimeKind.Unspecified), new DateTime(2017, 7, 1, 14, 5, 0, 0, DateTimeKind.Unspecified) },
                    { "SA", 11040, 6, 5, new DateTime(2017, 7, 1, 18, 55, 0, 0, DateTimeKind.Unspecified), new DateTime(2017, 7, 1, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "SA", 11050, 5, 6, new DateTime(2017, 7, 2, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2017, 7, 2, 12, 35, 0, 0, DateTimeKind.Unspecified) },
                    { "SA", 11060, 4, 7, new DateTime(2017, 7, 2, 20, 10, 0, 0, DateTimeKind.Unspecified), new DateTime(2017, 7, 2, 11, 30, 0, 0, DateTimeKind.Unspecified) },
                    { "SA", 11070, 3, 8, new DateTime(2017, 7, 2, 21, 15, 0, 0, DateTimeKind.Unspecified), new DateTime(2017, 7, 2, 10, 25, 0, 0, DateTimeKind.Unspecified) },
                    { "SA", 11080, 2, 9, new DateTime(2017, 7, 2, 22, 10, 0, 0, DateTimeKind.Unspecified), new DateTime(2017, 7, 2, 9, 20, 0, 0, DateTimeKind.Unspecified) },
                    { "SA", 11090, 1, 10, new DateTime(2017, 7, 2, 23, 25, 0, 0, DateTimeKind.Unspecified), new DateTime(2017, 7, 2, 8, 15, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Manifests",
                columns: new[] { "FlightPrefix", "FlightId", "PassengerId", "Seat" },
                values: new object[,]
                {
                    { "SA", 11000, 1, "A01" },
                    { "SA", 11010, 2, "B02" },
                    { "SA", 11020, 3, "C03" },
                    { "SA", 11030, 4, "D04" },
                    { "SA", 11040, 5, "A10" },
                    { "SA", 11050, 6, "G01" },
                    { "SA", 11060, 7, "H02" },
                    { "SA", 11070, 8, "I03" },
                    { "SA", 11080, 9, "J04" },
                    { "SA", 11090, 10, "K05" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Airports_AirportCode",
                table: "Airports",
                column: "AirportCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Airports_AirportName",
                table: "Airports",
                column: "AirportName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Flights_AircraftId",
                table: "Flights",
                column: "AircraftId");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_AirportId",
                table: "Flights",
                column: "AirportId");

            migrationBuilder.CreateIndex(
                name: "IX_Manifests_PassengerId",
                table: "Manifests",
                column: "PassengerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Manifests");

            migrationBuilder.DropTable(
                name: "Passengers");

            migrationBuilder.DropTable(
                name: "Flights");

            migrationBuilder.DropTable(
                name: "Aircrafts");

            migrationBuilder.DropTable(
                name: "Airports");
        }
    }
}
