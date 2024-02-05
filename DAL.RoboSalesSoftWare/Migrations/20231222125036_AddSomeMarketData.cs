using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.RoboSalesSoftWare.Migrations
{
    /// <inheritdoc />
    public partial class AddSomeMarketData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ShopNumber",
                table: "MarketDatas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShopNumber",
                table: "MarketDatas");
        }
    }
}
