﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Vtorproekt.Data;

#nullable disable

namespace Vtorproekt.Migrations
{
    [DbContext(typeof(VtorproektContext))]
    [Migration("20230406104617_property MaterialId in Tax model")]
    partial class propertyMaterialIdinTaxmodel
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Vtorproekt.Models.Bale", b =>
                {
                    b.Property<int>("BaleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BaleId"));

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int?>("MaterialId")
                        .HasColumnType("int");

                    b.Property<bool>("isReady")
                        .HasColumnType("bit");

                    b.HasKey("BaleId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("MaterialId");

                    b.ToTable("Bales");
                });

            modelBuilder.Entity("Vtorproekt.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeId"));

                    b.Property<string>("EmployeeName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("EmployeeId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Vtorproekt.Models.Material", b =>
                {
                    b.Property<int>("MaterialId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaterialId"));

                    b.Property<string>("MaterialName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaterialId");

                    b.ToTable("Materials");
                });

            modelBuilder.Entity("Vtorproekt.Models.Production", b =>
                {
                    b.Property<int>("ProductionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductionId"));

                    b.Property<int>("BaleId")
                        .HasColumnType("int");

                    b.Property<int?>("Employee")
                        .HasColumnType("int");

                    b.Property<int?>("MaterialId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ProduceDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("StorageId")
                        .HasColumnType("int");

                    b.Property<int?>("Tax")
                        .HasColumnType("int");

                    b.Property<int>("TaxId")
                        .HasColumnType("int");

                    b.Property<double>("Weight")
                        .HasColumnType("float");

                    b.Property<int>("WorkTypeId")
                        .HasColumnType("int");

                    b.HasKey("ProductionId");

                    b.HasIndex("Employee");

                    b.HasIndex("MaterialId");

                    b.HasIndex("StorageId");

                    b.HasIndex("Tax");

                    b.HasIndex("WorkTypeId");

                    b.ToTable("Productions");
                });

            modelBuilder.Entity("Vtorproekt.Models.Storage", b =>
                {
                    b.Property<int>("StorageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StorageId"));

                    b.Property<string>("StorageAdress")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("StorageId");

                    b.ToTable("Storages");
                });

            modelBuilder.Entity("Vtorproekt.Models.Tax", b =>
                {
                    b.Property<int>("TaxId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TaxId"));

                    b.Property<DateTime>("DateTax")
                        .HasColumnType("datetime2");

                    b.Property<double>("Limit1")
                        .HasColumnType("float");

                    b.Property<double>("Limit2")
                        .HasColumnType("float");

                    b.Property<double>("Limit3")
                        .HasColumnType("float");

                    b.Property<int>("MaterialId")
                        .HasColumnType("int");

                    b.Property<double>("Multi1")
                        .HasColumnType("float");

                    b.Property<double>("Multi2")
                        .HasColumnType("float");

                    b.Property<double>("Multi3")
                        .HasColumnType("float");

                    b.Property<double>("TaxValue")
                        .HasColumnType("float");

                    b.Property<int>("WorkTypeId")
                        .HasColumnType("int");

                    b.HasKey("TaxId");

                    b.HasIndex("WorkTypeId");

                    b.ToTable("Taxes");
                });

            modelBuilder.Entity("Vtorproekt.Models.WorkType", b =>
                {
                    b.Property<int>("WorkTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WorkTypeId"));

                    b.Property<int>("MaterialId")
                        .HasColumnType("int");

                    b.Property<string>("WorkTypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("WorkTypeId");

                    b.HasIndex("MaterialId");

                    b.ToTable("WorkTypes");
                });

            modelBuilder.Entity("Vtorproekt.Models.Bale", b =>
                {
                    b.HasOne("Vtorproekt.Models.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId");

                    b.HasOne("Vtorproekt.Models.Material", "Material")
                        .WithMany()
                        .HasForeignKey("MaterialId");

                    b.Navigation("Employee");

                    b.Navigation("Material");
                });

            modelBuilder.Entity("Vtorproekt.Models.Production", b =>
                {
                    b.HasOne("Vtorproekt.Models.Employee", "Producer")
                        .WithMany()
                        .HasForeignKey("Employee");

                    b.HasOne("Vtorproekt.Models.Material", "Material")
                        .WithMany()
                        .HasForeignKey("MaterialId");

                    b.HasOne("Vtorproekt.Models.Storage", "Storage")
                        .WithMany()
                        .HasForeignKey("StorageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Vtorproekt.Models.Tax", "TaxValue")
                        .WithMany("Productions")
                        .HasForeignKey("Tax");

                    b.HasOne("Vtorproekt.Models.WorkType", "WorkType")
                        .WithMany()
                        .HasForeignKey("WorkTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Material");

                    b.Navigation("Producer");

                    b.Navigation("Storage");

                    b.Navigation("TaxValue");

                    b.Navigation("WorkType");
                });

            modelBuilder.Entity("Vtorproekt.Models.Tax", b =>
                {
                    b.HasOne("Vtorproekt.Models.WorkType", "WorkType")
                        .WithMany()
                        .HasForeignKey("WorkTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("WorkType");
                });

            modelBuilder.Entity("Vtorproekt.Models.WorkType", b =>
                {
                    b.HasOne("Vtorproekt.Models.Material", "Material")
                        .WithMany()
                        .HasForeignKey("MaterialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Material");
                });

            modelBuilder.Entity("Vtorproekt.Models.Tax", b =>
                {
                    b.Navigation("Productions");
                });
#pragma warning restore 612, 618
        }
    }
}
