using Microsoft.EntityFrameworkCore.Migrations;

namespace Final_Project_Api.Migrations
{
    public partial class Update_Marka_Model : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Marka_Products_ProductId",
                table: "Marka");

            migrationBuilder.DropIndex(
                name: "IX_Marka_ProductId",
                table: "Marka");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Marka");

            migrationBuilder.AddColumn<int>(
                name: "ModelId",
                table: "Products",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Products_ModelId",
                table: "Products",
                column: "ModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Model_ModelId",
                table: "Products",
                column: "ModelId",
                principalTable: "Model",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Model_ModelId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ModelId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ModelId",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Marka",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Marka_ProductId",
                table: "Marka",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Marka_Products_ProductId",
                table: "Marka",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
