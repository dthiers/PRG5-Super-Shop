using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Super_Shop.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nchar(64)", nullable: false),
                    Role = table.Column<string>(type: "nchar(64)", nullable: false, defaultValue: "unknown"),
                    ImageUri = table.Column<string>(type: "nvarchar(512)", nullable: true, defaultValue: "~/img/employees/default_employee.png")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Heroes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false),
                    PowerLevel = table.Column<int>(type: "int", nullable: false),
                    ImageUri = table.Column<string>(type: "nvarchar(512)", nullable: true, defaultValue: "~/img/default_hero.png"),
                    CreatedAt = table.Column<DateTime>(type: "Date", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Heroes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nchar(256)", nullable: false),
                    ImageUri = table.Column<string>(type: "nvarchar(512)", nullable: true, defaultValue: "~/img/employees/default_employee.png")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HeroTeam",
                columns: table => new
                {
                    HeroesId = table.Column<int>(type: "int", nullable: false),
                    TeamsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeroTeam", x => new { x.HeroesId, x.TeamsId });
                    table.ForeignKey(
                        name: "FK_HeroTeam_Heroes_HeroesId",
                        column: x => x.HeroesId,
                        principalTable: "Heroes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HeroTeam_Teams_TeamsId",
                        column: x => x.TeamsId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "ImageUri", "Name", "Role" },
                values: new object[,]
                {
                    { 1, "~/img/employees/eric.jfif", "Eric Kuijpers", "CEO" },
                    { 2, "~/img/employees/carron.jfif", "Carron Schilders", "CTO" },
                    { 3, "~/img/employees/stijn.jfif", "Stijn Smulders", "Service desk" },
                    { 4, "~/img/interns/adam.jpg", "Adam Sandler", "Intern" }
                });

            migrationBuilder.InsertData(
                table: "Heroes",
                columns: new[] { "Id", "ImageUri", "Name", "PowerLevel" },
                values: new object[,]
                {
                    { 1, "~/img/iron_man.png", "Iron Man", 9001 },
                    { 2, "~/img/kermit.png", "Kermit the frog", 5 },
                    { 3, "~/img/batman.png", "Batman", 1 },
                    { 4, "~/img/deadpool.png", "Deadpool", 200 },
                    { 5, "~/img/wolverine.png", "Wolverine", 150 }
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "ImageUri", "Name" },
                values: new object[,]
                {
                    { 1, "", "The dream team" },
                    { 2, "", "The unbrella accademy" },
                    { 3, "", "Dharma Initiative" }
                });

            migrationBuilder.InsertData(
                table: "HeroTeam",
                columns: new[] { "HeroesId", "TeamsId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 1 },
                    { 2, 2 },
                    { 3, 2 },
                    { 4, 2 },
                    { 3, 3 },
                    { 4, 3 },
                    { 5, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_HeroTeam_TeamsId",
                table: "HeroTeam",
                column: "TeamsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "HeroTeam");

            migrationBuilder.DropTable(
                name: "Heroes");

            migrationBuilder.DropTable(
                name: "Teams");
        }
    }
}
