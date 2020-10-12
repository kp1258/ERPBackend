using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace ERPBackend.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    AddressId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Street = table.Column<string>(nullable: false),
                    PostalCode = table.Column<string>(nullable: false),
                    City = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.AddressId);
                });

            migrationBuilder.CreateTable(
                name: "Materials",
                columns: table => new
                {
                    MaterialId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materials", x => x.MaterialId);
                });

            migrationBuilder.CreateTable(
                name: "StandardProductCategories",
                columns: table => new
                {
                    StandardProductCategoryId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StandardProductCategories", x => x.StandardProductCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Login = table.Column<string>(maxLength: 20, nullable: false),
                    Password = table.Column<string>(maxLength: 20, nullable: false),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    Role = table.Column<string>(nullable: false),
                    Status = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "MaterialWarehouse",
                columns: table => new
                {
                    MaterialItemId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Quantity = table.Column<int>(nullable: false),
                    MaterialId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialWarehouse", x => x.MaterialItemId);
                    table.ForeignKey(
                        name: "FK_MaterialWarehouse_Materials_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Materials",
                        principalColumn: "MaterialId",
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
                name: "Clients",
                columns: table => new
                {
                    ClientId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    CompanyName = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: false),
                    EMail = table.Column<string>(nullable: true),
                    AddressId = table.Column<int>(nullable: false),
                    SalesmanId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.ClientId);
                    table.ForeignKey(
                        name: "FK_Clients_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Cascade);
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
                    TechnologistId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomProducts", x => x.CustomProductId);
                    table.ForeignKey(
                        name: "FK_CustomProducts_Users_TechnologistId",
                        column: x => x.TechnologistId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StandardProductWarehouse",
                columns: table => new
                {
                    StandardProductItemId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Quantity = table.Column<int>(nullable: false),
                    StandardProductId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StandardProductWarehouse", x => x.StandardProductItemId);
                    table.ForeignKey(
                        name: "FK_StandardProductWarehouse_StandardProducts_StandardProductId",
                        column: x => x.StandardProductId,
                        principalTable: "StandardProducts",
                        principalColumn: "StandardProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    PlacingDate = table.Column<DateTime>(nullable: false),
                    FulfillmentDate = table.Column<DateTime>(nullable: true),
                    Status = table.Column<string>(nullable: false),
                    Type = table.Column<string>(nullable: false),
                    ClientId = table.Column<int>(nullable: false),
                    SalesmanId = table.Column<int>(nullable: false),
                    WarehousemanId = table.Column<int>(nullable: true)
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
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CustomOrderDetails",
                columns: table => new
                {
                    CustomOrderItemId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    OrderId = table.Column<int>(nullable: false),
                    CustomProductId = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomOrderDetails", x => x.CustomOrderItemId);
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
                    StandardOrderItemId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    OrderId = table.Column<int>(nullable: false),
                    StandardProductId = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StandardOrderDetails", x => x.StandardOrderItemId);
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

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "AddressId", "City", "PostalCode", "Street" },
                values: new object[,]
                {
                    { 1, "Słubice", "69-100", "ul.Witosa 10" },
                    { 2, "Poznań", "61-222", "ul.Nowodworska 80" },
                    { 3, "Gorzów Wielkopolski", "66-400", "al. Wojska Polskiego 33" }
                });

            migrationBuilder.InsertData(
                table: "CustomProducts",
                columns: new[] { "CustomProductId", "Description", "Name", "TechnologistId" },
                values: new object[] { 4, "Opis", "Produkt specjalny 4", null });

            migrationBuilder.InsertData(
                table: "Materials",
                columns: new[] { "MaterialId", "Name" },
                values: new object[,]
                {
                    { 1, "Materiał 1" },
                    { 2, "Materiał 2" },
                    { 3, "Materiał 3" },
                    { 4, "Materiał 4" }
                });

            migrationBuilder.InsertData(
                table: "StandardProductCategories",
                columns: new[] { "StandardProductCategoryId", "Name" },
                values: new object[,]
                {
                    { 4, "Inne" },
                    { 3, "Szarpak" },
                    { 1, "Nóż" },
                    { 2, "Sito" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "FirstName", "LastName", "Login", "Password", "Role", "Status" },
                values: new object[,]
                {
                    { 4, "Agata", "Krzeszowska", "agata_k", "password", "Technologist", "Active" },
                    { 1, "Jan", "Kowalski", "jan_k", "password", "Administrator", "Active" },
                    { 2, "Anna", "Nowak", "anna_n", "password", "Salesman", "Active" },
                    { 3, "Andrzej", "Malinowski", "andrzej_m", "password", "ProductionManager", "Active" },
                    { 5, "Edward", "Rak", "edward_r", "password", "Warehouseman", "Active" }
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "ClientId", "AddressId", "CompanyName", "EMail", "FirstName", "LastName", "PhoneNumber", "SalesmanId" },
                values: new object[,]
                {
                    { 1, 1, "Zakłady mięsne Stokłosa", "zm_stokolosa@mail.com", "Adam", "Markowski", "678234765", 2 },
                    { 2, 2, "Zakłady mięsne Solańscy", "zm_solanscy@mail.com", "Edward", "Solański", "978456723", 2 },
                    { 3, 3, "ZM Turowski", "zm_turowski@mail.com", "Piotr", "Turowski", "867544765", 2 }
                });

            migrationBuilder.InsertData(
                table: "CustomProducts",
                columns: new[] { "CustomProductId", "Description", "Name", "TechnologistId" },
                values: new object[,]
                {
                    { 1, "Opis", "Produkt specjalny 1", 4 },
                    { 2, "Opis", "Produkt specjalny 2", 4 },
                    { 3, "Opis", "Produkt specjalny 3", 4 }
                });

            migrationBuilder.InsertData(
                table: "MaterialWarehouse",
                columns: new[] { "MaterialItemId", "MaterialId", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, 30 },
                    { 2, 2, 50 },
                    { 3, 3, 10 },
                    { 4, 4, 30 }
                });

            migrationBuilder.InsertData(
                table: "StandardProducts",
                columns: new[] { "StandardProductId", "Dimensions", "Name", "StandardProductCategoryId" },
                values: new object[,]
                {
                    { 1, "100x100", "Produkt 1", 1 },
                    { 2, "100x100", "Produkt 2", 2 },
                    { 3, "100x100", "Produkt 3", 3 },
                    { 4, "100x100", "Produkt 4", 4 }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "ClientId", "FulfillmentDate", "PlacingDate", "SalesmanId", "Status", "Type", "WarehousemanId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2020, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Completed", "Standard", 5 },
                    { 4, 1, new DateTime(2020, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Completed", "Custom", 5 },
                    { 2, 2, null, new DateTime(2020, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Placed", "Standard", null },
                    { 5, 2, null, new DateTime(2020, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "InProgress", "Standard", 5 },
                    { 3, 3, null, new DateTime(2020, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Placed", "Custom", null }
                });

            migrationBuilder.InsertData(
                table: "StandardProductWarehouse",
                columns: new[] { "StandardProductItemId", "Quantity", "StandardProductId" },
                values: new object[,]
                {
                    { 1, 40, 1 },
                    { 2, 50, 2 },
                    { 3, 10, 3 },
                    { 4, 25, 4 }
                });

            migrationBuilder.InsertData(
                table: "CustomOrderDetails",
                columns: new[] { "CustomOrderItemId", "CustomProductId", "OrderId", "Quantity" },
                values: new object[,]
                {
                    { 2, 1, 4, 5 },
                    { 3, 2, 4, 15 },
                    { 4, 3, 4, 9 },
                    { 1, 4, 3, 10 }
                });

            migrationBuilder.InsertData(
                table: "StandardOrderDetails",
                columns: new[] { "StandardOrderItemId", "OrderId", "Quantity", "StandardProductId" },
                values: new object[,]
                {
                    { 1, 1, 10, 1 },
                    { 2, 1, 10, 2 },
                    { 3, 1, 10, 3 },
                    { 4, 2, 10, 3 },
                    { 5, 2, 10, 4 },
                    { 6, 5, 10, 1 },
                    { 7, 5, 10, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clients_AddressId",
                table: "Clients",
                column: "AddressId");

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
                name: "IX_MaterialWarehouse_MaterialId",
                table: "MaterialWarehouse",
                column: "MaterialId",
                unique: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_StandardProductWarehouse_StandardProductId",
                table: "StandardProductWarehouse",
                column: "StandardProductId",
                unique: true);
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
                name: "Materials");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "StandardProducts");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "StandardProductCategories");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
