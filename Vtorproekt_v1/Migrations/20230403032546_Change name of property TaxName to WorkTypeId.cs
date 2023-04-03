using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vtorproekt.Migrations
{
    /// <inheritdoc />
    public partial class ChangenameofpropertyTaxNametoWorkTypeId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TaxName",
                table: "Taxes");

            migrationBuilder.AddColumn<int>(
                name: "WorkTypeId",
                table: "Taxes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WorkTypeId",
                table: "Taxes");

            migrationBuilder.AddColumn<string>(
                name: "TaxName",
                table: "Taxes",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
