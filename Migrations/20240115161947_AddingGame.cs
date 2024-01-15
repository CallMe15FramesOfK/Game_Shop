using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Game_Shop.Migrations
{
    /// <inheritdoc />
    public partial class AddingGame : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_List_GameShopEntity_GameShopEntityId",
                table: "User_List");

            migrationBuilder.DropIndex(
                name: "IX_User_List_GameShopEntityId",
                table: "User_List");

            migrationBuilder.AlterColumn<int>(
                name: "GameShopEntityId",
                table: "User_List",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "User_ListId",
                table: "GameShopEntity",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_GameShopEntity_User_ListId",
                table: "GameShopEntity",
                column: "User_ListId");

            migrationBuilder.AddForeignKey(
                name: "FK_GameShopEntity_User_List_User_ListId",
                table: "GameShopEntity",
                column: "User_ListId",
                principalTable: "User_List",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameShopEntity_User_List_User_ListId",
                table: "GameShopEntity");

            migrationBuilder.DropIndex(
                name: "IX_GameShopEntity_User_ListId",
                table: "GameShopEntity");

            migrationBuilder.DropColumn(
                name: "User_ListId",
                table: "GameShopEntity");

            migrationBuilder.AlterColumn<int>(
                name: "GameShopEntityId",
                table: "User_List",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_List_GameShopEntityId",
                table: "User_List",
                column: "GameShopEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_List_GameShopEntity_GameShopEntityId",
                table: "User_List",
                column: "GameShopEntityId",
                principalTable: "GameShopEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
