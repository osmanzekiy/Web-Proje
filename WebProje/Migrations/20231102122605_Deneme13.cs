using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebProje.Migrations
{
    /// <inheritdoc />
    public partial class Deneme13 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RolId",
                table: "Hastalar",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RolId",
                table: "Doktorlar",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Hastalar_RolId",
                table: "Hastalar",
                column: "RolId");

            migrationBuilder.CreateIndex(
                name: "IX_Doktorlar_RolId",
                table: "Doktorlar",
                column: "RolId");

            migrationBuilder.AddForeignKey(
                name: "FK_Doktorlar_Roller_RolId",
                table: "Doktorlar",
                column: "RolId",
                principalTable: "Roller",
                principalColumn: "RolId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Hastalar_Roller_RolId",
                table: "Hastalar",
                column: "RolId",
                principalTable: "Roller",
                principalColumn: "RolId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doktorlar_Roller_RolId",
                table: "Doktorlar");

            migrationBuilder.DropForeignKey(
                name: "FK_Hastalar_Roller_RolId",
                table: "Hastalar");

            migrationBuilder.DropIndex(
                name: "IX_Hastalar_RolId",
                table: "Hastalar");

            migrationBuilder.DropIndex(
                name: "IX_Doktorlar_RolId",
                table: "Doktorlar");

            migrationBuilder.DropColumn(
                name: "RolId",
                table: "Hastalar");

            migrationBuilder.DropColumn(
                name: "RolId",
                table: "Doktorlar");
        }
    }
}
