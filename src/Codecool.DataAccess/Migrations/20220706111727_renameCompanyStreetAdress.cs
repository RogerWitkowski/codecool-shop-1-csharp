using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Codecool.DataAccess.Migrations
{
    public partial class renameCompanyStreetAdress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StreetAddress",
                table: "Companies",
                newName: "StreetAdress");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StreetAdress",
                table: "Companies",
                newName: "StreetAddress");
        }
    }
}
