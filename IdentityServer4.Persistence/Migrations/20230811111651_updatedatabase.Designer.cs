﻿// <auto-generated />
using System;
using IdentityServer4.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace IdentityServer4.Persistence.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230811111651_updatedatabase")]
    partial class updatedatabase
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("IdentityServer4.Domain.Entities.Cinsiyet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CinsiyetAdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Cinsiyets");
                });

            modelBuilder.Entity("IdentityServer4.Domain.Entities.Color", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("RenkIsim")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Color");
                });

            modelBuilder.Entity("IdentityServer4.Domain.Entities.Kategoriler", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("KategoriName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("OneChildKategoriID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OneChildKategoriID");

                    b.ToTable("Kategoriler");
                });

            modelBuilder.Entity("IdentityServer4.Domain.Entities.Kullanicilar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("KullaniciAd")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KullaniciMail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KullaniciName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KullaniciSifre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Kullanicilar");
                });

            modelBuilder.Entity("IdentityServer4.Domain.Entities.MarkaOneChildKategoriToMany", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("KategoriID")
                        .HasColumnType("int");

                    b.Property<int>("MarkaID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("KategoriID");

                    b.HasIndex("MarkaID");

                    b.ToTable("MarkaOneChildKategoriToManies");
                });

            modelBuilder.Entity("IdentityServer4.Domain.Entities.Markalar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("MarkaName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Markalar");
                });

            modelBuilder.Entity("IdentityServer4.Domain.Entities.OneChildKategoriler", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("OneChildKategoriName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ThreeChildKategoriID")
                        .HasColumnType("int");

                    b.Property<int?>("TwoChildKategoriID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ThreeChildKategoriID");

                    b.HasIndex("TwoChildKategoriID");

                    b.ToTable("OneChildKategorilers");
                });

            modelBuilder.Entity("IdentityServer4.Domain.Entities.OneChildRelationshipCinsiyet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CinsiyetID")
                        .HasColumnType("int");

                    b.Property<int>("OneChildID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CinsiyetID");

                    b.HasIndex("OneChildID");

                    b.ToTable("OneChildRelationshipCinsiyets");
                });

            modelBuilder.Entity("IdentityServer4.Domain.Entities.ProductDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Evaluation")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<byte[]>("FileByte64")
                        .IsRequired()
                        .HasColumnType("varbinary(64)");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("UrunlerID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UrunlerID")
                        .IsUnique();

                    b.ToTable("ProductDetail");
                });

            modelBuilder.Entity("IdentityServer4.Domain.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("IdentityServer4.Domain.Entities.RoleKullanicilarManyToMany", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("KullaniciID")
                        .HasColumnType("int");

                    b.Property<int>("RoleID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("KullaniciID");

                    b.HasIndex("RoleID");

                    b.ToTable("RoleKullanicilarManyToManies");
                });

            modelBuilder.Entity("IdentityServer4.Domain.Entities.Size", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("SizeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Size");
                });

            modelBuilder.Entity("IdentityServer4.Domain.Entities.Stock", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("RenklerID")
                        .HasColumnType("int");

                    b.Property<int?>("SizeID")
                        .HasColumnType("int");

                    b.Property<int>("Stok")
                        .HasColumnType("int");

                    b.Property<int>("UrunlerID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasAlternateKey("RenklerID", "UrunlerID", "Id");

                    b.HasIndex("SizeID");

                    b.HasIndex("UrunlerID");

                    b.ToTable("Stock");
                });

            modelBuilder.Entity("IdentityServer4.Domain.Entities.ThreeChildKategori", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ThreeChildKategoriName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ThreeChildKategori");
                });

            modelBuilder.Entity("IdentityServer4.Domain.Entities.TwoChildKategoriler", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ThreeChildKategoriID")
                        .HasColumnType("int");

                    b.Property<string>("TwoChildKategoriName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ThreeChildKategoriID");

                    b.ToTable("TwoChildKategorilers");
                });

            modelBuilder.Entity("IdentityServer4.Domain.Entities.Urunler", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("KategoriID")
                        .HasColumnType("int");

                    b.Property<int>("MarkalarID")
                        .HasColumnType("int");

                    b.Property<string>("UrunName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("KategoriID");

                    b.HasIndex("MarkalarID");

                    b.ToTable("Urunlers");
                });

            modelBuilder.Entity("IdentityServer4.Domain.Entities.Kategoriler", b =>
                {
                    b.HasOne("IdentityServer4.Domain.Entities.OneChildKategoriler", "OneChildKategori")
                        .WithMany("Kategorilers")
                        .HasForeignKey("OneChildKategoriID");

                    b.Navigation("OneChildKategori");
                });

            modelBuilder.Entity("IdentityServer4.Domain.Entities.MarkaOneChildKategoriToMany", b =>
                {
                    b.HasOne("IdentityServer4.Domain.Entities.Kategoriler", "Kategoriler")
                        .WithMany("MarkaOneChildKategoriToManies")
                        .HasForeignKey("KategoriID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IdentityServer4.Domain.Entities.Markalar", "Markalar")
                        .WithMany("MarkaOneChildKategoriToManies")
                        .HasForeignKey("MarkaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kategoriler");

                    b.Navigation("Markalar");
                });

            modelBuilder.Entity("IdentityServer4.Domain.Entities.OneChildKategoriler", b =>
                {
                    b.HasOne("IdentityServer4.Domain.Entities.ThreeChildKategori", "ThreeChildKategori")
                        .WithMany("OneChildKategorilers")
                        .HasForeignKey("ThreeChildKategoriID");

                    b.HasOne("IdentityServer4.Domain.Entities.TwoChildKategoriler", "TwoChildKategori")
                        .WithMany("OneChildKategorilers")
                        .HasForeignKey("TwoChildKategoriID");

                    b.Navigation("ThreeChildKategori");

                    b.Navigation("TwoChildKategori");
                });

            modelBuilder.Entity("IdentityServer4.Domain.Entities.OneChildRelationshipCinsiyet", b =>
                {
                    b.HasOne("IdentityServer4.Domain.Entities.Cinsiyet", "Cinsiyet")
                        .WithMany("OneChildRelationshipCinsiyets")
                        .HasForeignKey("CinsiyetID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IdentityServer4.Domain.Entities.OneChildKategoriler", "OneChildKategori")
                        .WithMany("OneChildRelationshipCinsiyets")
                        .HasForeignKey("OneChildID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cinsiyet");

                    b.Navigation("OneChildKategori");
                });

            modelBuilder.Entity("IdentityServer4.Domain.Entities.ProductDetail", b =>
                {
                    b.HasOne("IdentityServer4.Domain.Entities.Urunler", "Product")
                        .WithOne("ProductDetail")
                        .HasForeignKey("IdentityServer4.Domain.Entities.ProductDetail", "UrunlerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("IdentityServer4.Domain.Entities.RoleKullanicilarManyToMany", b =>
                {
                    b.HasOne("IdentityServer4.Domain.Entities.Kullanicilar", "Kullanicilar")
                        .WithMany("RoleKullanicilarManyToManies")
                        .HasForeignKey("KullaniciID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IdentityServer4.Domain.Entities.Role", "Role")
                        .WithMany("RoleKullanicilarManyToManies")
                        .HasForeignKey("RoleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kullanicilar");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("IdentityServer4.Domain.Entities.Stock", b =>
                {
                    b.HasOne("IdentityServer4.Domain.Entities.Color", "Color")
                        .WithMany("Stocks")
                        .HasForeignKey("RenklerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IdentityServer4.Domain.Entities.Size", "Size")
                        .WithMany("Stocks")
                        .HasForeignKey("SizeID");

                    b.HasOne("IdentityServer4.Domain.Entities.Urunler", "Urunler")
                        .WithMany("Stocks")
                        .HasForeignKey("UrunlerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Color");

                    b.Navigation("Size");

                    b.Navigation("Urunler");
                });

            modelBuilder.Entity("IdentityServer4.Domain.Entities.TwoChildKategoriler", b =>
                {
                    b.HasOne("IdentityServer4.Domain.Entities.ThreeChildKategori", "ThreeChildKategori")
                        .WithMany("TwoChildKategorilers")
                        .HasForeignKey("ThreeChildKategoriID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ThreeChildKategori");
                });

            modelBuilder.Entity("IdentityServer4.Domain.Entities.Urunler", b =>
                {
                    b.HasOne("IdentityServer4.Domain.Entities.Kategoriler", "Kategori")
                        .WithMany("Urunlers")
                        .HasForeignKey("KategoriID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IdentityServer4.Domain.Entities.Markalar", "Markalar")
                        .WithMany("Urunlers")
                        .HasForeignKey("MarkalarID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kategori");

                    b.Navigation("Markalar");
                });

            modelBuilder.Entity("IdentityServer4.Domain.Entities.Cinsiyet", b =>
                {
                    b.Navigation("OneChildRelationshipCinsiyets");
                });

            modelBuilder.Entity("IdentityServer4.Domain.Entities.Color", b =>
                {
                    b.Navigation("Stocks");
                });

            modelBuilder.Entity("IdentityServer4.Domain.Entities.Kategoriler", b =>
                {
                    b.Navigation("MarkaOneChildKategoriToManies");

                    b.Navigation("Urunlers");
                });

            modelBuilder.Entity("IdentityServer4.Domain.Entities.Kullanicilar", b =>
                {
                    b.Navigation("RoleKullanicilarManyToManies");
                });

            modelBuilder.Entity("IdentityServer4.Domain.Entities.Markalar", b =>
                {
                    b.Navigation("MarkaOneChildKategoriToManies");

                    b.Navigation("Urunlers");
                });

            modelBuilder.Entity("IdentityServer4.Domain.Entities.OneChildKategoriler", b =>
                {
                    b.Navigation("Kategorilers");

                    b.Navigation("OneChildRelationshipCinsiyets");
                });

            modelBuilder.Entity("IdentityServer4.Domain.Entities.Role", b =>
                {
                    b.Navigation("RoleKullanicilarManyToManies");
                });

            modelBuilder.Entity("IdentityServer4.Domain.Entities.Size", b =>
                {
                    b.Navigation("Stocks");
                });

            modelBuilder.Entity("IdentityServer4.Domain.Entities.ThreeChildKategori", b =>
                {
                    b.Navigation("OneChildKategorilers");

                    b.Navigation("TwoChildKategorilers");
                });

            modelBuilder.Entity("IdentityServer4.Domain.Entities.TwoChildKategoriler", b =>
                {
                    b.Navigation("OneChildKategorilers");
                });

            modelBuilder.Entity("IdentityServer4.Domain.Entities.Urunler", b =>
                {
                    b.Navigation("ProductDetail")
                        .IsRequired();

                    b.Navigation("Stocks");
                });
#pragma warning restore 612, 618
        }
    }
}
