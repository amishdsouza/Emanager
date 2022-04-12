using Microsoft.EntityFrameworkCore.Migrations;

namespace Demo.Service.Migrations
{
    public partial class branchmaptable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmpBranchMap",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    EmployeeID = table.Column<string>(nullable: true),
                    BranchID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpBranchMap", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmpBranchMap_Branch_BranchID",
                        column: x => x.BranchID,
                        principalTable: "Branch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmpBranchMap_Employee_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmpBranchMap_BranchID",
                table: "EmpBranchMap",
                column: "BranchID");

            migrationBuilder.CreateIndex(
                name: "IX_EmpBranchMap_EmployeeID",
                table: "EmpBranchMap",
                column: "EmployeeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmpBranchMap");
        }
    }
}
