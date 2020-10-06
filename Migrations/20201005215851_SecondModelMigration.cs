using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace ERPBackend.Migrations
{
    public partial class SecondModelMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MaterialWarehouse_Materials_MaterialItemId",
                table: "MaterialWarehouse");

            migrationBuilder.DropForeignKey(
                name: "FK_StandardProductWarehouse_StandardProducts_StandardProductIte~",
                table: "StandardProductWarehouse");

            migrationBuilder.AlterColumn<int>(
                name: "StandardProductItemId",
                table: "StandardProductWarehouse",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "StandardProductId",
                table: "StandardProductWarehouse",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "MaterialItemId",
                table: "MaterialWarehouse",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "MaterialId",
                table: "MaterialWarehouse",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_StandardProductWarehouse_StandardProductId",
                table: "StandardProductWarehouse",
                column: "StandardProductId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MaterialWarehouse_MaterialId",
                table: "MaterialWarehouse",
                column: "MaterialId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialWarehouse_Materials_MaterialId",
                table: "MaterialWarehouse",
                column: "MaterialId",
                principalTable: "Materials",
                principalColumn: "MaterialId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StandardProductWarehouse_StandardProducts_StandardProductId",
                table: "StandardProductWarehouse",
                column: "StandardProductId",
                principalTable: "StandardProducts",
                principalColumn: "StandardProductId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MaterialWarehouse_Materials_MaterialId",
                table: "MaterialWarehouse");

            migrationBuilder.DropForeignKey(
                name: "FK_StandardProductWarehouse_StandardProducts_StandardProductId",
                table: "StandardProductWarehouse");

            migrationBuilder.DropIndex(
                name: "IX_StandardProductWarehouse_StandardProductId",
                table: "StandardProductWarehouse");

            migrationBuilder.DropIndex(
                name: "IX_MaterialWarehouse_MaterialId",
                table: "MaterialWarehouse");

            migrationBuilder.DropColumn(
                name: "StandardProductId",
                table: "StandardProductWarehouse");

            migrationBuilder.DropColumn(
                name: "MaterialId",
                table: "MaterialWarehouse");

            migrationBuilder.AlterColumn<int>(
                name: "StandardProductItemId",
                table: "StandardProductWarehouse",
                type: "int",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<int>(
                name: "MaterialItemId",
                table: "MaterialWarehouse",
                type: "int",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialWarehouse_Materials_MaterialItemId",
                table: "MaterialWarehouse",
                column: "MaterialItemId",
                principalTable: "Materials",
                principalColumn: "MaterialId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StandardProductWarehouse_StandardProducts_StandardProductIte~",
                table: "StandardProductWarehouse",
                column: "StandardProductItemId",
                principalTable: "StandardProducts",
                principalColumn: "StandardProductId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
