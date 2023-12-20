using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebProje.Migrations
{
    /// <inheritdoc />
    public partial class Deneme6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Randevular_Hastalar_HastaId",
                table: "Randevular");

            migrationBuilder.AlterColumn<int>(
                name: "HastaId",
                table: "Randevular",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Randevular_Hastalar_HastaId",
                table: "Randevular",
                column: "HastaId",
                principalTable: "Hastalar",
                principalColumn: "HastaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Randevular_Hastalar_HastaId",
                table: "Randevular");

            migrationBuilder.AlterColumn<int>(
                name: "HastaId",
                table: "Randevular",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Randevular_Hastalar_HastaId",
                table: "Randevular",
                column: "HastaId",
                principalTable: "Hastalar",
                principalColumn: "HastaId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
