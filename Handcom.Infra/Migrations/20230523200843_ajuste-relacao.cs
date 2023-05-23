using Microsoft.EntityFrameworkCore.Migrations;

namespace Handcom.Infra.Migrations
{
    public partial class ajusterelacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Category_Product_ProductsId",
                table: "Category");

            migrationBuilder.DropForeignKey(
                name: "FK_Supplier_Product_ProductsId",
                table: "Supplier");

            migrationBuilder.DropIndex(
                name: "IX_Supplier_ProductsId",
                table: "Supplier");

            migrationBuilder.DropIndex(
                name: "IX_Category_ProductsId",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "ProductsId",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "ProductsId",
                table: "Category");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Product",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryId",
                table: "Product",
                column: "CategoryId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Product_SupplierId",
                table: "Product",
                column: "SupplierId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Category_CategoryId",
                table: "Product",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Supplier_SupplierId",
                table: "Product",
                column: "SupplierId",
                principalTable: "Supplier",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Category_CategoryId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Supplier_SupplierId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_CategoryId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_SupplierId",
                table: "Product");

            migrationBuilder.AddColumn<int>(
                name: "ProductsId",
                table: "Supplier",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Product",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<int>(
                name: "ProductsId",
                table: "Category",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Supplier_ProductsId",
                table: "Supplier",
                column: "ProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_Category_ProductsId",
                table: "Category",
                column: "ProductsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Category_Product_ProductsId",
                table: "Category",
                column: "ProductsId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Supplier_Product_ProductsId",
                table: "Supplier",
                column: "ProductsId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
