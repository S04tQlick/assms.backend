using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace assms.api.DAL.Data.Migrations
{
    /// <inheritdoc />
    public partial class DatabaseTableRefactored : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssetImages_AssetModel_AssetId",
                table: "AssetImages");

            migrationBuilder.DropForeignKey(
                name: "FK_AssetModel_AssetCategories_AssetCategoryId",
                table: "AssetModel");

            migrationBuilder.DropForeignKey(
                name: "FK_AssetModel_AssetTypes_AssetTypeId",
                table: "AssetModel");

            migrationBuilder.DropForeignKey(
                name: "FK_AssetModel_BranchModel_BranchId",
                table: "AssetModel");

            migrationBuilder.DropForeignKey(
                name: "FK_AssetModel_Institutions_InstitutionId",
                table: "AssetModel");

            migrationBuilder.DropForeignKey(
                name: "FK_AssetModel_Vendors_VendorId",
                table: "AssetModel");

            migrationBuilder.DropForeignKey(
                name: "FK_BranchModel_Institutions_InstitutionId",
                table: "BranchModel");

            migrationBuilder.DropForeignKey(
                name: "FK_MaintenanceDue_AssetModel_AssetId",
                table: "MaintenanceDue");

            migrationBuilder.DropForeignKey(
                name: "FK_MaintenanceReports_AssetModel_AssetId",
                table: "MaintenanceReports");

            migrationBuilder.DropForeignKey(
                name: "FK_RefreshTokens_UserModel_UserId",
                table: "RefreshTokens");

            migrationBuilder.DropForeignKey(
                name: "FK_UserModel_BranchModel_BranchId",
                table: "UserModel");

            migrationBuilder.DropForeignKey(
                name: "FK_UserModel_Institutions_InstitutionId",
                table: "UserModel");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_UserModel_UserId",
                table: "UserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserModel",
                table: "UserModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BranchModel",
                table: "BranchModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AssetModel",
                table: "AssetModel");

            migrationBuilder.RenameTable(
                name: "UserModel",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "BranchModel",
                newName: "Branches");

            migrationBuilder.RenameTable(
                name: "AssetModel",
                newName: "Assets");

            migrationBuilder.RenameIndex(
                name: "IX_UserModel_InstitutionId",
                table: "Users",
                newName: "IX_Users_InstitutionId");

            migrationBuilder.RenameIndex(
                name: "IX_UserModel_BranchId",
                table: "Users",
                newName: "IX_Users_BranchId");

            migrationBuilder.RenameIndex(
                name: "IX_BranchModel_InstitutionId",
                table: "Branches",
                newName: "IX_Branches_InstitutionId");

            migrationBuilder.RenameIndex(
                name: "IX_AssetModel_VendorId",
                table: "Assets",
                newName: "IX_Assets_VendorId");

            migrationBuilder.RenameIndex(
                name: "IX_AssetModel_InstitutionId",
                table: "Assets",
                newName: "IX_Assets_InstitutionId");

            migrationBuilder.RenameIndex(
                name: "IX_AssetModel_BranchId",
                table: "Assets",
                newName: "IX_Assets_BranchId");

            migrationBuilder.RenameIndex(
                name: "IX_AssetModel_AssetTypeId",
                table: "Assets",
                newName: "IX_Assets_AssetTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_AssetModel_AssetCategoryId",
                table: "Assets",
                newName: "IX_Assets_AssetCategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Branches",
                table: "Branches",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Assets",
                table: "Assets",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AssetImages_Assets_AssetId",
                table: "AssetImages",
                column: "AssetId",
                principalTable: "Assets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Assets_AssetCategories_AssetCategoryId",
                table: "Assets",
                column: "AssetCategoryId",
                principalTable: "AssetCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Assets_AssetTypes_AssetTypeId",
                table: "Assets",
                column: "AssetTypeId",
                principalTable: "AssetTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Assets_Branches_BranchId",
                table: "Assets",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Assets_Institutions_InstitutionId",
                table: "Assets",
                column: "InstitutionId",
                principalTable: "Institutions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Assets_Vendors_VendorId",
                table: "Assets",
                column: "VendorId",
                principalTable: "Vendors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Branches_Institutions_InstitutionId",
                table: "Branches",
                column: "InstitutionId",
                principalTable: "Institutions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MaintenanceDue_Assets_AssetId",
                table: "MaintenanceDue",
                column: "AssetId",
                principalTable: "Assets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MaintenanceReports_Assets_AssetId",
                table: "MaintenanceReports",
                column: "AssetId",
                principalTable: "Assets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RefreshTokens_Users_UserId",
                table: "RefreshTokens",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_Users_UserId",
                table: "UserRoles",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Branches_BranchId",
                table: "Users",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Institutions_InstitutionId",
                table: "Users",
                column: "InstitutionId",
                principalTable: "Institutions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssetImages_Assets_AssetId",
                table: "AssetImages");

            migrationBuilder.DropForeignKey(
                name: "FK_Assets_AssetCategories_AssetCategoryId",
                table: "Assets");

            migrationBuilder.DropForeignKey(
                name: "FK_Assets_AssetTypes_AssetTypeId",
                table: "Assets");

            migrationBuilder.DropForeignKey(
                name: "FK_Assets_Branches_BranchId",
                table: "Assets");

            migrationBuilder.DropForeignKey(
                name: "FK_Assets_Institutions_InstitutionId",
                table: "Assets");

            migrationBuilder.DropForeignKey(
                name: "FK_Assets_Vendors_VendorId",
                table: "Assets");

            migrationBuilder.DropForeignKey(
                name: "FK_Branches_Institutions_InstitutionId",
                table: "Branches");

            migrationBuilder.DropForeignKey(
                name: "FK_MaintenanceDue_Assets_AssetId",
                table: "MaintenanceDue");

            migrationBuilder.DropForeignKey(
                name: "FK_MaintenanceReports_Assets_AssetId",
                table: "MaintenanceReports");

            migrationBuilder.DropForeignKey(
                name: "FK_RefreshTokens_Users_UserId",
                table: "RefreshTokens");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_Users_UserId",
                table: "UserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Branches_BranchId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Institutions_InstitutionId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Branches",
                table: "Branches");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Assets",
                table: "Assets");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "UserModel");

            migrationBuilder.RenameTable(
                name: "Branches",
                newName: "BranchModel");

            migrationBuilder.RenameTable(
                name: "Assets",
                newName: "AssetModel");

            migrationBuilder.RenameIndex(
                name: "IX_Users_InstitutionId",
                table: "UserModel",
                newName: "IX_UserModel_InstitutionId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_BranchId",
                table: "UserModel",
                newName: "IX_UserModel_BranchId");

            migrationBuilder.RenameIndex(
                name: "IX_Branches_InstitutionId",
                table: "BranchModel",
                newName: "IX_BranchModel_InstitutionId");

            migrationBuilder.RenameIndex(
                name: "IX_Assets_VendorId",
                table: "AssetModel",
                newName: "IX_AssetModel_VendorId");

            migrationBuilder.RenameIndex(
                name: "IX_Assets_InstitutionId",
                table: "AssetModel",
                newName: "IX_AssetModel_InstitutionId");

            migrationBuilder.RenameIndex(
                name: "IX_Assets_BranchId",
                table: "AssetModel",
                newName: "IX_AssetModel_BranchId");

            migrationBuilder.RenameIndex(
                name: "IX_Assets_AssetTypeId",
                table: "AssetModel",
                newName: "IX_AssetModel_AssetTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Assets_AssetCategoryId",
                table: "AssetModel",
                newName: "IX_AssetModel_AssetCategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserModel",
                table: "UserModel",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BranchModel",
                table: "BranchModel",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AssetModel",
                table: "AssetModel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AssetImages_AssetModel_AssetId",
                table: "AssetImages",
                column: "AssetId",
                principalTable: "AssetModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AssetModel_AssetCategories_AssetCategoryId",
                table: "AssetModel",
                column: "AssetCategoryId",
                principalTable: "AssetCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AssetModel_AssetTypes_AssetTypeId",
                table: "AssetModel",
                column: "AssetTypeId",
                principalTable: "AssetTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AssetModel_BranchModel_BranchId",
                table: "AssetModel",
                column: "BranchId",
                principalTable: "BranchModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AssetModel_Institutions_InstitutionId",
                table: "AssetModel",
                column: "InstitutionId",
                principalTable: "Institutions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AssetModel_Vendors_VendorId",
                table: "AssetModel",
                column: "VendorId",
                principalTable: "Vendors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BranchModel_Institutions_InstitutionId",
                table: "BranchModel",
                column: "InstitutionId",
                principalTable: "Institutions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MaintenanceDue_AssetModel_AssetId",
                table: "MaintenanceDue",
                column: "AssetId",
                principalTable: "AssetModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MaintenanceReports_AssetModel_AssetId",
                table: "MaintenanceReports",
                column: "AssetId",
                principalTable: "AssetModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RefreshTokens_UserModel_UserId",
                table: "RefreshTokens",
                column: "UserId",
                principalTable: "UserModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserModel_BranchModel_BranchId",
                table: "UserModel",
                column: "BranchId",
                principalTable: "BranchModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserModel_Institutions_InstitutionId",
                table: "UserModel",
                column: "InstitutionId",
                principalTable: "Institutions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_UserModel_UserId",
                table: "UserRoles",
                column: "UserId",
                principalTable: "UserModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
