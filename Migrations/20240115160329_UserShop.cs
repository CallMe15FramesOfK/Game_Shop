using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Game_Shop.Migrations
{
    /// <inheritdoc />
    public partial class UserShop : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserShopEntity");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserShopEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserShopEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserShopEntity_GameShopEntity_GameId",
                        column: x => x.GameId,
                        principalTable: "GameShopEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserShopEntity_GameId",
                table: "UserShopEntity",
                column: "GameId");
        }
    }
}
