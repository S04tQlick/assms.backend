using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace assms.api.DAL.Data.Migrations
{
    /// <inheritdoc />
    public partial class emailaddedtoinsitutiuontable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Institutions",
                newName: "Email");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Institutions",
                newName: "Address");
        }
    }
}
