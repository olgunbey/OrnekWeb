using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdentityServer4.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cinsiyets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CinsiyetAdi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cinsiyets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Color",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RenkIsim = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Color", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kullanicilar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KullaniciAd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KullaniciMail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KullaniciName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KullaniciSifre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kullanicilar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Markalar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MarkaName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Markalar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ThreeChildKategori",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ThreeChildKategoriName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThreeChildKategori", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoleKullanicilarManyToManies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KullaniciID = table.Column<int>(type: "int", nullable: false),
                    RoleID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleKullanicilarManyToManies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleKullanicilarManyToManies_Kullanicilar_KullaniciID",
                        column: x => x.KullaniciID,
                        principalTable: "Kullanicilar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleKullanicilarManyToManies_Roles_RoleID",
                        column: x => x.RoleID,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TwoChildKategorilers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TwoChildKategoriName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThreeChildKategoriID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TwoChildKategorilers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TwoChildKategorilers_ThreeChildKategori_ThreeChildKategoriID",
                        column: x => x.ThreeChildKategoriID,
                        principalTable: "ThreeChildKategori",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OneChildKategorilers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OneChildKategoriName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TwoChildKategoriID = table.Column<int>(type: "int", nullable: true),
                    ThreeChildKategoriID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OneChildKategorilers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OneChildKategorilers_ThreeChildKategori_ThreeChildKategoriID",
                        column: x => x.ThreeChildKategoriID,
                        principalTable: "ThreeChildKategori",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OneChildKategorilers_TwoChildKategorilers_TwoChildKategoriID",
                        column: x => x.TwoChildKategoriID,
                        principalTable: "TwoChildKategorilers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Kategoriler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KategoriName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OneChildKategoriID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategoriler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kategoriler_OneChildKategorilers_OneChildKategoriID",
                        column: x => x.OneChildKategoriID,
                        principalTable: "OneChildKategorilers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OneChildRelationshipCinsiyets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OneChildID = table.Column<int>(type: "int", nullable: false),
                    CinsiyetID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OneChildRelationshipCinsiyets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OneChildRelationshipCinsiyets_Cinsiyets_CinsiyetID",
                        column: x => x.CinsiyetID,
                        principalTable: "Cinsiyets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OneChildRelationshipCinsiyets_OneChildKategorilers_OneChildID",
                        column: x => x.OneChildID,
                        principalTable: "OneChildKategorilers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Urunlers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UrunName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KategoriID = table.Column<int>(type: "int", nullable: false),
                    MarkalarID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Urunlers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Urunlers_Kategoriler_KategoriID",
                        column: x => x.KategoriID,
                        principalTable: "Kategoriler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Urunlers_Markalar_MarkalarID",
                        column: x => x.MarkalarID,
                        principalTable: "Markalar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Evaluation = table.Column<int>(type: "int", nullable: false),
                    UrunlerID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductDetail_Urunlers_UrunlerID",
                        column: x => x.UrunlerID,
                        principalTable: "Urunlers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Stock",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UrunlerID = table.Column<int>(type: "int", nullable: false),
                    RenklerID = table.Column<int>(type: "int", nullable: false),
                    Stok = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stock", x => x.Id);
                    table.UniqueConstraint("AK_Stock_RenklerID_UrunlerID_Id", x => new { x.RenklerID, x.UrunlerID, x.Id });
                    table.ForeignKey(
                        name: "FK_Stock_Color_RenklerID",
                        column: x => x.RenklerID,
                        principalTable: "Color",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Stock_Urunlers_UrunlerID",
                        column: x => x.UrunlerID,
                        principalTable: "Urunlers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Kategoriler_OneChildKategoriID",
                table: "Kategoriler",
                column: "OneChildKategoriID");

            migrationBuilder.CreateIndex(
                name: "IX_OneChildKategorilers_ThreeChildKategoriID",
                table: "OneChildKategorilers",
                column: "ThreeChildKategoriID");

            migrationBuilder.CreateIndex(
                name: "IX_OneChildKategorilers_TwoChildKategoriID",
                table: "OneChildKategorilers",
                column: "TwoChildKategoriID");

            migrationBuilder.CreateIndex(
                name: "IX_OneChildRelationshipCinsiyets_CinsiyetID",
                table: "OneChildRelationshipCinsiyets",
                column: "CinsiyetID");

            migrationBuilder.CreateIndex(
                name: "IX_OneChildRelationshipCinsiyets_OneChildID",
                table: "OneChildRelationshipCinsiyets",
                column: "OneChildID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetail_UrunlerID",
                table: "ProductDetail",
                column: "UrunlerID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RoleKullanicilarManyToManies_KullaniciID",
                table: "RoleKullanicilarManyToManies",
                column: "KullaniciID");

            migrationBuilder.CreateIndex(
                name: "IX_RoleKullanicilarManyToManies_RoleID",
                table: "RoleKullanicilarManyToManies",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_Stock_UrunlerID",
                table: "Stock",
                column: "UrunlerID");

            migrationBuilder.CreateIndex(
                name: "IX_TwoChildKategorilers_ThreeChildKategoriID",
                table: "TwoChildKategorilers",
                column: "ThreeChildKategoriID");

            migrationBuilder.CreateIndex(
                name: "IX_Urunlers_KategoriID",
                table: "Urunlers",
                column: "KategoriID");

            migrationBuilder.CreateIndex(
                name: "IX_Urunlers_MarkalarID",
                table: "Urunlers",
                column: "MarkalarID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OneChildRelationshipCinsiyets");

            migrationBuilder.DropTable(
                name: "ProductDetail");

            migrationBuilder.DropTable(
                name: "RoleKullanicilarManyToManies");

            migrationBuilder.DropTable(
                name: "Stock");

            migrationBuilder.DropTable(
                name: "Cinsiyets");

            migrationBuilder.DropTable(
                name: "Kullanicilar");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Color");

            migrationBuilder.DropTable(
                name: "Urunlers");

            migrationBuilder.DropTable(
                name: "Kategoriler");

            migrationBuilder.DropTable(
                name: "Markalar");

            migrationBuilder.DropTable(
                name: "OneChildKategorilers");

            migrationBuilder.DropTable(
                name: "TwoChildKategorilers");

            migrationBuilder.DropTable(
                name: "ThreeChildKategori");
        }
    }
}
