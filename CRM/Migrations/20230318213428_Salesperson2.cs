using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRM.Migrations
{
    public partial class Salesperson2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contact_Salesperson_SalespersonID",
                table: "Contact");

            migrationBuilder.DropIndex(
                name: "IX_Contact_SalespersonID",
                table: "Contact");

            migrationBuilder.DropColumn(
                name: "SalespersonID",
                table: "Contact");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SalespersonID",
                table: "Contact",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contact_SalespersonID",
                table: "Contact",
                column: "SalespersonID");

            migrationBuilder.AddForeignKey(
                name: "FK_Contact_Salesperson_SalespersonID",
                table: "Contact",
                column: "SalespersonID",
                principalTable: "Salesperson",
                principalColumn: "ID");
        }
    }
}
