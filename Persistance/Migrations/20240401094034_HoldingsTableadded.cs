using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Persistance.Migrations
{
    /// <inheritdoc />
    public partial class HoldingsTableadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "HoldingsIdentifier",
                table: "Trade",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Holdings",
                columns: table => new
                {
                    Identifier = table.Column<Guid>(type: "uuid", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: false),
                    Quantity = table.Column<decimal>(type: "numeric", nullable: false),
                    BuyPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    TrailingStoploss = table.Column<decimal>(type: "numeric", nullable: false),
                    PortfolioId = table.Column<int>(type: "integer", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DateCreated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    DateDeleted = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedByUserId = table.Column<string>(type: "text", nullable: false),
                    UpdatedByUserId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Holdings", x => x.Identifier);
                    table.ForeignKey(
                        name: "FK_Holdings_AspNetUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Holdings_AspNetUsers_UpdatedByUserId",
                        column: x => x.UpdatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Holdings_Portfolio_PortfolioId",
                        column: x => x.PortfolioId,
                        principalTable: "Portfolio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Trade_HoldingsIdentifier",
                table: "Trade",
                column: "HoldingsIdentifier");

            migrationBuilder.CreateIndex(
                name: "IX_Holdings_CreatedByUserId",
                table: "Holdings",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Holdings_PortfolioId",
                table: "Holdings",
                column: "PortfolioId");

            migrationBuilder.CreateIndex(
                name: "IX_Holdings_UpdatedByUserId",
                table: "Holdings",
                column: "UpdatedByUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trade_Holdings_HoldingsIdentifier",
                table: "Trade",
                column: "HoldingsIdentifier",
                principalTable: "Holdings",
                principalColumn: "Identifier");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trade_Holdings_HoldingsIdentifier",
                table: "Trade");

            migrationBuilder.DropTable(
                name: "Holdings");

            migrationBuilder.DropIndex(
                name: "IX_Trade_HoldingsIdentifier",
                table: "Trade");

            migrationBuilder.DropColumn(
                name: "HoldingsIdentifier",
                table: "Trade");
        }
    }
}
