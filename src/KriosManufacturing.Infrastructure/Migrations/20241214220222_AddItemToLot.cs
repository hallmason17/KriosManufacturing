using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KriosManufacturing.Infrastructure.Migrations;

/// <inheritdoc />
public partial class AddItemToLot : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AddColumn<long>(
            name: "ItemId",
            table: "Lots",
            type: "bigint",
            nullable: false,
            defaultValue: 0L);

        migrationBuilder.CreateIndex(
            name: "IX_Lots_ItemId",
            table: "Lots",
            column: "ItemId");

        migrationBuilder.AddForeignKey(
            name: "FK_Lots_Items_ItemId",
            table: "Lots",
            column: "ItemId",
            principalTable: "Items",
            principalColumn: "Id",
            onDelete: ReferentialAction.Cascade);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_Lots_Items_ItemId",
            table: "Lots");

        migrationBuilder.DropIndex(
            name: "IX_Lots_ItemId",
            table: "Lots");

        migrationBuilder.DropColumn(
            name: "ItemId",
            table: "Lots");
    }
}