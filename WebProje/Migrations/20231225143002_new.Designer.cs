﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebProje.Models;

#nullable disable

namespace WebProje.Migrations
{
    [DbContext(typeof(HastaneContext))]
    [Migration("20231225143002_new")]
    partial class @new
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebProje.Models.Admin", b =>
                {
                    b.Property<int>("AdminId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AdminId"));

                    b.Property<string>("Isim")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RolId")
                        .HasColumnType("int");

                    b.Property<string>("Soyisim")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AdminId");

                    b.HasIndex("RolId");

                    b.ToTable("Adminler");
                });

            modelBuilder.Entity("WebProje.Models.Bolum", b =>
                {
                    b.Property<int>("BolumId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BolumId"));

                    b.Property<string>("BolumAdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BolumId");

                    b.ToTable("Bolumler");
                });

            modelBuilder.Entity("WebProje.Models.CalismaSaatleri", b =>
                {
                    b.Property<int>("CalismaSaatleriId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CalismaSaatleriId"));

                    b.Property<TimeSpan>("Baslangic")
                        .HasColumnType("time");

                    b.Property<TimeSpan>("Bitis")
                        .HasColumnType("time");

                    b.Property<int>("DoktorId")
                        .HasColumnType("int");

                    b.Property<string>("Gun")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CalismaSaatleriId");

                    b.HasIndex("DoktorId");

                    b.ToTable("CalismaSaatleri");
                });

            modelBuilder.Entity("WebProje.Models.Doktor", b =>
                {
                    b.Property<int>("DoktorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DoktorId"));

                    b.Property<int>("BolumId")
                        .HasColumnType("int");

                    b.Property<string>("Isim")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RolId")
                        .HasColumnType("int");

                    b.Property<string>("Soyisim")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TC")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.HasKey("DoktorId");

                    b.HasIndex("BolumId");

                    b.HasIndex("RolId");

                    b.ToTable("Doktorlar");
                });

            modelBuilder.Entity("WebProje.Models.Hasta", b =>
                {
                    b.Property<int>("HastaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HastaId"));

                    b.Property<string>("Cinsiyet")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Isim")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RolId")
                        .HasColumnType("int");

                    b.Property<string>("Soyisim")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TC")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("Telefon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("HastaId");

                    b.HasIndex("RolId");

                    b.ToTable("Hastalar");
                });

            modelBuilder.Entity("WebProje.Models.Randevu", b =>
                {
                    b.Property<int>("RandevuId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RandevuId"));

                    b.Property<int>("DoktorId")
                        .HasColumnType("int");

                    b.Property<int?>("HastaId")
                        .HasColumnType("int");

                    b.Property<bool>("IsOpen")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Tarih")
                        .HasColumnType("datetime2");

                    b.HasKey("RandevuId");

                    b.HasIndex("DoktorId");

                    b.HasIndex("HastaId");

                    b.ToTable("Randevular");
                });

            modelBuilder.Entity("WebProje.Models.Roles", b =>
                {
                    b.Property<int>("RolId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RolId"));

                    b.Property<string>("RolAdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RolId");

                    b.ToTable("Roller");
                });

            modelBuilder.Entity("WebProje.Models.Admin", b =>
                {
                    b.HasOne("WebProje.Models.Roles", "Rol")
                        .WithMany()
                        .HasForeignKey("RolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Rol");
                });

            modelBuilder.Entity("WebProje.Models.CalismaSaatleri", b =>
                {
                    b.HasOne("WebProje.Models.Doktor", "Doktor")
                        .WithMany()
                        .HasForeignKey("DoktorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doktor");
                });

            modelBuilder.Entity("WebProje.Models.Doktor", b =>
                {
                    b.HasOne("WebProje.Models.Bolum", "Bolum")
                        .WithMany()
                        .HasForeignKey("BolumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebProje.Models.Roles", "Rol")
                        .WithMany()
                        .HasForeignKey("RolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bolum");

                    b.Navigation("Rol");
                });

            modelBuilder.Entity("WebProje.Models.Hasta", b =>
                {
                    b.HasOne("WebProje.Models.Roles", "Rol")
                        .WithMany()
                        .HasForeignKey("RolId");

                    b.Navigation("Rol");
                });

            modelBuilder.Entity("WebProje.Models.Randevu", b =>
                {
                    b.HasOne("WebProje.Models.Doktor", "Doktor")
                        .WithMany()
                        .HasForeignKey("DoktorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebProje.Models.Hasta", "Hasta")
                        .WithMany("Randevular")
                        .HasForeignKey("HastaId");

                    b.Navigation("Doktor");

                    b.Navigation("Hasta");
                });

            modelBuilder.Entity("WebProje.Models.Hasta", b =>
                {
                    b.Navigation("Randevular");
                });
#pragma warning restore 612, 618
        }
    }
}
