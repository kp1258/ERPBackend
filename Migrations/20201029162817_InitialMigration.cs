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
                    PhoneNumber = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
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
                    MaterialWarehouseItemId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Quantity = table.Column<int>(nullable: false),
                    MaterialId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialWarehouse", x => x.MaterialWarehouseItemId);
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
                    StandardProductCategoryId = table.Column<int>(nullable: false),
                    Status = table.Column<string>(nullable: false)
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
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    AddressId = table.Column<int>(nullable: false),
                    Status = table.Column<string>(nullable: false),
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
                    Status = table.Column<string>(nullable: false),
                    OrderDate = table.Column<DateTime>(nullable: false),
                    PreparationStartDate = table.Column<DateTime>(nullable: true),
                    PreparationCompletionDate = table.Column<DateTime>(nullable: true),
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
                name: "ProductWarehouse",
                columns: table => new
                {
                    ProductWarehouseItemId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Quantity = table.Column<int>(nullable: false),
                    StandardProductId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductWarehouse", x => x.ProductWarehouseItemId);
                    table.ForeignKey(
                        name: "FK_ProductWarehouse_StandardProducts_StandardProductId",
                        column: x => x.StandardProductId,
                        principalTable: "StandardProducts",
                        principalColumn: "StandardProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StandardOrderItemDetail",
                columns: table => new
                {
                    StandardOrderItemDetailId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    StandardOrderItemId = table.Column<int>(nullable: false),
                    StandardProductId = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Status = table.Column<string>(nullable: false),
                    MissingQuantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StandardOrderItemDetail", x => x.StandardOrderItemDetailId);
                    table.ForeignKey(
                        name: "FK_StandardOrderItemDetail_StandardProducts_StandardProductId",
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
                    RealizationStartDate = table.Column<DateTime>(nullable: true),
                    CompletionDate = table.Column<DateTime>(nullable: true),
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
                name: "CustomOrderItems",
                columns: table => new
                {
                    CustomOrderItemId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    OrderId = table.Column<int>(nullable: false),
                    CustomProductId = table.Column<int>(nullable: false),
                    Status = table.Column<string>(nullable: false),
                    ProductionManagerId = table.Column<int>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    OrderDate = table.Column<DateTime>(nullable: false),
                    ProductionStartDate = table.Column<DateTime>(nullable: true),
                    CompletionDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomOrderItems", x => x.CustomOrderItemId);
                    table.ForeignKey(
                        name: "FK_CustomOrderItems_CustomProducts_CustomProductId",
                        column: x => x.CustomProductId,
                        principalTable: "CustomProducts",
                        principalColumn: "CustomProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomOrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StandardOrderItems",
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
                    table.PrimaryKey("PK_StandardOrderItems", x => x.StandardOrderItemId);
                    table.ForeignKey(
                        name: "FK_StandardOrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StandardOrderItems_StandardProducts_StandardProductId",
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
                columns: new[] { "CustomProductId", "Description", "Name", "OrderDate", "PreparationCompletionDate", "PreparationStartDate", "Status", "TechnologistId" },
                values: new object[] { 4, "Opis", "Produkt specjalny 4", new DateTime(2020, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Ordered", null });

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
                columns: new[] { "UserId", "Email", "FirstName", "LastName", "Login", "Password", "PhoneNumber", "Role", "Status" },
                values: new object[,]
                {
                    { 4, "agata_k@email.com", "Agata", "Krzeszowska", "agata_k", "password", "685234054", "Technologist", "Active" },
                    { 1, "jan_k@email.com", "Jan", "Kowalski", "jan_k", "password", "607934182", "Administrator", "Active" },
                    { 2, "anna_n@email.com", "Anna", "Nowak", "anna_n", "password", "709856234", "Salesman", "Active" },
                    { 3, "andrzej_m@email.com", "Andrzej", "Malinowski", "andrzej_m", "password", "679234374", "ProductionManager", "Active" },
                    { 5, "edward_r@email.com", "Edward", "Rak", "edward_r", "password", "978345278", "Warehouseman", "Active" }
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "ClientId", "AddressId", "CompanyName", "Email", "FirstName", "LastName", "PhoneNumber", "SalesmanId", "Status" },
                values: new object[,]
                {
                    { 1, 1, "Zakłady mięsne Stokłosa", "zm_stokolosa@mail.com", "Adam", "Markowski", "678234765", 2, "Active" },
                    { 2, 2, "Zakłady mięsne Solańscy", "zm_solanscy@mail.com", "Edward", "Solański", "978456723", 2, "Active" },
                    { 3, 3, "ZM Turowski", "zm_turowski@mail.com", "Piotr", "Turowski", "867544765", 2, "Active" }
                });

            migrationBuilder.InsertData(
                table: "CustomProducts",
                columns: new[] { "CustomProductId", "Description", "Name", "OrderDate", "PreparationCompletionDate", "PreparationStartDate", "Status", "TechnologistId" },
                values: new object[,]
                {
                    { 1, "Opis", "Produkt specjalny 1", new DateTime(2020, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Prepared", 4 },
                    { 2, "Opis", "Produkt specjalny 2", new DateTime(2020, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Prepared", 4 },
                    { 3, "Opis", "Produkt specjalny 3", new DateTime(2020, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Prepared", 4 }
                });

            migrationBuilder.InsertData(
                table: "MaterialWarehouse",
                columns: new[] { "MaterialWarehouseItemId", "MaterialId", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, 30 },
                    { 2, 2, 50 },
                    { 3, 3, 10 },
                    { 4, 4, 30 }
                });

            migrationBuilder.InsertData(
                table: "StandardProducts",
                columns: new[] { "StandardProductId", "Dimensions", "Name", "StandardProductCategoryId", "Status" },
                values: new object[,]
                {
                    { 1, "100x100", "Produkt 1", 1, "InProduction" },
                    { 2, "100x100", "Produkt 2", 2, "InProduction" },
                    { 3, "100x100", "Produkt 3", 3, "InProduction" },
                    { 4, "100x100", "Produkt 4", 4, "InProduction" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "ClientId", "CompletionDate", "PlacingDate", "RealizationStartDate", "SalesmanId", "Status", "Type", "WarehousemanId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2020, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Completed", "Standard", 5 },
                    { 4, 1, new DateTime(2020, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Completed", "Custom", 5 },
                    { 2, 2, null, new DateTime(2020, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, "Placed", "Standard", null },
                    { 5, 2, null, new DateTime(2020, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "InRealization", "Standard", 5 },
                    { 3, 3, null, new DateTime(2020, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, "Placed", "Custom", null }
                });

            migrationBuilder.InsertData(
                table: "ProductWarehouse",
                columns: new[] { "ProductWarehouseItemId", "Quantity", "StandardProductId" },
                values: new object[,]
                {
                    { 1, 40, 1 },
                    { 2, 50, 2 },
                    { 3, 10, 3 },
                    { 4, 25, 4 }
                });

            migrationBuilder.InsertData(
                table: "CustomOrderItems",
                columns: new[] { "CustomOrderItemId", "CompletionDate", "CustomProductId", "OrderDate", "OrderId", "ProductionManagerId", "ProductionStartDate", "Quantity", "Status" },
                values: new object[,]
                {
                    { 2, new DateTime(2020, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2020, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 3, new DateTime(2020, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Completed" },
                    { 3, new DateTime(2020, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2020, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 3, new DateTime(2020, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 15, "Completed" },
                    { 4, new DateTime(2020, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, new DateTime(2020, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 3, new DateTime(2020, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, "Completed" },
                    { 1, null, 4, new DateTime(2020, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, null, null, 10, "Ordered" }
                });

            migrationBuilder.InsertData(
                table: "StandardOrderItems",
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
                name: "IX_CustomOrderItems_CustomProductId",
                table: "CustomOrderItems",
                column: "CustomProductId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomOrderItems_OrderId",
                table: "CustomOrderItems",
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
                name: "IX_ProductWarehouse_StandardProductId",
                table: "ProductWarehouse",
                column: "StandardProductId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StandardOrderItemDetail_StandardProductId",
                table: "StandardOrderItemDetail",
                column: "StandardProductId");

            migrationBuilder.CreateIndex(
                name: "IX_StandardOrderItems_OrderId",
                table: "StandardOrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_StandardOrderItems_StandardProductId",
                table: "StandardOrderItems",
                column: "StandardProductId");

            migrationBuilder.CreateIndex(
                name: "IX_StandardProducts_StandardProductCategoryId",
                table: "StandardProducts",
                column: "StandardProductCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomOrderItems");

            migrationBuilder.DropTable(
                name: "MaterialWarehouse");

            migrationBuilder.DropTable(
                name: "ProductWarehouse");

            migrationBuilder.DropTable(
                name: "StandardOrderItemDetail");

            migrationBuilder.DropTable(
                name: "StandardOrderItems");

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
