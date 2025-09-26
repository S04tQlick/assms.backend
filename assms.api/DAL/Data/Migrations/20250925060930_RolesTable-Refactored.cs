using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace assms.api.DAL.Data.Migrations
{
    /// <inheritdoc />
    public partial class RolesTableRefactored : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_RoleModel_RoleId",
                table: "UserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoleModel",
                table: "RoleModel");

            migrationBuilder.RenameTable(
                name: "RoleModel",
                newName: "Roles");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Roles",
                table: "Roles",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_Roles_RoleId",
                table: "UserRoles",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_Roles_RoleId",
                table: "UserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Roles",
                table: "Roles");

            migrationBuilder.RenameTable(
                name: "Roles",
                newName: "RoleModel");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoleModel",
                table: "RoleModel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_RoleModel_RoleId",
                table: "UserRoles",
                column: "RoleId",
                principalTable: "RoleModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
