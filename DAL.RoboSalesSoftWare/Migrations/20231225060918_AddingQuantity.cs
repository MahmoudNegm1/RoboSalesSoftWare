using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.RoboSalesSoftWare.Migrations
{
    /// <inheritdoc />
    public partial class AddingQuantity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Quantity",
                table: "ReceiptDetailss",
                type: "decimal(18,2)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "ReceiptDetailss");
        }
    }
}
