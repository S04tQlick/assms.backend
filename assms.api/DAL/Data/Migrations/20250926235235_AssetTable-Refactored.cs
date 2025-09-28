using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace assms.api.DAL.Data.Migrations
{
    /// <inheritdoc />
    public partial class AssetTableRefactored : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssetCategories_AssetTypes_AssetTypeId",
                table: "AssetCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_Assets_AssetCategories_AssetCategoryId",
                table: "Assets");

            migrationBuilder.DropForeignKey(
                name: "FK_Assets_AssetTypes_AssetTypeId",
                table: "Assets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AssetTypes",
                table: "AssetTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AssetCategories",
                table: "AssetCategories");

            migrationBuilder.DropColumn(
                name: "BranchName",
                table: "Assets");

            migrationBuilder.RenameTable(
                name: "AssetTypes",
                newName: "AssetTypeModel");

            migrationBuilder.RenameTable(
                name: "AssetCategories",
                newName: "AssetCategoryModel");

            migrationBuilder.RenameIndex(
                name: "IX_AssetCategories_AssetTypeId",
                table: "AssetCategoryModel",
                newName: "IX_AssetCategoryModel_AssetTypeId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "WarrantyStartDate",
                table: "Assets",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "WarrantyEndDate",
                table: "Assets",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Region",
                table: "Assets",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "PurchasePrice",
                table: "Assets",
                type: "numeric",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "PurchaseDate",
                table: "Assets",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AssetTypeModel",
                table: "AssetTypeModel",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AssetCategoryModel",
                table: "AssetCategoryModel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AssetCategoryModel_AssetTypeModel_AssetTypeId",
                table: "AssetCategoryModel",
                column: "AssetTypeId",
                principalTable: "AssetTypeModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Assets_AssetCategoryModel_AssetCategoryId",
                table: "Assets",
                column: "AssetCategoryId",
                principalTable: "AssetCategoryModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Assets_AssetTypeModel_AssetTypeId",
                table: "Assets",
                column: "AssetTypeId",
                principalTable: "AssetTypeModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssetCategoryModel_AssetTypeModel_AssetTypeId",
                table: "AssetCategoryModel");

            migrationBuilder.DropForeignKey(
                name: "FK_Assets_AssetCategoryModel_AssetCategoryId",
                table: "Assets");

            migrationBuilder.DropForeignKey(
                name: "FK_Assets_AssetTypeModel_AssetTypeId",
                table: "Assets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AssetTypeModel",
                table: "AssetTypeModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AssetCategoryModel",
                table: "AssetCategoryModel");

            migrationBuilder.RenameTable(
                name: "AssetTypeModel",
                newName: "AssetTypes");

            migrationBuilder.RenameTable(
                name: "AssetCategoryModel",
                newName: "AssetCategories");

            migrationBuilder.RenameIndex(
                name: "IX_AssetCategoryModel_AssetTypeId",
                table: "AssetCategories",
                newName: "IX_AssetCategories_AssetTypeId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "WarrantyStartDate",
                table: "Assets",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "WarrantyEndDate",
                table: "Assets",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<string>(
                name: "Region",
                table: "Assets",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<decimal>(
                name: "PurchasePrice",
                table: "Assets",
                type: "numeric",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<DateTime>(
                name: "PurchaseDate",
                table: "Assets",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AddColumn<string>(
                name: "BranchName",
                table: "Assets",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AssetTypes",
                table: "AssetTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AssetCategories",
                table: "AssetCategories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AssetCategories_AssetTypes_AssetTypeId",
                table: "AssetCategories",
                column: "AssetTypeId",
                principalTable: "AssetTypes",
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
        }
    }
}
