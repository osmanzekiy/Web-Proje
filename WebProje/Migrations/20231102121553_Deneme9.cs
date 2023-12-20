using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebProje.Migrations
{
    /// <inheritdoc />
    public partial class Deneme9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RolId",
                table: "Roller",
                newName: "RoleId");

            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "Adminler",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RolesRoleId",
                table: "Adminler",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Adminler_RolesRoleId",
                table: "Adminler",
                column: "RolesRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Adminler_Roller_RolesRoleId",
                table: "Adminler",
                column: "RolesRoleId",
                principalTable: "Roller",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adminler_Roller_RolesRoleId",
                table: "Adminler");

            migrationBuilder.DropIndex(
                name: "IX_Adminler_RolesRoleId",
                table: "Adminler");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "Adminler");

            migrationBuilder.DropColumn(
                name: "RolesRoleId",
                table: "Adminler");

            migrationBuilder.RenameColumn(
                name: "RoleId",
                table: "Roller",
                newName: "RolId");
        }
    }
}
