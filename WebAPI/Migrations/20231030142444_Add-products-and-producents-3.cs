using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class Addproductsandproducents3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_AspNetUsers_CustomerId",
                table: "Order"
            );

            migrationBuilder.DropPrimaryKey(name: "PK_Order", table: "Order");

            migrationBuilder.RenameTable(name: "Order", newName: "Orders");

            migrationBuilder.RenameIndex(
                name: "IX_Order_OrderCode",
                table: "Orders",
                newName: "IX_Orders_OrderCode"
            );

            migrationBuilder.RenameIndex(
                name: "IX_Order_CustomerId",
                table: "Orders",
                newName: "IX_Orders_CustomerId"
            );

            migrationBuilder.AddColumn<int>(
                name: "ProducentId",
                table: "Orders",
                type: "int",
                nullable: true
            );

            migrationBuilder.AddPrimaryKey(name: "PK_Orders", table: "Orders", column: "Id");

            migrationBuilder.CreateTable(
                name: "Producents",
                columns: table =>
                    new
                    {
                        ProducentId = table
                            .Column<int>(type: "int", nullable: false)
                            .Annotation("SqlServer:Identity", "1, 1"),
                        ProducentName = table.Column<string>(
                            type: "nvarchar(max)",
                            nullable: false
                        ),
                        Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                    },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producents", x => x.ProducentId);
                }
            );

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table =>
                    new
                    {
                        ProductId = table
                            .Column<int>(type: "int", nullable: false)
                            .Annotation("SqlServer:Identity", "1, 1"),
                        ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                        Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                        ProducentId = table.Column<int>(type: "int", nullable: false)
                    },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                }
            );

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ProducentId",
                table: "Orders",
                column: "ProducentId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ProductId",
                table: "Orders",
                column: "ProductId"
            );

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_CustomerId",
                table: "Orders",
                column: "CustomerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade
            );

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Producents_ProducentId",
                table: "Orders",
                column: "ProducentId",
                principalTable: "Producents",
                principalColumn: "ProducentId"
            );

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Products_ProductId",
                table: "Orders",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_CustomerId",
                table: "Orders"
            );

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Producents_ProducentId",
                table: "Orders"
            );

            migrationBuilder.DropForeignKey(name: "FK_Orders_Products_ProductId", table: "Orders");

            migrationBuilder.DropTable(name: "Producents");

            migrationBuilder.DropTable(name: "Products");

            migrationBuilder.DropPrimaryKey(name: "PK_Orders", table: "Orders");

            migrationBuilder.DropIndex(name: "IX_Orders_ProducentId", table: "Orders");

            migrationBuilder.DropIndex(name: "IX_Orders_ProductId", table: "Orders");

            migrationBuilder.DropColumn(name: "ProducentId", table: "Orders");

            migrationBuilder.RenameTable(name: "Orders", newName: "Order");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_OrderCode",
                table: "Order",
                newName: "IX_Order_OrderCode"
            );

            migrationBuilder.RenameIndex(
                name: "IX_Orders_CustomerId",
                table: "Order",
                newName: "IX_Order_CustomerId"
            );

            migrationBuilder.AddPrimaryKey(name: "PK_Order", table: "Order", column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_AspNetUsers_CustomerId",
                table: "Order",
                column: "CustomerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade
            );
        }
    }
}
