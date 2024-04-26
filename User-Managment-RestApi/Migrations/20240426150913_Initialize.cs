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
                    Description = table.Column<string>(type: "TEXT", nullable: false),
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
                    ConfirmPassword = table.Column<string>(type: "TEXT", nullable: false),
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
                    { 1, new DateTime(2024, 4, 26, 18, 9, 12, 588, DateTimeKind.Local).AddTicks(4086), "This is admin!", "Admin" },
                    { 2, new DateTime(2024, 4, 26, 18, 9, 12, 588, DateTimeKind.Local).AddTicks(4098), "This is writer!", "Writer" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "ConfirmPassword", "CreatedTime", "Email", "LastName", "Name", "Password", "RoleId" },
                values: new object[,]
                {
                    { 1, "123456", new DateTime(2024, 4, 26, 18, 9, 12, 588, DateTimeKind.Local).AddTicks(4309), "test1@gmail.com", "Test1", "Test1", "123456", 1 },
                    { 2, "123456*", new DateTime(2024, 4, 26, 18, 9, 12, 588, DateTimeKind.Local).AddTicks(4312), "test2@gmail.com", "Test2", "Test2", "123456*", 1 },
                    { 3, "123", new DateTime(2024, 4, 26, 18, 9, 12, 588, DateTimeKind.Local).AddTicks(4315), "test3@gmail.com", "Test3", "Test3", "123", 2 },
                    { 4, "12", new DateTime(2024, 4, 26, 18, 9, 12, 588, DateTimeKind.Local).AddTicks(4317), "test4@gmail.com", "Test4", "Test4", "12", 2 }
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
