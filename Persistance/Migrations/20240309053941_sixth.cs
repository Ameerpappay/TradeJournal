using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Migrations
{
    /// <inheritdoc />
    public partial class sixth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trade_AspNetUsers_CreatedById",
                table: "Trade");

            migrationBuilder.DropForeignKey(
                name: "FK_Trade_AspNetUsers_UpdatedById",
                table: "Trade");

            migrationBuilder.DropIndex(
                name: "IX_Trade_CreatedById",
                table: "Trade");

            migrationBuilder.DropIndex(
                name: "IX_Trade_UpdatedById",
                table: "Trade");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Trade");

            migrationBuilder.DropColumn(
                name: "UpdatedById",
                table: "Trade");

            migrationBuilder.CreateIndex(
                name: "IX_Trade_CreatedByUserId",
                table: "Trade",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Trade_UpdatedByUserId",
                table: "Trade",
                column: "UpdatedByUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trade_AspNetUsers_CreatedByUserId",
                table: "Trade",
                column: "CreatedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Trade_AspNetUsers_UpdatedByUserId",
                table: "Trade",
                column: "UpdatedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trade_AspNetUsers_CreatedByUserId",
                table: "Trade");

            migrationBuilder.DropForeignKey(
                name: "FK_Trade_AspNetUsers_UpdatedByUserId",
                table: "Trade");

            migrationBuilder.DropIndex(
                name: "IX_Trade_CreatedByUserId",
                table: "Trade");

            migrationBuilder.DropIndex(
                name: "IX_Trade_UpdatedByUserId",
                table: "Trade");

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "Trade",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedById",
                table: "Trade",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Trade_CreatedById",
                table: "Trade",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Trade_UpdatedById",
                table: "Trade",
                column: "UpdatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Trade_AspNetUsers_CreatedById",
                table: "Trade",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Trade_AspNetUsers_UpdatedById",
                table: "Trade",
                column: "UpdatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
