using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateOrderModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Orders_AspNetUsers_ownerId", table: "Orders");

            migrationBuilder.RenameColumn(name: "ownerId", table: "Orders", newName: "CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_ownerId",
                table: "Orders",
                newName: "IX_Orders_CustomerId"
            );

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_CustomerId",
                table: "Orders",
                column: "CustomerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id"
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_CustomerId",
                table: "Orders"
            );

            migrationBuilder.RenameColumn(name: "CustomerId", table: "Orders", newName: "ownerId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                newName: "IX_Orders_ownerId"
            );

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_ownerId",
                table: "Orders",
                column: "ownerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id"
            );
        }
    }
}
