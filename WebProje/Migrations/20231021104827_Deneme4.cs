using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebProje.Migrations
{
    /// <inheritdoc />
    public partial class Deneme4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DoktorId",
                table: "Randevular",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Randevular_DoktorId",
                table: "Randevular",
                column: "DoktorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Randevular_Doktorlar_DoktorId",
                table: "Randevular",
                column: "DoktorId",
                principalTable: "Doktorlar",
                principalColumn: "DoktorId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Randevular_Doktorlar_DoktorId",
                table: "Randevular");

            migrationBuilder.DropIndex(
                name: "IX_Randevular_DoktorId",
                table: "Randevular");

            migrationBuilder.DropColumn(
                name: "DoktorId",
                table: "Randevular");
        }
    }
}
