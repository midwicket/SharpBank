﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SharpBank.API.Models;

namespace SharpBank.API.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20211008144932_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SharpBank.Models.Account", b =>
                {
                    b.Property<string>("AccountNumber")
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("Balance")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AccountNumber");

                    b.ToTable("Account");

                    b.HasData(
                        new
                        {
                            AccountNumber = "001",
                            Balance = 0m,
                            UserName = "Shriram"
                        },
                        new
                        {
                            AccountNumber = "201",
                            Balance = 0m,
                            UserName = "Vijith"
                        },
                        new
                        {
                            AccountNumber = "301",
                            Balance = 0m,
                            UserName = "Sagar"
                        },
                        new
                        {
                            AccountNumber = "401",
                            Balance = 0m,
                            UserName = "Balaji"
                        });
                });

            modelBuilder.Entity("SharpBank.Models.Bank", b =>
                {
                    b.Property<string>("IFSC")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("BankName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IFSC");

                    b.ToTable("Bank");

                    b.HasData(
                        new
                        {
                            IFSC = "001",
                            BankName = "Yaxis"
                        },
                        new
                        {
                            IFSC = "002",
                            BankName = "YesBI"
                        },
                        new
                        {
                            IFSC = "003",
                            BankName = "FDHC"
                        },
                        new
                        {
                            IFSC = "004",
                            BankName = "YCYCY"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}