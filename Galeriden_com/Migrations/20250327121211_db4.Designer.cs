﻿// <auto-generated />
using System;
using Galeriden_com.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Galeriden_com.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20250327121211_db4")]
    partial class db4
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Galeriden_com.Models.Arac", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Fiyat")
                        .HasColumnType("float");

                    b.Property<string>("Marka")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Model")
                        .HasColumnType("int");

                    b.Property<string>("Plaka")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Arac");
                });

            modelBuilder.Entity("Galeriden_com.Models.Musteri", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Adi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Adres")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Soyadi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefon")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Musteri");
                });

            modelBuilder.Entity("Galeriden_com.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("SurName")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Galeriden_com.Models.SatinAlma", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("AlimFiyati")
                        .HasColumnType("float");

                    b.Property<DateTime>("AlimFiyatiDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("AracID")
                        .HasColumnType("int");

                    b.Property<int>("MusteriID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AracID");

                    b.HasIndex("MusteriID");

                    b.ToTable("SatinAlma");
                });

            modelBuilder.Entity("Galeriden_com.Models.Satis", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AracID")
                        .HasColumnType("int");

                    b.Property<int>("MusteriID")
                        .HasColumnType("int");

                    b.Property<double>("SatisFiyati")
                        .HasColumnType("float");

                    b.Property<DateTime>("SatisFiyatiDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AracID");

                    b.HasIndex("MusteriID");

                    b.ToTable("Satis");
                });

            modelBuilder.Entity("Galeriden_com.Models.SatinAlma", b =>
                {
                    b.HasOne("Galeriden_com.Models.Arac", "arac")
                        .WithMany("SatinAlma")
                        .HasForeignKey("AracID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Galeriden_com.Models.Musteri", "musteri")
                        .WithMany("SatinAlma")
                        .HasForeignKey("MusteriID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("arac");

                    b.Navigation("musteri");
                });

            modelBuilder.Entity("Galeriden_com.Models.Satis", b =>
                {
                    b.HasOne("Galeriden_com.Models.Arac", "arac")
                        .WithMany()
                        .HasForeignKey("AracID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Galeriden_com.Models.Musteri", "musteri")
                        .WithMany()
                        .HasForeignKey("MusteriID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("arac");

                    b.Navigation("musteri");
                });

            modelBuilder.Entity("Galeriden_com.Models.Arac", b =>
                {
                    b.Navigation("SatinAlma");
                });

            modelBuilder.Entity("Galeriden_com.Models.Musteri", b =>
                {
                    b.Navigation("SatinAlma");
                });
#pragma warning restore 612, 618
        }
    }
}
