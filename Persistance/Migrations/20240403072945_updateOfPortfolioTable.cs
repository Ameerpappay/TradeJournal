using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Migrations
{
    /// <inheritdoc />
    public partial class updateOfPortfolioTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trade_Portfolio_PortfolioId",
                table: "Trade");

            migrationBuilder.DropIndex(
                name: "IX_Trade_PortfolioId",
                table: "Trade");

            migrationBuilder.DropColumn(
                name: "PortfolioId",
                table: "Trade");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PortfolioId",
                table: "Trade",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Trade_PortfolioId",
                table: "Trade",
                column: "PortfolioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trade_Portfolio_PortfolioId",
                table: "Trade",
                column: "PortfolioId",
                principalTable: "Portfolio",
                principalColumn: "Id");
        }
    }
}
