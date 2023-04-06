using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vtorproekt.Migrations
{
    /// <inheritdoc />
    public partial class AddpropertyMaterialIdtoTaxmodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MaterialId",
                table: "Taxes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Taxes_WorkTypeId",
                table: "Taxes",
                column: "WorkTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Taxes_WorkTypes_WorkTypeId",
                table: "Taxes",
                column: "WorkTypeId",
                principalTable: "WorkTypes",
                principalColumn: "WorkTypeId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Taxes_WorkTypes_WorkTypeId",
                table: "Taxes");

            migrationBuilder.DropIndex(
                name: "IX_Taxes_WorkTypeId",
                table: "Taxes");

            migrationBuilder.DropColumn(
                name: "MaterialId",
                table: "Taxes");
        }
    }
}
