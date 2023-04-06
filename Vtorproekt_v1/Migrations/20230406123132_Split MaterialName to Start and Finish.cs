using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vtorproekt.Migrations
{
    /// <inheritdoc />
    public partial class SplitMaterialNametoStartandFinish : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MaterialNameFinish",
                table: "Materials",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Taxes_MaterialId",
                table: "Taxes",
                column: "MaterialId");

            migrationBuilder.AddForeignKey(
                name: "FK_Taxes_Materials_MaterialId",
                table: "Taxes",
                column: "MaterialId",
                principalTable: "Materials",
                principalColumn: "MaterialId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Taxes_Materials_MaterialId",
                table: "Taxes");

            migrationBuilder.DropIndex(
                name: "IX_Taxes_MaterialId",
                table: "Taxes");

            migrationBuilder.DropColumn(
                name: "MaterialNameFinish",
                table: "Materials");
        }
    }
}
