using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_commerce.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ordermiggg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserID1",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductID1",
                table: "OrderDetails",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserID1",
                table: "Orders",
                column: "UserID1");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ProductID1",
                table: "OrderDetails",
                column: "ProductID1");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Products_ProductID1",
                table: "OrderDetails",
                column: "ProductID1",
                principalTable: "Products",
                principalColumn: "ProductID");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_UserID1",
                table: "Orders",
                column: "UserID1",
                principalTable: "Users",
                principalColumn: "UserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Products_ProductID1",
                table: "OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_UserID1",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_UserID1",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_ProductID1",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "UserID1",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ProductID1",
                table: "OrderDetails");
        }
    }
}
