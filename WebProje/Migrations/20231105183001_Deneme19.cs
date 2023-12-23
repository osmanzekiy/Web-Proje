using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebProje.Migrations
{
    /// <inheritdoc />
    public partial class Deneme19 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "RolId",
                table: "Hastalar",
                type: "int",
                nullable: true,
                defaultValue: 3,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "RolId",
                table: "Hastalar",
                type: "int",
                nullable: true,
                defaultValue: 1,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
