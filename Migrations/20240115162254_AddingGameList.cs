using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Game_Shop.Migrations
{
    /// <inheritdoc />
    public partial class AddingGameList : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "GameGenre",
                table: "User_List",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GameName",
                table: "User_List",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "GamePlatform",
                table: "User_List",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GameGenre",
                table: "User_List");

            migrationBuilder.DropColumn(
                name: "GameName",
                table: "User_List");

            migrationBuilder.DropColumn(
                name: "GamePlatform",
                table: "User_List");

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
    }
}
