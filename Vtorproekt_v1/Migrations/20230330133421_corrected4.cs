using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vtorproekt.Migrations
{
    /// <inheritdoc />
    public partial class corrected4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "Materials",
                columns: table => new
                {
                    MaterialId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaterialName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materials", x => x.MaterialId);
                });

            migrationBuilder.CreateTable(
                name: "Storages",
                columns: table => new
                {
                    StorageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StorageArdess = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Storages", x => x.StorageId);
                });

            migrationBuilder.CreateTable(
                name: "Taxes",
                columns: table => new
                {
                    TaxId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateTax = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TaxValue = table.Column<double>(type: "float", nullable: false),
                    Limit1 = table.Column<double>(type: "float", nullable: false),
                    Limit2 = table.Column<double>(type: "float", nullable: false),
                    Limit3 = table.Column<double>(type: "float", nullable: false),
                    Multi1 = table.Column<double>(type: "float", nullable: false),
                    Multi2 = table.Column<double>(type: "float", nullable: false),
                    Multi3 = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Taxes", x => x.TaxId);
                });

            migrationBuilder.CreateTable(
                name: "WorkTypes",
                columns: table => new
                {
                    WorkTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkTypes", x => x.WorkTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Bales",
                columns: table => new
                {
                    BaleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: true),
                    MaterialId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bales", x => x.BaleId);
                    table.ForeignKey(
                        name: "FK_Bales_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId");
                    table.ForeignKey(
                        name: "FK_Bales_Materials_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Materials",
                        principalColumn: "MaterialId");
                });

            migrationBuilder.CreateTable(
                name: "Productions",
                columns: table => new
                {
                    ProductionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkTypeId = table.Column<int>(type: "int", nullable: false),
                    BaleId = table.Column<int>(type: "int", nullable: false),
                    MaterialId = table.Column<int>(type: "int", nullable: true),
                    Weight = table.Column<double>(type: "float", nullable: false),
                    StorageId = table.Column<int>(type: "int", nullable: false),
                    ProduceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TaxId = table.Column<int>(type: "int", nullable: false),
                    Tax = table.Column<int>(type: "int", nullable: true),
                    Employee = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productions", x => x.ProductionId);
                    table.ForeignKey(
                        name: "FK_Productions_Employees_Employee",
                        column: x => x.Employee,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId");
                    table.ForeignKey(
                        name: "FK_Productions_Materials_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Materials",
                        principalColumn: "MaterialId");
                    table.ForeignKey(
                        name: "FK_Productions_Storages_StorageId",
                        column: x => x.StorageId,
                        principalTable: "Storages",
                        principalColumn: "StorageId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Productions_Taxes_Tax",
                        column: x => x.Tax,
                        principalTable: "Taxes",
                        principalColumn: "TaxId");
                    table.ForeignKey(
                        name: "FK_Productions_WorkTypes_WorkTypeId",
                        column: x => x.WorkTypeId,
                        principalTable: "WorkTypes",
                        principalColumn: "WorkTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bales_EmployeeId",
                table: "Bales",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Bales_MaterialId",
                table: "Bales",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_Productions_Employee",
                table: "Productions",
                column: "Employee");

            migrationBuilder.CreateIndex(
                name: "IX_Productions_MaterialId",
                table: "Productions",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_Productions_StorageId",
                table: "Productions",
                column: "StorageId");

            migrationBuilder.CreateIndex(
                name: "IX_Productions_Tax",
                table: "Productions",
                column: "Tax");

            migrationBuilder.CreateIndex(
                name: "IX_Productions_WorkTypeId",
                table: "Productions",
                column: "WorkTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bales");

            migrationBuilder.DropTable(
                name: "Productions");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Materials");

            migrationBuilder.DropTable(
                name: "Storages");

            migrationBuilder.DropTable(
                name: "Taxes");

            migrationBuilder.DropTable(
                name: "WorkTypes");
        }
    }
}
