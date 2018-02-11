using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace OwnedEntityTipsNTricks.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SalesOrders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrderDate = table.Column<DateTime>(nullable: false),
                    OrderTotal = table.Column<decimal>(nullable: false),
                    BillingAddress_City = table.Column<string>(nullable: true),
                    BillingAddress_PostalCode = table.Column<string>(nullable: true),
                    BillingAddress_Region = table.Column<string>(nullable: true),
                    BillingAddress_Street = table.Column<string>(nullable: true),
                    ShippingAddress_City = table.Column<string>(nullable: true),
                    ShippingAddress_PostalCode = table.Column<string>(nullable: true),
                    ShippingAddress_Region = table.Column<string>(nullable: true),
                    ShippingAddress_Street = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesOrders", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SalesOrders");
        }
    }
}
