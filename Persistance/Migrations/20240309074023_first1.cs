using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Migrations
{
    /// <inheritdoc />
    public partial class first1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Image_AspNetUsers_CreatedById",
                table: "Image");

            migrationBuilder.DropForeignKey(
                name: "FK_Portfolio_AspNetUsers_CreatedById",
                table: "Portfolio");

            migrationBuilder.DropForeignKey(
                name: "FK_Strategies_AspNetUsers_CreatedById",
                table: "Strategies");

            migrationBuilder.DropForeignKey(
                name: "FK_Trade_AspNetUsers_CreatedById",
                table: "Trade");

            migrationBuilder.RenameColumn(
                name: "CreatedById",
                table: "Strategies",
                newName: "CreatedByUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Strategies_CreatedById",
                table: "Strategies",
                newName: "IX_Strategies_CreatedByUserId");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedById",
                table: "Trade",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "CreatedByUserId",
                table: "Trade",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UpdatedByUserId",
                table: "Trade",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedByUserId",
                table: "Strategies",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedById",
                table: "Portfolio",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "CreatedByUserId",
                table: "Portfolio",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UpdatedByUserId",
                table: "Portfolio",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedById",
                table: "Image",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "CreatedByUserId",
                table: "Image",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UpdatedByUserId",
                table: "Image",
                type: "text",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Image_AspNetUsers_CreatedById",
                table: "Image",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Portfolio_AspNetUsers_CreatedById",
                table: "Portfolio",
                column: "CreatedById",
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
                name: "FK_Trade_AspNetUsers_CreatedById",
                table: "Trade",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Image_AspNetUsers_CreatedById",
                table: "Image");

            migrationBuilder.DropForeignKey(
                name: "FK_Portfolio_AspNetUsers_CreatedById",
                table: "Portfolio");

            migrationBuilder.DropForeignKey(
                name: "FK_Strategies_AspNetUsers_CreatedByUserId",
                table: "Strategies");

            migrationBuilder.DropForeignKey(
                name: "FK_Trade_AspNetUsers_CreatedById",
                table: "Trade");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "Trade");

            migrationBuilder.DropColumn(
                name: "UpdatedByUserId",
                table: "Trade");

            migrationBuilder.DropColumn(
                name: "UpdatedByUserId",
                table: "Strategies");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "Portfolio");

            migrationBuilder.DropColumn(
                name: "UpdatedByUserId",
                table: "Portfolio");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "Image");

            migrationBuilder.DropColumn(
                name: "UpdatedByUserId",
                table: "Image");

            migrationBuilder.RenameColumn(
                name: "CreatedByUserId",
                table: "Strategies",
                newName: "CreatedById");

            migrationBuilder.RenameIndex(
                name: "IX_Strategies_CreatedByUserId",
                table: "Strategies",
                newName: "IX_Strategies_CreatedById");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedById",
                table: "Trade",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedById",
                table: "Portfolio",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedById",
                table: "Image",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Image_AspNetUsers_CreatedById",
                table: "Image",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Portfolio_AspNetUsers_CreatedById",
                table: "Portfolio",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Strategies_AspNetUsers_CreatedById",
                table: "Strategies",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Trade_AspNetUsers_CreatedById",
                table: "Trade",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
