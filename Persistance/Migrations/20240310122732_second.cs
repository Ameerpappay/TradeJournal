using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Migrations
{
    /// <inheritdoc />
    public partial class second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Image_Trade_TradeId",
                table: "Image");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Trade",
                table: "Trade");

            migrationBuilder.DropIndex(
                name: "IX_Image_TradeId",
                table: "Image");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Image_Trade_TradeIdentifier",
                table: "Image");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Trade",
                table: "Trade");

            migrationBuilder.DropIndex(
                name: "IX_Image_TradeIdentifier",
                table: "Image");

            migrationBuilder.DropColumn(
                name: "TradeIdentifier",
                table: "Image");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Trade",
                table: "Trade",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Image_TradeId",
                table: "Image",
                column: "TradeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Image_Trade_TradeId",
                table: "Image",
                column: "TradeId",
                principalTable: "Trade",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
