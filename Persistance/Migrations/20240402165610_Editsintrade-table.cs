using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Migrations
{
    /// <inheritdoc />
    public partial class Editsintradetable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trade_Holdings_HoldingsIdentifier",
                table: "Trade");

            migrationBuilder.DropForeignKey(
                name: "FK_Trade_Portfolio_PortfolioId",
                table: "Trade");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Trade");

            migrationBuilder.AlterColumn<int>(
                name: "PortfolioId",
                table: "Trade",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<Guid>(
                name: "HoldingsIdentifier",
                table: "Trade",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HoldingsId",
                table: "Trade",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Trade_Holdings_HoldingsIdentifier",
                table: "Trade",
                column: "HoldingsIdentifier",
                principalTable: "Holdings",
                principalColumn: "Identifier",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Trade_Portfolio_PortfolioId",
                table: "Trade",
                column: "PortfolioId",
                principalTable: "Portfolio",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trade_Holdings_HoldingsIdentifier",
                table: "Trade");

            migrationBuilder.DropForeignKey(
                name: "FK_Trade_Portfolio_PortfolioId",
                table: "Trade");

            migrationBuilder.DropColumn(
                name: "HoldingsId",
                table: "Trade");

            migrationBuilder.AlterColumn<int>(
                name: "PortfolioId",
                table: "Trade",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "HoldingsIdentifier",
                table: "Trade",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Trade",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Trade_Holdings_HoldingsIdentifier",
                table: "Trade",
                column: "HoldingsIdentifier",
                principalTable: "Holdings",
                principalColumn: "Identifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Trade_Portfolio_PortfolioId",
                table: "Trade",
                column: "PortfolioId",
                principalTable: "Portfolio",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
