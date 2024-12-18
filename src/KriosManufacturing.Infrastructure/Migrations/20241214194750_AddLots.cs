using Microsoft.EntityFrameworkCore.Migrations;

using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace KriosManufacturing.Infrastructure.Migrations;

/// <inheritdoc />
public partial class AddLots : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AlterColumn<string>(
            name: "Name",
            table: "Items",
            type: "character varying(128)",
            maxLength: 128,
            nullable: false,
            oldClrType: typeof(string),
            oldType: "text");

        migrationBuilder.AlterColumn<string>(
            name: "Description",
            table: "Items",
            type: "character varying(256)",
            maxLength: 256,
            nullable: true,
            oldClrType: typeof(string),
            oldType: "text",
            oldNullable: true);

        migrationBuilder.AlterColumn<int>(
            name: "Quantity",
            table: "InventoryRecords",
            type: "integer",
            nullable: false,
            oldClrType: typeof(long),
            oldType: "bigint");

        migrationBuilder.AddColumn<long>(
            name: "LotId",
            table: "InventoryRecords",
            type: "bigint",
            nullable: false,
            defaultValue: 0L);

        migrationBuilder.CreateTable(
            name: "Lots",
            columns: table => new
            {
                Id = table.Column<long>(type: "bigint", nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                LotNumber = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                ExpirationDate = table.Column<DateOnly>(type: "date", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Lots", x => x.Id);
            });

        migrationBuilder.CreateIndex(
            name: "IX_InventoryRecords_LotId",
            table: "InventoryRecords",
            column: "LotId");

        migrationBuilder.AddForeignKey(
            name: "FK_InventoryRecords_Lots_LotId",
            table: "InventoryRecords",
            column: "LotId",
            principalTable: "Lots",
            principalColumn: "Id",
            onDelete: ReferentialAction.Cascade);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_InventoryRecords_Lots_LotId",
            table: "InventoryRecords");

        migrationBuilder.DropTable(
            name: "Lots");

        migrationBuilder.DropIndex(
            name: "IX_InventoryRecords_LotId",
            table: "InventoryRecords");

        migrationBuilder.DropColumn(
            name: "LotId",
            table: "InventoryRecords");

        migrationBuilder.AlterColumn<string>(
            name: "Name",
            table: "Items",
            type: "text",
            nullable: false,
            oldClrType: typeof(string),
            oldType: "character varying(128)",
            oldMaxLength: 128);

        migrationBuilder.AlterColumn<string>(
            name: "Description",
            table: "Items",
            type: "text",
            nullable: true,
            oldClrType: typeof(string),
            oldType: "character varying(256)",
            oldMaxLength: 256,
            oldNullable: true);

        migrationBuilder.AlterColumn<long>(
            name: "Quantity",
            table: "InventoryRecords",
            type: "bigint",
            nullable: false,
            oldClrType: typeof(int),
            oldType: "integer");
    }
}