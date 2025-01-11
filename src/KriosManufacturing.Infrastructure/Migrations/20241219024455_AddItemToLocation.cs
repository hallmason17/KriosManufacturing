﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KriosManufacturing.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddItemToLocation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ItemId",
                table: "Locations",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Locations_ItemId",
                table: "Locations",
                column: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Items_ItemId",
                table: "Locations",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Items_ItemId",
                table: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_Locations_ItemId",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "Locations");
        }
    }
}
