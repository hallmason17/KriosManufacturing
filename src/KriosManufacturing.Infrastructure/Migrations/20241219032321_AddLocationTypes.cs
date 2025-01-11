using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KriosManufacturing.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddLocationTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LocationType",
                table: "Locations",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LocationType",
                table: "Locations");
        }
    }
}
