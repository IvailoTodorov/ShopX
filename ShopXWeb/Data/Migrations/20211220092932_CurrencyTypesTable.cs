using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopXWeb.Data.Migrations
{
    public partial class CurrencyTypesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PriceType",
                table: "Posts");

            migrationBuilder.AddColumn<int>(
                name: "CurrencyTypeId",
                table: "Posts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CurrencyTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrencyTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Posts_CurrencyTypeId",
                table: "Posts",
                column: "CurrencyTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_CurrencyTypes_CurrencyTypeId",
                table: "Posts",
                column: "CurrencyTypeId",
                principalTable: "CurrencyTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_CurrencyTypes_CurrencyTypeId",
                table: "Posts");

            migrationBuilder.DropTable(
                name: "CurrencyTypes");

            migrationBuilder.DropIndex(
                name: "IX_Posts_CurrencyTypeId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "CurrencyTypeId",
                table: "Posts");

            migrationBuilder.AddColumn<string>(
                name: "PriceType",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
