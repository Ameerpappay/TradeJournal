using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Migrations
{
    /// <inheritdoc />
    public partial class first3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Image_AspNetUsers_CreatedById",
                table: "Image");

            migrationBuilder.DropForeignKey(
                name: "FK_Image_AspNetUsers_UpdatedById",
                table: "Image");

            migrationBuilder.DropForeignKey(
                name: "FK_Portfolio_AspNetUsers_CreatedById",
                table: "Portfolio");

            migrationBuilder.DropForeignKey(
                name: "FK_Portfolio_AspNetUsers_UpdatedById",
                table: "Portfolio");

            migrationBuilder.DropForeignKey(
                name: "FK_Strategies_AspNetUsers_CreatedByUserId",
                table: "Strategies");

            migrationBuilder.DropForeignKey(
                name: "FK_Strategies_AspNetUsers_UpdatedById",
                table: "Strategies");

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

            migrationBuilder.DropIndex(
                name: "IX_Strategies_UpdatedById",
                table: "Strategies");

            migrationBuilder.DropIndex(
                name: "IX_Portfolio_CreatedById",
                table: "Portfolio");

            migrationBuilder.DropIndex(
                name: "IX_Portfolio_UpdatedById",
                table: "Portfolio");

            migrationBuilder.DropIndex(
                name: "IX_Image_CreatedById",
                table: "Image");

            migrationBuilder.DropIndex(
                name: "IX_Image_UpdatedById",
                table: "Image");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Trade");

            migrationBuilder.DropColumn(
                name: "UpdatedById",
                table: "Trade");

            migrationBuilder.DropColumn(
                name: "UpdatedById",
                table: "Strategies");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Portfolio");

            migrationBuilder.DropColumn(
                name: "UpdatedById",
                table: "Portfolio");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Image");

            migrationBuilder.DropColumn(
                name: "UpdatedById",
                table: "Image");

            migrationBuilder.CreateIndex(
                name: "IX_Trade_CreatedByUserId",
                table: "Trade",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Trade_UpdatedByUserId",
                table: "Trade",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Strategies_UpdatedByUserId",
                table: "Strategies",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Portfolio_CreatedByUserId",
                table: "Portfolio",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Portfolio_UpdatedByUserId",
                table: "Portfolio",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Image_CreatedByUserId",
                table: "Image",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Image_UpdatedByUserId",
                table: "Image",
                column: "UpdatedByUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Image_AspNetUsers_CreatedByUserId",
                table: "Image",
                column: "CreatedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Image_AspNetUsers_UpdatedByUserId",
                table: "Image",
                column: "UpdatedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Portfolio_AspNetUsers_CreatedByUserId",
                table: "Portfolio",
                column: "CreatedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Portfolio_AspNetUsers_UpdatedByUserId",
                table: "Portfolio",
                column: "UpdatedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Strategies_AspNetUsers_CreatedByUserId",
                table: "Strategies",
                column: "CreatedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Strategies_AspNetUsers_UpdatedByUserId",
                table: "Strategies",
                column: "UpdatedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Trade_AspNetUsers_CreatedByUserId",
                table: "Trade",
                column: "CreatedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Trade_AspNetUsers_UpdatedByUserId",
                table: "Trade",
                column: "UpdatedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Image_AspNetUsers_CreatedByUserId",
                table: "Image");

            migrationBuilder.DropForeignKey(
                name: "FK_Image_AspNetUsers_UpdatedByUserId",
                table: "Image");

            migrationBuilder.DropForeignKey(
                name: "FK_Portfolio_AspNetUsers_CreatedByUserId",
                table: "Portfolio");

            migrationBuilder.DropForeignKey(
                name: "FK_Portfolio_AspNetUsers_UpdatedByUserId",
                table: "Portfolio");

            migrationBuilder.DropForeignKey(
                name: "FK_Strategies_AspNetUsers_CreatedByUserId",
                table: "Strategies");

            migrationBuilder.DropForeignKey(
                name: "FK_Strategies_AspNetUsers_UpdatedByUserId",
                table: "Strategies");

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

            migrationBuilder.DropIndex(
                name: "IX_Strategies_UpdatedByUserId",
                table: "Strategies");

            migrationBuilder.DropIndex(
                name: "IX_Portfolio_CreatedByUserId",
                table: "Portfolio");

            migrationBuilder.DropIndex(
                name: "IX_Portfolio_UpdatedByUserId",
                table: "Portfolio");

            migrationBuilder.DropIndex(
                name: "IX_Image_CreatedByUserId",
                table: "Image");

            migrationBuilder.DropIndex(
                name: "IX_Image_UpdatedByUserId",
                table: "Image");

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

            migrationBuilder.AddColumn<string>(
                name: "UpdatedById",
                table: "Strategies",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "Portfolio",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedById",
                table: "Portfolio",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "Image",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedById",
                table: "Image",
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

            migrationBuilder.CreateIndex(
                name: "IX_Strategies_UpdatedById",
                table: "Strategies",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Portfolio_CreatedById",
                table: "Portfolio",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Portfolio_UpdatedById",
                table: "Portfolio",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Image_CreatedById",
                table: "Image",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Image_UpdatedById",
                table: "Image",
                column: "UpdatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Image_AspNetUsers_CreatedById",
                table: "Image",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Image_AspNetUsers_UpdatedById",
                table: "Image",
                column: "UpdatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Portfolio_AspNetUsers_CreatedById",
                table: "Portfolio",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Portfolio_AspNetUsers_UpdatedById",
                table: "Portfolio",
                column: "UpdatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Strategies_AspNetUsers_CreatedByUserId",
                table: "Strategies",
                column: "CreatedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Strategies_AspNetUsers_UpdatedById",
                table: "Strategies",
                column: "UpdatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

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
