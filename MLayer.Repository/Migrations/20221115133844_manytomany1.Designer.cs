﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NLayer.Repository;

#nullable disable

namespace NLayer.Repository.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20221115133844_manytomany1")]
    partial class manytomany1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MusteriMusteriTipi", b =>
                {
                    b.Property<int>("MusteriTipleriId")
                        .HasColumnType("int");

                    b.Property<int>("MusterilerId")
                        .HasColumnType("int");

                    b.HasKey("MusteriTipleriId", "MusterilerId");

                    b.HasIndex("MusterilerId");

                    b.ToTable("MusteriMusteriTipi");
                });

            modelBuilder.Entity("NLayer.Core.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Categories", (string)null);
                });

            modelBuilder.Entity("NLayer.Core.Entities.Banka", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Adi")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Bankalar");
                });

            modelBuilder.Entity("NLayer.Core.Entities.DovizTipi", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Adi")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("DovizTipleri");
                });

            modelBuilder.Entity("NLayer.Core.Entities.Hareket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Aciklama")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("HareketTipiId")
                        .HasColumnType("int");

                    b.Property<int?>("HesapId")
                        .HasColumnType("int");

                    b.Property<decimal>("Tutar")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("HareketTipiId");

                    b.HasIndex("HesapId");

                    b.ToTable("Hareketler");
                });

            modelBuilder.Entity("NLayer.Core.Entities.HareketTipi", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Adi")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("HareketTipleri");
                });

            modelBuilder.Entity("NLayer.Core.Entities.Hesap", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("DovizTipiId")
                        .HasColumnType("int");

                    b.Property<int?>("HesapTipiId")
                        .HasColumnType("int");

                    b.Property<string>("Kodu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MusteriId")
                        .HasColumnType("int");

                    b.Property<int?>("SubeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DovizTipiId");

                    b.HasIndex("HesapTipiId");

                    b.HasIndex("MusteriId");

                    b.HasIndex("SubeId");

                    b.ToTable("Hesaplar");
                });

            modelBuilder.Entity("NLayer.Core.Entities.HesapTipi", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Adi")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("HesapTipleri");
                });

            modelBuilder.Entity("NLayer.Core.Entities.Lokasyon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Adi")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Lokasyonlar");
                });

            modelBuilder.Entity("NLayer.Core.Entities.Musteri", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AdiSoyadi")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Musteriler");
                });

            modelBuilder.Entity("NLayer.Core.Entities.MusteriTipi", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Adi")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("MusteriTipi");
                });

            modelBuilder.Entity("NLayer.Core.Entities.Sube", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Adi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("BankaId")
                        .HasColumnType("int");

                    b.Property<int?>("LokasyonId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BankaId");

                    b.HasIndex("LokasyonId");

                    b.ToTable("Subeler");
                });

            modelBuilder.Entity("NLayer.Core.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products", (string)null);
                });

            modelBuilder.Entity("NLayer.Core.ProductFeature", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Height")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Width")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId")
                        .IsUnique();

                    b.ToTable("ProductFeatures");
                });

            modelBuilder.Entity("MusteriMusteriTipi", b =>
                {
                    b.HasOne("NLayer.Core.Entities.MusteriTipi", null)
                        .WithMany()
                        .HasForeignKey("MusteriTipleriId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NLayer.Core.Entities.Musteri", null)
                        .WithMany()
                        .HasForeignKey("MusterilerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("NLayer.Core.Entities.Hareket", b =>
                {
                    b.HasOne("NLayer.Core.Entities.HareketTipi", "HareketTipi")
                        .WithMany()
                        .HasForeignKey("HareketTipiId");

                    b.HasOne("NLayer.Core.Entities.Hesap", null)
                        .WithMany("Hareketler")
                        .HasForeignKey("HesapId");

                    b.Navigation("HareketTipi");
                });

            modelBuilder.Entity("NLayer.Core.Entities.Hesap", b =>
                {
                    b.HasOne("NLayer.Core.Entities.DovizTipi", "DovizTipi")
                        .WithMany()
                        .HasForeignKey("DovizTipiId");

                    b.HasOne("NLayer.Core.Entities.HesapTipi", "HesapTipi")
                        .WithMany()
                        .HasForeignKey("HesapTipiId");

                    b.HasOne("NLayer.Core.Entities.Musteri", null)
                        .WithMany("Hesaplar")
                        .HasForeignKey("MusteriId");

                    b.HasOne("NLayer.Core.Entities.Sube", null)
                        .WithMany("Hesaplar")
                        .HasForeignKey("SubeId");

                    b.Navigation("DovizTipi");

                    b.Navigation("HesapTipi");
                });

            modelBuilder.Entity("NLayer.Core.Entities.Sube", b =>
                {
                    b.HasOne("NLayer.Core.Entities.Banka", null)
                        .WithMany("Subeler")
                        .HasForeignKey("BankaId");

                    b.HasOne("NLayer.Core.Entities.Lokasyon", "Lokasyon")
                        .WithMany()
                        .HasForeignKey("LokasyonId");

                    b.Navigation("Lokasyon");
                });

            modelBuilder.Entity("NLayer.Core.Product", b =>
                {
                    b.HasOne("NLayer.Core.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("NLayer.Core.ProductFeature", b =>
                {
                    b.HasOne("NLayer.Core.Product", "Product")
                        .WithOne("ProductFeature")
                        .HasForeignKey("NLayer.Core.ProductFeature", "ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("NLayer.Core.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("NLayer.Core.Entities.Banka", b =>
                {
                    b.Navigation("Subeler");
                });

            modelBuilder.Entity("NLayer.Core.Entities.Hesap", b =>
                {
                    b.Navigation("Hareketler");
                });

            modelBuilder.Entity("NLayer.Core.Entities.Musteri", b =>
                {
                    b.Navigation("Hesaplar");
                });

            modelBuilder.Entity("NLayer.Core.Entities.Sube", b =>
                {
                    b.Navigation("Hesaplar");
                });

            modelBuilder.Entity("NLayer.Core.Product", b =>
                {
                    b.Navigation("ProductFeature");
                });
#pragma warning restore 612, 618
        }
    }
}
