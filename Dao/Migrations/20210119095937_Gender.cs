using Microsoft.EntityFrameworkCore.Migrations;

namespace Dao.Migrations
{
    public partial class Gender : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Crystal",
                table: "Product",
                newName: "Gender");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Gender",
                table: "Product",
                newName: "Crystal");
        }
    }
}
