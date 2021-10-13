using Microsoft.EntityFrameworkCore.Migrations;

namespace Super_Shop.Migrations
{
    public partial class AddContactFormRequest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContactFormRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nchar(128)", nullable: false),
                    Message = table.Column<string>(type: "nchar(1024)", nullable: false),
                    Email = table.Column<string>(type: "nchar(256)", nullable: false),
                    HeroId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactFormRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContactFormRequests_Heroes_HeroId",
                        column: x => x.HeroId,
                        principalTable: "Heroes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContactFormRequests_HeroId",
                table: "ContactFormRequests",
                column: "HeroId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactFormRequests");
        }
    }
}
