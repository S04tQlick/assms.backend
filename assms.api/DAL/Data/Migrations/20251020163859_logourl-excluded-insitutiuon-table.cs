using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace assms.api.DAL.Data.Migrations
{
    /// <inheritdoc />
    public partial class logourlexcludedinsitutiuontable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LogoUrl",
                table: "Institutions");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LogoUrl",
                table: "Institutions",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
