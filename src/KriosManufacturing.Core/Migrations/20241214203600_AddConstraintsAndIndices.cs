using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KriosManufacturing.Core.Migrations
{
    /// <inheritdoc />
    public partial class AddConstraintsAndIndices : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Unit",
                table: "Locations",
                type: "character varying(16)",
                maxLength: 16,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Cell",
                table: "Locations",
                type: "character varying(16)",
                maxLength: 16,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "Sku",
                table: "Items",
                type: "character varying(64)",
                maxLength: 64,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Lots_LotNumber",
                table: "Lots",
                column: "LotNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Locations_Unit_Cell",
                table: "Locations",
                columns: new[] { "Unit", "Cell" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Items_Sku",
                table: "Items",
                column: "Sku",
                unique: true);

            migrationBuilder.AddCheckConstraint(
                name: "CK_Quantity",
                table: "InventoryRecords",
                sql: "\"Quantity\" > 0");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Lots_LotNumber",
                table: "Lots");

            migrationBuilder.DropIndex(
                name: "IX_Locations_Unit_Cell",
                table: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_Items_Sku",
                table: "Items");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Quantity",
                table: "InventoryRecords");

            migrationBuilder.DropColumn(
                name: "Sku",
                table: "Items");

            migrationBuilder.AlterColumn<string>(
                name: "Unit",
                table: "Locations",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(16)",
                oldMaxLength: 16);

            migrationBuilder.AlterColumn<string>(
                name: "Cell",
                table: "Locations",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(16)",
                oldMaxLength: 16);
        }
    }
}
