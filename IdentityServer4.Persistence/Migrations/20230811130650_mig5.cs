using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdentityServer4.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kategoriler_OneChildKategorilers_OneChildKategoriID",
                table: "Kategoriler");

            migrationBuilder.AddForeignKey(
                name: "FK_Kategoriler_OneChildKategorilers_OneChildKategoriID",
                table: "Kategoriler",
                column: "OneChildKategoriID",
                principalTable: "OneChildKategorilers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kategoriler_OneChildKategorilers_OneChildKategoriID",
                table: "Kategoriler");

            migrationBuilder.AddForeignKey(
                name: "FK_Kategoriler_OneChildKategorilers_OneChildKategoriID",
                table: "Kategoriler",
                column: "OneChildKategoriID",
                principalTable: "OneChildKategorilers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
