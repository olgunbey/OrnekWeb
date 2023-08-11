using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdentityServer4.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class updatedatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FileAddress",
                table: "ProductDetail",
                newName: "FileName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FileName",
                table: "ProductDetail",
                newName: "FileAddress");
        }
    }
}
