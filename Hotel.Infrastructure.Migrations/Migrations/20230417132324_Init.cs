using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel.Infrastructure.Migrations.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Guest",
                columns: table => new
                {
                    GuestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guest", x => x.GuestId);
                });

            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    RoomId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.RoomId);
                });

            migrationBuilder.CreateTable(
                name: "Reservation",
                columns: table => new
                {
                    ReservationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GuestId = table.Column<int>(type: "int", nullable: false),
                    RoomId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservation", x => x.ReservationId);
                    table.ForeignKey(
                        name: "FK_Reservation_Guest_GuestId",
                        column: x => x.GuestId,
                        principalTable: "Guest",
                        principalColumn: "GuestId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservation_Room_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Room",
                        principalColumn: "RoomId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Guest",
                columns: new[] { "GuestId", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "Maxim", "PhoneNumber 1" },
                    { 2, "Denis", "PhoneNumber 2" },
                    { 3, "Valera", "PhoneNumber 3" },
                    { 4, "Ivan", "PhoneNumber 4" }
                });

            migrationBuilder.InsertData(
                table: "Room",
                columns: new[] { "RoomId", "Capacity", "Description", "Number" },
                values: new object[,]
                {
                    { 1, 1, "Room 1a", "1a" },
                    { 2, 2, "Room 2a", "2a" },
                    { 3, 3, "Room 3a", "3a" }
                });

            migrationBuilder.InsertData(
                table: "Reservation",
                columns: new[] { "ReservationId", "EndDate", "GuestId", "RoomId", "StartDate" },
                values: new object[] { 1, new DateTime(2023, 4, 19, 16, 23, 23, 823, DateTimeKind.Local).AddTicks(336), 2, 3, new DateTime(2023, 4, 17, 16, 23, 23, 823, DateTimeKind.Local).AddTicks(319) });

            migrationBuilder.InsertData(
                table: "Reservation",
                columns: new[] { "ReservationId", "EndDate", "GuestId", "RoomId", "StartDate" },
                values: new object[] { 2, new DateTime(2023, 4, 20, 16, 23, 23, 823, DateTimeKind.Local).AddTicks(351), 3, 1, new DateTime(2023, 4, 17, 16, 23, 23, 823, DateTimeKind.Local).AddTicks(349) });

            migrationBuilder.InsertData(
                table: "Reservation",
                columns: new[] { "ReservationId", "EndDate", "GuestId", "RoomId", "StartDate" },
                values: new object[] { 3, new DateTime(2023, 4, 21, 16, 23, 23, 823, DateTimeKind.Local).AddTicks(353), 1, 2, new DateTime(2023, 4, 17, 16, 23, 23, 823, DateTimeKind.Local).AddTicks(353) });

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_GuestId",
                table: "Reservation",
                column: "GuestId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_RoomId",
                table: "Reservation",
                column: "RoomId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservation");

            migrationBuilder.DropTable(
                name: "Guest");

            migrationBuilder.DropTable(
                name: "Room");
        }
    }
}
