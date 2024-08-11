using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace admin.Migrations
{
    /// <inheritdoc />
    public partial class AddBuyerInfoToSale : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BuyerAdress",
                table: "Sales",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "BuyerName",
                table: "Sales",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BuyerAdress",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "BuyerName",
                table: "Sales");
        }
    }
}
