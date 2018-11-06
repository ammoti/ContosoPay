﻿// <auto-generated />
using System;
using Contoso.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Contoso.API.Migrations
{
    [DbContext(typeof(ContosoContext))]
    [Migration("20181104123105_Second")]
    partial class Second
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Contoso.Model.Entities.Operation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new DateTime(2018, 11, 4, 15, 31, 4, 595, DateTimeKind.Local));

                    b.Property<int>("Discount");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsDeleted");

                    b.Property<int>("OperationType");

                    b.Property<int>("SellerId");

                    b.Property<DateTime>("UpdateDate");

                    b.HasKey("Id");

                    b.HasIndex("SellerId");

                    b.ToTable("Operations");
                });

            modelBuilder.Entity("Contoso.Model.Entities.Sale", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CardNo");

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new DateTime(2018, 11, 4, 15, 31, 4, 585, DateTimeKind.Local));

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsDeleted");

                    b.Property<double>("Price");

                    b.Property<int>("ProcessType");

                    b.Property<int>("SellerId");

                    b.Property<DateTime>("UpdateDate");

                    b.HasKey("Id");

                    b.HasIndex("SellerId");

                    b.ToTable("Sales");
                });

            modelBuilder.Entity("Contoso.Model.Entities.Seller", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new DateTime(2018, 11, 4, 15, 31, 4, 584, DateTimeKind.Local));

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("MaxRange");

                    b.Property<string>("MinRange");

                    b.Property<string>("Name");

                    b.Property<DateTime>("UpdateDate");

                    b.HasKey("Id");

                    b.ToTable("Sellers");
                });

            modelBuilder.Entity("Contoso.Model.Entities.Users", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new DateTime(2018, 11, 4, 15, 31, 4, 578, DateTimeKind.Local));

                    b.Property<string>("Email");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Name");

                    b.Property<string>("Password");

                    b.Property<string>("Surname");

                    b.Property<DateTime>("UpdateDate");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Contoso.Model.Entities.Operation", b =>
                {
                    b.HasOne("Contoso.Model.Entities.Seller", "Seller")
                        .WithMany("OperationCreated")
                        .HasForeignKey("SellerId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Contoso.Model.Entities.Sale", b =>
                {
                    b.HasOne("Contoso.Model.Entities.Seller", "Seller")
                        .WithMany("SaleCreated")
                        .HasForeignKey("SellerId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
