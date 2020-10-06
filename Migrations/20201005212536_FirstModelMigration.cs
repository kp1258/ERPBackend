using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace ERPBackend.Migrations
{
    public partial class FirstModelMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    ClientId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    CompanyName = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Street = table.Column<string>(nullable: false),
                    PostalCode = table.Column<string>(nullable: false),
                    City = table.Column<string>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: false),
                    EMail = table.Column<string>(nullable: true),
                    SalesmanId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.ClientId);
                    table.ForeignKey(
                        name: "FK_Clients_Users_SalesmanId",
                        column: x => x.SalesmanId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomProducts",
                columns: table => new
                {
                    CustomProductId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    TechnologistId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomProducts", x => x.CustomProductId);
                    table.ForeignKey(
                        name: "FK_CustomProducts_Users_TechnologistId",
                        column: x => x.TechnologistId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MaterialWarehouse",
                columns: table => new
                {
                    MaterialItemId = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialWarehouse", x => x.MaterialItemId);
                    table.ForeignKey(
                        name: "FK_MaterialWarehouse_Materials_MaterialItemId",
                        column: x => x.MaterialItemId,
                        principalTable: "Materials",
                        principalColumn: "MaterialId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StandardProductCategories",
                columns: table => new
                {
                    StandardProductCategoryId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    CategoryName = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StandardProductCategories", x => x.StandardProductCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    PlacingDate = table.Column<DateTime>(nullable: false),
                    FulfillmentDate = table.Column<DateTime>(nullable: false),
                    Status = table.Column<string>(nullable: false),
                    Type = table.Column<string>(nullable: false),
                    ClientId = table.Column<int>(nullable: false),
                    SalesmanId = table.Column<int>(nullable: false),
                    WarehousemanId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Users_SalesmanId",
                        column: x => x.SalesmanId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Users_WarehousemanId",
                        column: x => x.WarehousemanId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StandardProducts",
                columns: table => new
                {
                    StandardProductId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 40, nullable: false),
                    Dimensions = table.Column<string>(nullable: true),
                    StandardProductCategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StandardProducts", x => x.StandardProductId);
                    table.ForeignKey(
                        name: "FK_StandardProducts_StandardProductCategories_StandardProductCa~",
                        column: x => x.StandardProductCategoryId,
                        principalTable: "StandardProductCategories",
                        principalColumn: "StandardProductCategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomOrderDetails",
                columns: table => new
                {
                    CustomOrderDetailId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    OrderId = table.Column<int>(nullable: false),
                    CustomProductId = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomOrderDetails", x => x.CustomOrderDetailId);
                    table.ForeignKey(
                        name: "FK_CustomOrderDetails_CustomProducts_CustomProductId",
                        column: x => x.CustomProductId,
                        principalTable: "CustomProducts",
                        principalColumn: "CustomProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomOrderDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StandardOrderDetails",
                columns: table => new
                {
                    StandardOrderDetailId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    OrderId = table.Column<int>(nullable: false),
                    StandardProductId = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StandardOrderDetails", x => x.StandardOrderDetailId);
                    table.ForeignKey(
                        name: "FK_StandardOrderDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StandardOrderDetails_StandardProducts_StandardProductId",
                        column: x => x.StandardProductId,
                        principalTable: "StandardProducts",
                        principalColumn: "StandardProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StandardProductWarehouse",
                columns: table => new
                {
                    StandardProductItemId = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StandardProductWarehouse", x => x.StandardProductItemId);
                    table.ForeignKey(
                        name: "FK_StandardProductWarehouse_StandardProducts_StandardProductIte~",
                        column: x => x.StandardProductItemId,
                        principalTable: "StandardProducts",
                        principalColumn: "StandardProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "StandardProducts",
                columns: new[] { "StandardProductId", "Dimensions", "Name", "StandardProductCategoryId" },
                values: new object[] { 1, null, "Produkt", 0 });

            migrationBuilder.CreateIndex(
                name: "IX_Clients_SalesmanId",
                table: "Clients",
                column: "SalesmanId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomOrderDetails_CustomProductId",
                table: "CustomOrderDetails",
                column: "CustomProductId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomOrderDetails_OrderId",
                table: "CustomOrderDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomProducts_TechnologistId",
                table: "CustomProducts",
                column: "TechnologistId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ClientId",
                table: "Orders",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_SalesmanId",
                table: "Orders",
                column: "SalesmanId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_WarehousemanId",
                table: "Orders",
                column: "WarehousemanId");

            migrationBuilder.CreateIndex(
                name: "IX_StandardOrderDetails_OrderId",
                table: "StandardOrderDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_StandardOrderDetails_StandardProductId",
                table: "StandardOrderDetails",
                column: "StandardProductId");

            migrationBuilder.CreateIndex(
                name: "IX_StandardProducts_StandardProductCategoryId",
                table: "StandardProducts",
                column: "StandardProductCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomOrderDetails");

            migrationBuilder.DropTable(
                name: "MaterialWarehouse");

            migrationBuilder.DropTable(
                name: "StandardOrderDetails");

            migrationBuilder.DropTable(
                name: "StandardProductWarehouse");

            migrationBuilder.DropTable(
                name: "CustomProducts");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "StandardProducts");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "StandardProductCategories");

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Name" },
                values: new object[] { 1, "Produkt" });
        }
    }
}
