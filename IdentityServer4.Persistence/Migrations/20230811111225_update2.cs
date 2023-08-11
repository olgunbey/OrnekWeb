using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdentityServer4.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class update2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MyProperty",
                table: "ProductDetail",
                newName: "FileByte64");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FileByte64",
                table: "ProductDetail",
                newName: "MyProperty");
        }
    }
}
