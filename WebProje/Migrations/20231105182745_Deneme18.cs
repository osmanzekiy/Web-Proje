using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebProje.Migrations
{
    /// <inheritdoc />
    public partial class Deneme18 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hastalar_Roller_RolId",
                table: "Hastalar");

            migrationBuilder.AlterColumn<int>(
                name: "RolId",
                table: "Hastalar",
                type: "int",
                nullable: true,
                defaultValue:3,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Hastalar_Roller_RolId",
                table: "Hastalar",
                column: "RolId",
                principalTable: "Roller",
                principalColumn: "RolId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hastalar_Roller_RolId",
                table: "Hastalar");

            migrationBuilder.AlterColumn<int>(
                name: "RolId",
                table: "Hastalar",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Hastalar_Roller_RolId",
                table: "Hastalar",
                column: "RolId",
                principalTable: "Roller",
                principalColumn: "RolId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
