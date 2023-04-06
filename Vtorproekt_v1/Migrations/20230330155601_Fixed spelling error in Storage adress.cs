using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vtorproekt.Migrations
{
    /// <inheritdoc />
    public partial class FixedspellingerrorinStorageadress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StorageAdress",
                table: "Storages",
                newName: "StorageAdress");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StorageAdress",
                table: "Storages",
                newName: "StorageAdress");
        }
    }
}
