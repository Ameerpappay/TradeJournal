using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Migrations
{
    /// <inheritdoc />
    public partial class fifth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Strategies_AspNetUsers_CreatedById",
                table: "Strategies");

            migrationBuilder.DropForeignKey(
                name: "FK_Strategies_AspNetUsers_UpdatedById",
                table: "Strategies");

            migrationBuilder.DropIndex(
                name: "IX_Strategies_CreatedById",
                table: "Strategies");

            migrationBuilder.DropIndex(
                name: "IX_Strategies_UpdatedById",
                table: "Strategies");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Strategies");

            migrationBuilder.DropColumn(
                name: "UpdatedById",
                table: "Strategies");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedByUserId",
                table: "Trade",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedByUserId",
                table: "Trade",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedByUserId",
                table: "Strategies",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedByUserId",
                table: "Strategies",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedByUserId",
                table: "Image",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedByUserId",
                table: "Image",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.CreateIndex(
                name: "IX_Strategies_CreatedByUserId",
                table: "Strategies",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Strategies_UpdatedByUserId",
                table: "Strategies",
                column: "UpdatedByUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Strategies_AspNetUsers_CreatedByUserId",
                table: "Strategies",
                column: "CreatedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Strategies_AspNetUsers_UpdatedByUserId",
                table: "Strategies",
                column: "UpdatedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Strategies_AspNetUsers_CreatedByUserId",
                table: "Strategies");

            migrationBuilder.DropForeignKey(
                name: "FK_Strategies_AspNetUsers_UpdatedByUserId",
                table: "Strategies");

            migrationBuilder.DropIndex(
                name: "IX_Strategies_CreatedByUserId",
                table: "Strategies");

            migrationBuilder.DropIndex(
                name: "IX_Strategies_UpdatedByUserId",
                table: "Strategies");

            migrationBuilder.AlterColumn<int>(
                name: "UpdatedByUserId",
                table: "Trade",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "CreatedByUserId",
                table: "Trade",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "UpdatedByUserId",
                table: "Strategies",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "CreatedByUserId",
                table: "Strategies",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "Strategies",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedById",
                table: "Strategies",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UpdatedByUserId",
                table: "Image",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "CreatedByUserId",
                table: "Image",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.CreateIndex(
                name: "IX_Strategies_CreatedById",
                table: "Strategies",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Strategies_UpdatedById",
                table: "Strategies",
                column: "UpdatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Strategies_AspNetUsers_CreatedById",
                table: "Strategies",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Strategies_AspNetUsers_UpdatedById",
                table: "Strategies",
                column: "UpdatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
