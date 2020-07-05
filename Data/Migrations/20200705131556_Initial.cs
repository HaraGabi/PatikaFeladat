using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GatekeeperLogs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LicensePlate = table.Column<string>(maxLength: 12, nullable: false),
                    VehicleColor = table.Column<string>(maxLength: 12, nullable: true),
                    PassOver = table.Column<DateTime>(nullable: false),
                    Direction = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GatekeeperLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Partner",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(5,2)", nullable: false, defaultValue: 0.0m),
                    Begin = table.Column<DateTime>(nullable: false),
                    End = table.Column<DateTime>(nullable: true),
                    PaymentPeriod = table.Column<byte>(nullable: false, defaultValue: (byte)1),
                    CardId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partner", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LicensePlate = table.Column<string>(maxLength: 12, nullable: false),
                    PartnerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehicles_Partner_PartnerId",
                        column: x => x.PartnerId,
                        principalTable: "Partner",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "GatekeeperLogs",
                columns: new[] { "Id", "Direction", "LicensePlate", "PassOver", "VehicleColor" },
                values: new object[,]
                {
                    { 1, (byte)1, "ABC123", new DateTime(2020, 6, 26, 10, 10, 0, 0, DateTimeKind.Local), "Yellow" },
                    { 35, (byte)2, "ABC126", new DateTime(2020, 6, 27, 17, 20, 0, 0, DateTimeKind.Local), null },
                    { 36, (byte)2, "ABC127", new DateTime(2020, 6, 27, 18, 10, 0, 0, DateTimeKind.Local), null },
                    { 37, (byte)2, "ABC128", new DateTime(2020, 6, 27, 18, 50, 0, 0, DateTimeKind.Local), null },
                    { 38, (byte)2, "ABC129", new DateTime(2020, 6, 27, 19, 10, 0, 0, DateTimeKind.Local), null },
                    { 39, (byte)1, "ABC123", new DateTime(2020, 6, 27, 20, 10, 0, 0, DateTimeKind.Local), null },
                    { 40, (byte)1, "ABC124", new DateTime(2020, 6, 28, 7, 10, 0, 0, DateTimeKind.Local), null },
                    { 41, (byte)1, "ABC125", new DateTime(2020, 6, 28, 7, 35, 0, 0, DateTimeKind.Local), null },
                    { 42, (byte)1, "ABC126", new DateTime(2020, 6, 28, 7, 45, 0, 0, DateTimeKind.Local), null },
                    { 43, (byte)1, "ABC127", new DateTime(2020, 6, 28, 8, 15, 0, 0, DateTimeKind.Local), null },
                    { 44, (byte)1, "ABC128", new DateTime(2020, 6, 28, 9, 25, 0, 0, DateTimeKind.Local), null },
                    { 45, (byte)1, "ABC129", new DateTime(2020, 6, 28, 10, 35, 0, 0, DateTimeKind.Local), null },
                    { 46, (byte)2, "ABC123", new DateTime(2020, 6, 28, 16, 10, 0, 0, DateTimeKind.Local), null },
                    { 47, (byte)2, "ABC124", new DateTime(2020, 6, 28, 17, 10, 0, 0, DateTimeKind.Local), null },
                    { 48, (byte)2, "ABC125", new DateTime(2020, 6, 28, 18, 15, 0, 0, DateTimeKind.Local), null },
                    { 49, (byte)2, "ABC126", new DateTime(2020, 6, 28, 19, 20, 0, 0, DateTimeKind.Local), null },
                    { 50, (byte)2, "ABC127", new DateTime(2020, 6, 28, 20, 25, 0, 0, DateTimeKind.Local), null },
                    { 51, (byte)2, "ABC128", new DateTime(2020, 6, 28, 21, 30, 0, 0, DateTimeKind.Local), null },
                    { 34, (byte)2, "ABC125", new DateTime(2020, 6, 27, 17, 15, 0, 0, DateTimeKind.Local), null },
                    { 32, (byte)2, "ABC123", new DateTime(2020, 6, 27, 16, 30, 0, 0, DateTimeKind.Local), null },
                    { 33, (byte)2, "ABC124", new DateTime(2020, 6, 27, 17, 10, 0, 0, DateTimeKind.Local), null },
                    { 30, (byte)1, "ABC128", new DateTime(2020, 6, 27, 9, 15, 0, 0, DateTimeKind.Local), null },
                    { 2, (byte)1, "ABC124", new DateTime(2020, 6, 26, 10, 15, 0, 0, DateTimeKind.Local), "Red" },
                    { 3, (byte)1, "ABC125", new DateTime(2020, 6, 26, 10, 30, 0, 0, DateTimeKind.Local), "Blue" },
                    { 4, (byte)1, "ABC126", new DateTime(2020, 6, 26, 10, 35, 0, 0, DateTimeKind.Local), "Purple" },
                    { 5, (byte)1, "ABC127", new DateTime(2020, 6, 26, 10, 55, 0, 0, DateTimeKind.Local), "Black" },
                    { 6, (byte)1, "ABC128", new DateTime(2020, 6, 26, 11, 15, 0, 0, DateTimeKind.Local), "White" },
                    { 7, (byte)2, "ABC123", new DateTime(2020, 6, 26, 11, 25, 0, 0, DateTimeKind.Local), "Orange" },
                    { 8, (byte)1, "ABC129", new DateTime(2020, 6, 26, 11, 45, 0, 0, DateTimeKind.Local), "Green" },
                    { 31, (byte)1, "ABC129", new DateTime(2020, 6, 27, 9, 55, 0, 0, DateTimeKind.Local), null },
                    { 10, (byte)2, "ABC125", new DateTime(2020, 6, 26, 13, 20, 0, 0, DateTimeKind.Local), "Blue" },
                    { 9, (byte)2, "ABC124", new DateTime(2020, 6, 26, 12, 10, 0, 0, DateTimeKind.Local), "Red" },
                    { 12, (byte)2, "ABC127", new DateTime(2020, 6, 26, 15, 45, 0, 0, DateTimeKind.Local), "Black" },
                    { 13, (byte)2, "ABC128", new DateTime(2020, 6, 26, 16, 50, 0, 0, DateTimeKind.Local), "White" },
                    { 14, (byte)2, "ABC129", new DateTime(2020, 6, 26, 17, 55, 0, 0, DateTimeKind.Local), "Green" },
                    { 25, (byte)1, "ABC123", new DateTime(2020, 6, 27, 7, 40, 0, 0, DateTimeKind.Local), null },
                    { 26, (byte)1, "ABC124", new DateTime(2020, 6, 27, 8, 10, 0, 0, DateTimeKind.Local), null },
                    { 27, (byte)1, "ABC125", new DateTime(2020, 6, 27, 8, 30, 0, 0, DateTimeKind.Local), null },
                    { 28, (byte)1, "ABC126", new DateTime(2020, 6, 27, 8, 35, 0, 0, DateTimeKind.Local), null },
                    { 29, (byte)1, "ABC127", new DateTime(2020, 6, 27, 8, 40, 0, 0, DateTimeKind.Local), null },
                    { 11, (byte)2, "ABC126", new DateTime(2020, 6, 26, 14, 30, 0, 0, DateTimeKind.Local), "Purple" }
                });

            migrationBuilder.InsertData(
                table: "Partner",
                columns: new[] { "Id", "Begin", "CardId", "Discount", "End", "Name", "PaymentPeriod" },
                values: new object[,]
                {
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 11111, 0.3m, null, "Partner4", (byte)3 },
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0.1m, null, "Partner1", (byte)1 }
                });

            migrationBuilder.InsertData(
                table: "Partner",
                columns: new[] { "Id", "Begin", "CardId", "End", "Name", "PaymentPeriod" },
                values: new object[] { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Partner2", (byte)2 });

            migrationBuilder.InsertData(
                table: "Partner",
                columns: new[] { "Id", "Begin", "CardId", "Discount", "End", "Name", "PaymentPeriod" },
                values: new object[,]
                {
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0.15m, null, "Partner3", (byte)3 },
                    { 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 22222, 0.3m, null, "Partner5", (byte)3 }
                });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "LicensePlate", "PartnerId" },
                values: new object[,]
                {
                    { 1, "ABC123", 1 },
                    { 2, "ABC124", 2 },
                    { 3, "ABC125", 3 },
                    { 4, "ABC126", 4 },
                    { 5, "ABC127", 4 },
                    { 6, "ABC128", 5 },
                    { 7, "ABC129", 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_LicensePlate",
                table: "Vehicles",
                column: "LicensePlate",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_PartnerId",
                table: "Vehicles",
                column: "PartnerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GatekeeperLogs");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "Partner");
        }
    }
}
