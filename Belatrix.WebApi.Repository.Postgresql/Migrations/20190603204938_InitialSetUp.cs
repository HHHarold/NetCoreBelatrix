using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Belatrix.WebApi.Repository.Postgresql.Migrations
{
    public partial class InitialSetUp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "customer",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    first_name = table.Column<string>(maxLength: 40, nullable: false),
                    last_name = table.Column<string>(maxLength: 40, nullable: false),
                    city = table.Column<string>(maxLength: 40, nullable: false),
                    country = table.Column<string>(maxLength: 40, nullable: false),
                    phone = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customer", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "supplier",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    company_name = table.Column<string>(maxLength: 40, nullable: false),
                    contact_name = table.Column<string>(maxLength: 50, nullable: false),
                    contact_title = table.Column<string>(maxLength: 40, nullable: false),
                    city = table.Column<string>(maxLength: 40, nullable: false),
                    country = table.Column<string>(maxLength: 40, nullable: false),
                    phone = table.Column<string>(maxLength: 30, nullable: false),
                    fax = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_supplier", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "order",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    order_date = table.Column<DateTime>(nullable: false),
                    order_number = table.Column<string>(maxLength: 10, nullable: false),
                    customer_id = table.Column<int>(nullable: false),
                    total_amount = table.Column<decimal>(type: "decimal(12,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order", x => x.id);
                    table.ForeignKey(
                        name: "order_customer_id_fkey",
                        column: x => x.customer_id,
                        principalTable: "customer",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "product",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    product_name = table.Column<string>(maxLength: 50, nullable: false),
                    supplier_id = table.Column<int>(nullable: false),
                    unit_price = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    package = table.Column<string>(maxLength: 30, nullable: false),
                    is_idscontinued = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product", x => x.id);
                    table.ForeignKey(
                        name: "product_supplier_id_fkey",
                        column: x => x.supplier_id,
                        principalTable: "supplier",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "order_item",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OrderId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    unit_price = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order_item", x => x.id);
                    table.ForeignKey(
                        name: "order_item_order_id_fkey",
                        column: x => x.OrderId,
                        principalTable: "order",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "order_item_product_id_fkey",
                        column: x => x.ProductId,
                        principalTable: "product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "customer_name_idx",
                table: "customer",
                columns: new[] { "last_name", "first_name" });

            migrationBuilder.CreateIndex(
                name: "IX_order_customer_id",
                table: "order",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "order_id_idx",
                table: "order",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "order_order_date_idx",
                table: "order",
                column: "order_date");

            migrationBuilder.CreateIndex(
                name: "order_item_id_idx",
                table: "order_item",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_order_item_OrderId",
                table: "order_item",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "order_item_product_id_idx",
                table: "order_item",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "product_product_name_idx",
                table: "product",
                column: "product_name");

            migrationBuilder.CreateIndex(
                name: "product_supplier_id_idx",
                table: "product",
                column: "supplier_id");

            migrationBuilder.CreateIndex(
                name: "supplier_company_name_idx",
                table: "supplier",
                column: "company_name");

            migrationBuilder.CreateIndex(
                name: "supplier_country_idx",
                table: "supplier",
                column: "country");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "order_item");

            migrationBuilder.DropTable(
                name: "order");

            migrationBuilder.DropTable(
                name: "product");

            migrationBuilder.DropTable(
                name: "customer");

            migrationBuilder.DropTable(
                name: "supplier");
        }
    }
}
