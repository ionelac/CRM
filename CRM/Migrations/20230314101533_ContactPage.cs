using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRM.Migrations
{
    public partial class ContactPage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Customer",
                table: "Pipeline");

            migrationBuilder.AlterColumn<decimal>(
                name: "ExpectedRevenue",
                table: "Pipeline",
                type: "decimal(6,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<int>(
                name: "ContactID",
                table: "Pipeline",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Contact",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContactName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contact", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pipeline_ContactID",
                table: "Pipeline",
                column: "ContactID");

            migrationBuilder.AddForeignKey(
                name: "FK_Pipeline_Contact_ContactID",
                table: "Pipeline",
                column: "ContactID",
                principalTable: "Contact",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pipeline_Contact_ContactID",
                table: "Pipeline");

            migrationBuilder.DropTable(
                name: "Contact");

            migrationBuilder.DropIndex(
                name: "IX_Pipeline_ContactID",
                table: "Pipeline");

            migrationBuilder.DropColumn(
                name: "ContactID",
                table: "Pipeline");

            migrationBuilder.AlterColumn<decimal>(
                name: "ExpectedRevenue",
                table: "Pipeline",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(6,2)");

            migrationBuilder.AddColumn<string>(
                name: "Customer",
                table: "Pipeline",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
