﻿// <auto-generated />
using System;
using DAL.RoboSalesSoftWare.ApplicationDbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DAL.RoboSalesSoftWare.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DAL.RoboSalesSoftWare.Entities.MarketData", b =>
                {
                    b.Property<int>("MarketCode")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MarketCode"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ArabicName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MarketSerialCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShopNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telephone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MarketCode");

                    b.ToTable("MarketDatas");
                });

            modelBuilder.Entity("DAL.RoboSalesSoftWare.Entities.Receipt", b =>
                {
                    b.Property<int>("ReceiptCode")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReceiptCode"));

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModificationDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("marketCode")
                        .HasColumnType("int");

                    b.Property<decimal>("price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ReceiptCode");

                    b.ToTable("Receipts");
                });

            modelBuilder.Entity("DAL.RoboSalesSoftWare.Entities.ReceiptDetails", b =>
                {
                    b.Property<int>("ReceiptDetailsCode")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReceiptDetailsCode"));

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<decimal?>("Quantity")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ReceiptCode")
                        .HasColumnType("int");

                    b.Property<int>("typeCode")
                        .HasColumnType("int");

                    b.HasKey("ReceiptDetailsCode");

                    b.HasIndex("ReceiptCode");

                    b.HasIndex("typeCode");

                    b.ToTable("ReceiptDetailss");
                });

            modelBuilder.Entity("DAL.RoboSalesSoftWare.Entities.User", b =>
                {
                    b.Property<int>("UserCode")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserCode"));

                    b.Property<string>("PassWord")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserCode");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DAL.RoboSalesSoftWare.Entities.VegatablesType", b =>
                {
                    b.Property<int>("TypeCode")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TypeCode"));

                    b.Property<string>("Arabic_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cover")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ModificationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("ReceiptCode")
                        .HasColumnType("int");

                    b.HasKey("TypeCode");

                    b.HasIndex("ReceiptCode");

                    b.ToTable("VegatablesTypes");
                });

            modelBuilder.Entity("DAL.RoboSalesSoftWare.Entities.ReceiptDetails", b =>
                {
                    b.HasOne("DAL.RoboSalesSoftWare.Entities.Receipt", "ReceiptNavigation")
                        .WithMany()
                        .HasForeignKey("ReceiptCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.RoboSalesSoftWare.Entities.VegatablesType", "VegatablesTypeNavigation")
                        .WithMany()
                        .HasForeignKey("typeCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ReceiptNavigation");

                    b.Navigation("VegatablesTypeNavigation");
                });

            modelBuilder.Entity("DAL.RoboSalesSoftWare.Entities.VegatablesType", b =>
                {
                    b.HasOne("DAL.RoboSalesSoftWare.Entities.Receipt", null)
                        .WithMany("VegatablesType")
                        .HasForeignKey("ReceiptCode");
                });

            modelBuilder.Entity("DAL.RoboSalesSoftWare.Entities.Receipt", b =>
                {
                    b.Navigation("VegatablesType");
                });
#pragma warning restore 612, 618
        }
    }
}