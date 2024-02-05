using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.RoboSalesSoftWare.Migrations
{
    /// <inheritdoc />
    public partial class Start : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MarketDatas",
                columns: table => new
                {
                    MarketCode = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArabicName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telephone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarketDatas", x => x.MarketCode);
                });

            migrationBuilder.CreateTable(
                name: "Receipts",
                columns: table => new
                {
                    ReceiptCode = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    marketCode = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receipts", x => x.ReceiptCode);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserCode = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PassWord = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserCode);
                });

            migrationBuilder.CreateTable(
                name: "VegatablesTypes",
                columns: table => new
                {
                    TypeCode = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Arabic_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Cover = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReceiptCode = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VegatablesTypes", x => x.TypeCode);
                    table.ForeignKey(
                        name: "FK_VegatablesTypes_Receipts_ReceiptCode",
                        column: x => x.ReceiptCode,
                        principalTable: "Receipts",
                        principalColumn: "ReceiptCode");
                });

            migrationBuilder.CreateTable(
                name: "ReceiptDetailss",
                columns: table => new
                {
                    ReceiptDetailsCode = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    typeCode = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    ReceiptCode = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceiptDetailss", x => x.ReceiptDetailsCode);
                    table.ForeignKey(
                        name: "FK_ReceiptDetailss_Receipts_ReceiptCode",
                        column: x => x.ReceiptCode,
                        principalTable: "Receipts",
                        principalColumn: "ReceiptCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReceiptDetailss_VegatablesTypes_typeCode",
                        column: x => x.typeCode,
                        principalTable: "VegatablesTypes",
                        principalColumn: "TypeCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReceiptDetailss_ReceiptCode",
                table: "ReceiptDetailss",
                column: "ReceiptCode");

            migrationBuilder.CreateIndex(
                name: "IX_ReceiptDetailss_typeCode",
                table: "ReceiptDetailss",
                column: "typeCode");

            migrationBuilder.CreateIndex(
                name: "IX_VegatablesTypes_ReceiptCode",
                table: "VegatablesTypes",
                column: "ReceiptCode");
            migrationBuilder.Sql(InsertData.SetDataForUsers());
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MarketDatas");

            migrationBuilder.DropTable(
                name: "ReceiptDetailss");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "VegatablesTypes");

            migrationBuilder.DropTable(
                name: "Receipts");
        }
    }
}
