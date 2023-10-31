﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class Addproductsandproducents2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_CustomerId",
                table: "Orders"
            );

            migrationBuilder.DropPrimaryKey(name: "PK_Orders", table: "Orders");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddPrimaryKey(name: "PK_Orders", table: "Orders", column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_CustomerId",
                table: "Orders",
                column: "CustomerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade
            );
        }
    }
}
