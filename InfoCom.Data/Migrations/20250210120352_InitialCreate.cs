using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InfoCom.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Schedules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Schedules",
                columns: new[] { "Id", "CreatedAt", "Description", "DueDate", "IsDeleted", "Status", "Title" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 2, 10, 12, 0, 0, 0, DateTimeKind.Unspecified), "I am Demo description", new DateTime(2025, 2, 10, 12, 0, 0, 0, DateTimeKind.Unspecified), false, "BackLog", "DemoTitle" },
                    { 2, new DateTime(2025, 2, 10, 12, 0, 0, 0, DateTimeKind.Unspecified), "I am Demo description two", new DateTime(2025, 2, 10, 12, 0, 0, 0, DateTimeKind.Unspecified), false, "ToDO", "DemoTitle2" },
                    { 3, new DateTime(2025, 2, 10, 12, 0, 0, 0, DateTimeKind.Unspecified), "I am Demo description three", new DateTime(2025, 2, 10, 12, 0, 0, 0, DateTimeKind.Unspecified), false, "InProgress", "DemoTiTle3" },
                    { 4, new DateTime(2025, 2, 10, 12, 0, 0, 0, DateTimeKind.Unspecified), "I am Demo description four", new DateTime(2025, 2, 10, 12, 0, 0, 0, DateTimeKind.Unspecified), false, "Reviewing", "DemoTiTle4" },
                    { 5, new DateTime(2025, 2, 10, 12, 0, 0, 0, DateTimeKind.Unspecified), "I am Demo description five", new DateTime(2025, 2, 10, 12, 0, 0, 0, DateTimeKind.Unspecified), false, "Revieving", "DemoTiTle5" },
                    { 6, new DateTime(2025, 2, 10, 12, 0, 0, 0, DateTimeKind.Unspecified), "I am Demo description six", new DateTime(2025, 2, 10, 12, 0, 0, 0, DateTimeKind.Unspecified), false, "QATesting", "DemoTiTle6" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Schedules");
        }
    }
}
