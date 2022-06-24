using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Codecool.CodecoolShop.Migrations
{
    public partial class CreateModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BaseModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DefaultPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ProductCategoryId = table.Column<int>(type: "int", nullable: true),
                    SupplierId = table.Column<int>(type: "int", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: true),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BaseModels_BaseModels_ProductCategoryId",
                        column: x => x.ProductCategoryId,
                        principalTable: "BaseModels",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BaseModels_BaseModels_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "BaseModels",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BaseModels_ProductCategoryId",
                table: "BaseModels",
                column: "ProductCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseModels_SupplierId",
                table: "BaseModels",
                column: "SupplierId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BaseModels");
        }
    }
}
