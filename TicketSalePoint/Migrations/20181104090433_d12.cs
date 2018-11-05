using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace TicketSalePoint.Migrations
{
    public partial class d12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Orders_OrderId",
                table: "Tickets");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "Tickets",
                newName: "Orderid");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_OrderId",
                table: "Tickets",
                newName: "IX_Tickets_Orderid");

            migrationBuilder.AlterColumn<int>(
                name: "Orderid",
                table: "Tickets",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "_OrderId",
                table: "Tickets",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Orders_Orderid",
                table: "Tickets",
                column: "Orderid",
                principalTable: "Orders",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Orders_Orderid",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "_OrderId",
                table: "Tickets");

            migrationBuilder.RenameColumn(
                name: "Orderid",
                table: "Tickets",
                newName: "OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_Orderid",
                table: "Tickets",
                newName: "IX_Tickets_OrderId");

            migrationBuilder.AlterColumn<int>(
                name: "OrderId",
                table: "Tickets",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Orders_OrderId",
                table: "Tickets",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
