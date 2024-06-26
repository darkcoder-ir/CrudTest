﻿// <auto-generated />
using System;
using Mc2.Crud.Persistanse.DbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Mc2.Crud.Persistanse.Migrations
{
    [DbContext(typeof(MyAppContext))]
    [Migration("20240315190629_DDDConfigg2")]
    partial class DDDConfigg2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Mc2.CrudTest.Core.Domain.Entities.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("FullName")
                        .HasComputedColumnSql("CONCAT(FirstName, '-', LastName, '-', DateOfBirth)");

                    b.HasKey("Id");

                    b.HasIndex("FullName")
                        .IsUnique();

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Mc2.CrudTest.Core.Domain.Entities.Customer", b =>
                {
                    b.OwnsOne("Mc2.CrudTest.Core.Domain.ValueObjects.AccountNumber", "AccountNumber", b1 =>
                        {
                            b1.Property<Guid>("CustomerId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("AccountNumber");

                            b1.HasKey("CustomerId");

                            b1.ToTable("Customers");

                            b1.WithOwner()
                                .HasForeignKey("CustomerId");
                        });

                    b.OwnsOne("Mc2.CrudTest.Core.Domain.ValueObjects.DateOfBirth", "DateOfBirth", b1 =>
                        {
                            b1.Property<Guid>("CustomerId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(10)
                                .HasColumnType("nvarchar(10)")
                                .HasColumnName("DateOfBirth");

                            b1.HasKey("CustomerId");

                            b1.ToTable("Customers");

                            b1.WithOwner()
                                .HasForeignKey("CustomerId");
                        });

                    b.OwnsOne("Mc2.CrudTest.Core.Domain.ValueObjects.Email", "Email", b1 =>
                        {
                            b1.Property<Guid>("CustomerId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(256)
                                .HasColumnType("nvarchar(256)")
                                .HasColumnName("Email");

                            b1.HasKey("CustomerId");

                            b1.ToTable("Customers");

                            b1.WithOwner()
                                .HasForeignKey("CustomerId");
                        });

                    b.OwnsOne("Mc2.CrudTest.Core.Domain.ValueObjects.FirstName", "FirstName", b1 =>
                        {
                            b1.Property<Guid>("CustomerId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("nvarchar(50)")
                                .HasColumnName("FirstName");

                            b1.HasKey("CustomerId");

                            b1.ToTable("Customers");

                            b1.WithOwner()
                                .HasForeignKey("CustomerId");
                        });

                    b.OwnsOne("Mc2.CrudTest.Core.Domain.ValueObjects.LastName", "LastName", b1 =>
                        {
                            b1.Property<Guid>("CustomerId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("nvarchar(50)")
                                .HasColumnName("LastName");

                            b1.HasKey("CustomerId");

                            b1.ToTable("Customers");

                            b1.WithOwner()
                                .HasForeignKey("CustomerId");
                        });

                    b.OwnsOne("Mc2.CrudTest.Core.Domain.ValueObjects.PhoneNumber", "PhoneNumber", b1 =>
                        {
                            b1.Property<Guid>("CustomerId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<decimal>("Value")
                                .HasMaxLength(13)
                                .HasColumnType("decimal(20,0)")
                                .HasColumnName("PhoneNumber");

                            b1.HasKey("CustomerId");

                            b1.ToTable("Customers");

                            b1.WithOwner()
                                .HasForeignKey("CustomerId");
                        });

                    b.Navigation("AccountNumber")
                        .IsRequired();

                    b.Navigation("DateOfBirth")
                        .IsRequired();

                    b.Navigation("Email")
                        .IsRequired();

                    b.Navigation("FirstName")
                        .IsRequired();

                    b.Navigation("LastName")
                        .IsRequired();

                    b.Navigation("PhoneNumber")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
