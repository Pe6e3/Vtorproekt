using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vtorproekt.Migrations
{
    /// <inheritdoc />
    public partial class RemovesomepropertiesfromTaxmodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Limit1",
                table: "Taxes");

            migrationBuilder.DropColumn(
                name: "Limit2",
                table: "Taxes");

            migrationBuilder.DropColumn(
                name: "Limit3",
                table: "Taxes");

            migrationBuilder.DropColumn(
                name: "Multi1",
                table: "Taxes");

            migrationBuilder.DropColumn(
                name: "Multi2",
                table: "Taxes");

            migrationBuilder.DropColumn(
                name: "Multi3",
                table: "Taxes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Limit1",
                table: "Taxes",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Limit2",
                table: "Taxes",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Limit3",
                table: "Taxes",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Multi1",
                table: "Taxes",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Multi2",
                table: "Taxes",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Multi3",
                table: "Taxes",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
