using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IntroToWebApi_E.Migrations
{
    /// <inheritdoc />
    public partial class AddColumnsToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreditCompleted",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "department",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreditCompleted",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "department",
                table: "Users");
        }
    }
}
