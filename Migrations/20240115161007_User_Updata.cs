using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Game_Shop.Migrations
{
    /// <inheritdoc />
    public partial class User_Updata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User_List",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameShopEntityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_List", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_List_GameShopEntity_GameShopEntityId",
                        column: x => x.GameShopEntityId,
                        principalTable: "GameShopEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_List_GameShopEntityId",
                table: "User_List",
                column: "GameShopEntityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User_List");
        }
    }
}
