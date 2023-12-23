using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebProje.Migrations
{
    /// <inheritdoc />
    public partial class Deneme14 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Hastalar",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Doktorlar",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TC",
                table: "Doktorlar",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Hastalar");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Doktorlar");

            migrationBuilder.DropColumn(
                name: "TC",
                table: "Doktorlar");
        }
    }
}
