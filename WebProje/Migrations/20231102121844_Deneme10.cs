using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebProje.Migrations
{
    /// <inheritdoc />
    public partial class Deneme10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adminler_Roller_RoleId",
                table: "Adminler");

            migrationBuilder.RenameColumn(
                name: "RoleId",
                table: "Roller",
                newName: "RolId");

            migrationBuilder.RenameColumn(
                name: "RoleId",
                table: "Adminler",
                newName: "RolId");

            migrationBuilder.RenameIndex(
                name: "IX_Adminler_RolesRoleId",
                table: "Adminler",
                newName: "IX_Adminler_RolId");

            migrationBuilder.AddForeignKey(
                name: "FK_Adminler_Roller_RolId",
                table: "Adminler",
                column: "RolId",
                principalTable: "Roller",
                principalColumn: "RolId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adminler_Roller_RolId",
                table: "Adminler");

            migrationBuilder.RenameColumn(
                name: "RolId",
                table: "Roller",
                newName: "RoleId");

            migrationBuilder.RenameColumn(
                name: "RolId",
                table: "Adminler",
                newName: "RolesRoleId");

            migrationBuilder.RenameIndex(
                name: "IX_Adminler_RolId",
                table: "Adminler",
                newName: "IX_Adminler_RolesRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Adminler_Roller_RolesRoleId",
                table: "Adminler",
                column: "RolesRoleId",
                principalTable: "Roller",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
