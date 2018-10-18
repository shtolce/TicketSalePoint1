using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace TicketSalePoint.Migrations
{
    public partial class initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Orderid",
                table: "Users",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Comments = table.Column<string>(nullable: true),
                    Emissionid = table.Column<int>(nullable: true),
                    InitialCost = table.Column<double>(nullable: false),
                    OrderDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.id);
                    table.ForeignKey(
                        name: "FK_Orders_TicketEmissions_Emissionid",
                        column: x => x.Emissionid,
                        principalTable: "TicketEmissions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_Orderid",
                table: "Users",
                column: "Orderid");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_Emissionid",
                table: "Orders",
                column: "Emissionid");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Orders_Orderid",
                table: "Users",
                column: "Orderid",
                principalTable: "Orders",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Orders_Orderid",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Users_Orderid",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Orderid",
                table: "Users");
        }
    }
}
