using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERPBackend.Migrations
{
    public partial class FinalMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CustomOrderItems",
                keyColumn: "CustomOrderItemId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CustomOrderItems",
                keyColumn: "CustomOrderItemId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CustomOrderItems",
                keyColumn: "CustomOrderItemId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CustomOrderItems",
                keyColumn: "CustomOrderItemId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "MaterialWarehouse",
                keyColumn: "MaterialWarehouseItemId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MaterialWarehouse",
                keyColumn: "MaterialWarehouseItemId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MaterialWarehouse",
                keyColumn: "MaterialWarehouseItemId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MaterialWarehouse",
                keyColumn: "MaterialWarehouseItemId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ProductWarehouse",
                keyColumn: "ProductWarehouseItemId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProductWarehouse",
                keyColumn: "ProductWarehouseItemId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProductWarehouse",
                keyColumn: "ProductWarehouseItemId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ProductWarehouse",
                keyColumn: "ProductWarehouseItemId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "StandardOrderItems",
                keyColumn: "StandardOrderItemId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "StandardOrderItems",
                keyColumn: "StandardOrderItemId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "StandardOrderItems",
                keyColumn: "StandardOrderItemId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "StandardOrderItems",
                keyColumn: "StandardOrderItemId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "StandardOrderItems",
                keyColumn: "StandardOrderItemId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "StandardOrderItems",
                keyColumn: "StandardOrderItemId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "StandardOrderItems",
                keyColumn: "StandardOrderItemId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "CustomProducts",
                keyColumn: "CustomProductId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CustomProducts",
                keyColumn: "CustomProductId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CustomProducts",
                keyColumn: "CustomProductId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CustomProducts",
                keyColumn: "CustomProductId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "MaterialId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "MaterialId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "MaterialId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "MaterialId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "StandardProducts",
                keyColumn: "StandardProductId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "StandardProducts",
                keyColumn: "StandardProductId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "StandardProducts",
                keyColumn: "StandardProductId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "StandardProducts",
                keyColumn: "StandardProductId",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$U6Us.rSgKNQOdBGsOk/bGOc4Oa6bCczKrpq1N.N/JdmVNMRj3Yvse");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$f7ORw/Yv7RlriQ8749XzsexBdfDkA1EiK6Jv/yddlipQVllyCxDKG");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$fxEnaNdioUn74.61AIFQy.C.jlWAp6XapPWfN.eeuDuPDhOOWMp8C");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                column: "Password",
                value: "$2a$11$NfMIvAqaxAGG2DupmOQSFOoANndQiEy.9j7vD4ZZYzRD5IPNuH14S");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                column: "Password",
                value: "$2a$11$cyzeXRjxn9ZAI5BWd7HJVuUnYcIk6M/H0O3d.46yIc4mr6lQb3cna");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CustomProducts",
                columns: new[] { "CustomProductId", "Name", "OrderDate", "OrderDescription", "PreparationCompletionDate", "PreparationStartDate", "SolutionDescription", "Status", "TechnologistId" },
                values: new object[,]
                {
                    { 1, "Produkt specjalny 1", new DateTime(2020, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Opis zamówienia", new DateTime(2020, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Prepared", 4 },
                    { 2, "Produkt specjalny 2", new DateTime(2020, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Opis zamówienia", new DateTime(2020, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Prepared", 4 },
                    { 3, "Produkt specjalny 3", new DateTime(2020, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Opis zamówienia", new DateTime(2020, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Prepared", 4 },
                    { 4, "Produkt specjalny 4", new DateTime(2020, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Opis zamówienia", null, null, null, "Ordered", null }
                });

            migrationBuilder.InsertData(
                table: "Materials",
                columns: new[] { "MaterialId", "Name", "Unit" },
                values: new object[,]
                {
                    { 1, "Materiał 1", "kilogramy" },
                    { 2, "Materiał 2", "kilogramy" },
                    { 3, "Materiał 3", "kilogramy" },
                    { 4, "Materiał 4", "kilogramy" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "ClientId", "CompletionDate", "PlacingDate", "RealizationStartDate", "SalesmanId", "Status", "Type", "WarehousemanId" },
                values: new object[,]
                {
                    { 5, 2, null, new DateTime(2020, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "InRealization", "Standard", 5 },
                    { 4, 1, new DateTime(2020, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Completed", "Custom", 5 },
                    { 3, 3, null, new DateTime(2020, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, "Placed", "Custom", null },
                    { 2, 2, null, new DateTime(2020, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, "Placed", "Standard", null },
                    { 1, 1, new DateTime(2020, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Completed", "Standard", 5 }
                });

            migrationBuilder.InsertData(
                table: "StandardProducts",
                columns: new[] { "StandardProductId", "BlobName", "Dimensions", "ImageName", "ImagePath", "Name", "StandardProductCategoryId", "Status" },
                values: new object[,]
                {
                    { 1, null, "100x100", null, null, "Produkt 1", 1, "Produced" },
                    { 2, null, "100x100", null, null, "Produkt 2", 2, "Produced" },
                    { 3, null, "100x100", null, null, "Produkt 3", 3, "Produced" },
                    { 4, null, "100x100", null, null, "Produkt 4", 4, "Produced" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$HIxaERy8ZGrEEGRnUKTRyu8N7pCJVahbRBw.UNX3GWldwB4Dfmtie");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$fkUqct2pB4oJjkQVdbLM0eSwq2yb3KKLrDtG.rn1NAoTvDTBnponW");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$tapGOoNUWrYO9pfwY3tTgODwqKw84qdR90OFEjqAa9EUhrHh08KsS");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                column: "Password",
                value: "$2a$11$dtXeuV.wySZJKLNEKp93zOo2qmMe1JGeqCdZ9BQgW9bpvE6qkp.7u");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                column: "Password",
                value: "$2a$11$dVY.L7cHk.kj/KSX/Af4X.mKnhfIjiYnkDwmN3NDutqv5Mwzxupdu");

            migrationBuilder.InsertData(
                table: "CustomOrderItems",
                columns: new[] { "CustomOrderItemId", "CompletionDate", "CustomProductId", "OrderDate", "OrderId", "ProductionManagerId", "ProductionStartDate", "Quantity", "Status" },
                values: new object[,]
                {
                    { 1, null, 4, new DateTime(2020, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, null, null, 10, "Ordered" },
                    { 2, new DateTime(2020, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2020, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 3, new DateTime(2020, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Completed" },
                    { 3, new DateTime(2020, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2020, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 3, new DateTime(2020, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 15, "Completed" },
                    { 4, new DateTime(2020, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, new DateTime(2020, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 3, new DateTime(2020, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, "Completed" }
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
                table: "ProductWarehouse",
                columns: new[] { "ProductWarehouseItemId", "Quantity", "StandardProductId" },
                values: new object[,]
                {
                    { 1, 40, 1 },
                    { 4, 25, 4 },
                    { 2, 50, 2 },
                    { 3, 10, 3 }
                });

            migrationBuilder.InsertData(
                table: "StandardOrderItems",
                columns: new[] { "StandardOrderItemId", "OrderId", "Quantity", "StandardProductId" },
                values: new object[,]
                {
                    { 4, 2, 10, 3 },
                    { 3, 1, 10, 3 },
                    { 1, 1, 10, 1 },
                    { 2, 1, 10, 2 },
                    { 6, 5, 10, 1 },
                    { 7, 5, 10, 2 },
                    { 5, 2, 10, 4 }
                });
        }
    }
}
