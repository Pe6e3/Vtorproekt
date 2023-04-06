using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vtorproekt.Migrations
{
    /// <inheritdoc />
    public partial class AddpropertyMaterialIdtoWorkTypemodelDeletethisfromTaxmodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaterialId",
                table: "Taxes");

            migrationBuilder.AddColumn<int>(
                name: "MaterialId",
                table: "WorkTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaterialId",
                table: "WorkTypes");

            migrationBuilder.AddColumn<int>(
                name: "MaterialId",
                table: "Taxes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
