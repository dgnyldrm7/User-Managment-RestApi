using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace User_Managment_RestApi.Migrations
{
    /// <inheritdoc />
    public partial class Initialize : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleName = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    ConfirmPassword = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    RoleId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedTime", "Description", "RoleName" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 5, 1, 16, 32, 15, 9, DateTimeKind.Local).AddTicks(728), "Admin role", "Admin" },
                    { 2, new DateTime(2024, 5, 1, 16, 32, 15, 9, DateTimeKind.Local).AddTicks(740), "Regular user role", "User" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "ConfirmPassword", "CreatedTime", "Email", "LastName", "Name", "Password", "RoleId" },
                values: new object[,]
                {
                    { 1, "password123", new DateTime(2024, 5, 1, 16, 32, 15, 9, DateTimeKind.Local).AddTicks(834), "john@example.com", "Doe", "John", "password123", 1 },
                    { 2, "password456", new DateTime(2024, 5, 1, 16, 32, 15, 9, DateTimeKind.Local).AddTicks(837), "jane@example.com", "Doe", "Jane", "password456", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
