using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vtorproekt.Migrations
{
    /// <inheritdoc />
    public partial class propertyMaterialIdinTaxmodel : Migration
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
                name: "IX_WorkTypes_MaterialId",
                table: "WorkTypes",
                column: "MaterialId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkTypes_Materials_MaterialId",
                table: "WorkTypes",
                column: "MaterialId",
                principalTable: "Materials",
                principalColumn: "MaterialId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkTypes_Materials_MaterialId",
                table: "WorkTypes");

            migrationBuilder.DropIndex(
                name: "IX_WorkTypes_MaterialId",
                table: "WorkTypes");

            migrationBuilder.DropColumn(
                name: "MaterialId",
                table: "Taxes");
        }
    }
}
