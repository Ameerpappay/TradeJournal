using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Migrations
{
    /// <inheritdoc />
    public partial class fourth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreatedByUserId",
                table: "Trade",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UpdatedByUserId",
                table: "Trade",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CreatedByUserId",
                table: "Strategies",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UpdatedByUserId",
                table: "Strategies",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CreatedByUserId",
                table: "Image",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UpdatedByUserId",
                table: "Image",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "Trade");

            migrationBuilder.DropColumn(
                name: "UpdatedByUserId",
                table: "Trade");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "Strategies");

            migrationBuilder.DropColumn(
                name: "UpdatedByUserId",
                table: "Strategies");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "Image");

            migrationBuilder.DropColumn(
                name: "UpdatedByUserId",
                table: "Image");
        }
    }
}
