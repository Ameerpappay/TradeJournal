using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Migrations
{
    /// <inheritdoc />
    public partial class fscd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Image_Trade_TradeIdentifier",
                table: "Image");

            migrationBuilder.DropForeignKey(
                name: "FK_Trade_Holdings_HoldingsIdentifier",
                table: "Trade");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Trade",
                table: "Trade");

            migrationBuilder.DropIndex(
                name: "IX_Trade_HoldingsIdentifier",
                table: "Trade");

            migrationBuilder.DropIndex(
                name: "IX_Image_TradeIdentifier",
                table: "Image");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Holdings",
                table: "Holdings");

            migrationBuilder.DropColumn(
                name: "HoldingsIdentifier",
                table: "Trade");

            migrationBuilder.DropColumn(
                name: "TradeIdentifier",
                table: "Image");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Trade",
                table: "Trade",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Holdings",
                table: "Holdings",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Trade_HoldingsId",
                table: "Trade",
                column: "HoldingsId");

            migrationBuilder.CreateIndex(
                name: "IX_Trade_Identifier",
                table: "Trade",
                column: "Identifier",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Image_TradeId",
                table: "Image",
                column: "TradeId");

            migrationBuilder.CreateIndex(
                name: "IX_Holdings_Identifier",
                table: "Holdings",
                column: "Identifier",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Image_Trade_TradeId",
                table: "Image",
                column: "TradeId",
                principalTable: "Trade",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Trade_Holdings_HoldingsId",
                table: "Trade",
                column: "HoldingsId",
                principalTable: "Holdings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Image_Trade_TradeId",
                table: "Image");

            migrationBuilder.DropForeignKey(
                name: "FK_Trade_Holdings_HoldingsId",
                table: "Trade");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Trade",
                table: "Trade");

            migrationBuilder.DropIndex(
                name: "IX_Trade_HoldingsId",
                table: "Trade");

            migrationBuilder.DropIndex(
                name: "IX_Trade_Identifier",
                table: "Trade");

            migrationBuilder.DropIndex(
                name: "IX_Image_TradeId",
                table: "Image");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Holdings",
                table: "Holdings");

            migrationBuilder.DropIndex(
                name: "IX_Holdings_Identifier",
                table: "Holdings");

            migrationBuilder.AddColumn<Guid>(
                name: "HoldingsIdentifier",
                table: "Trade",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "TradeIdentifier",
                table: "Image",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Trade",
                table: "Trade",
                column: "Identifier");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Holdings",
                table: "Holdings",
                column: "Identifier");

            migrationBuilder.CreateIndex(
                name: "IX_Trade_HoldingsIdentifier",
                table: "Trade",
                column: "HoldingsIdentifier");

            migrationBuilder.CreateIndex(
                name: "IX_Image_TradeIdentifier",
                table: "Image",
                column: "TradeIdentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Image_Trade_TradeIdentifier",
                table: "Image",
                column: "TradeIdentifier",
                principalTable: "Trade",
                principalColumn: "Identifier",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Trade_Holdings_HoldingsIdentifier",
                table: "Trade",
                column: "HoldingsIdentifier",
                principalTable: "Holdings",
                principalColumn: "Identifier",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
