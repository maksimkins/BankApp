﻿// <auto-generated />
using System;
using Bank.Repositories.EF_Core_Repositories.DbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Bank.Migrations
{
    [DbContext(typeof(AllClientsDbContext))]
    [Migration("20231005160757_add some things AllDbContext")]
    partial class addsomethingsAllDbContext
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Bank.Models.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Account")
                        .HasColumnType("float");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Login")
                        .IsUnique();

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("Bank.Models.DebtorClient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("DebtToReturn")
                        .HasColumnType("float");

                    b.Property<int>("LoanClientId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LoanClientId")
                        .IsUnique();

                    b.ToTable("DebtorClients");
                });

            modelBuilder.Entity("Bank.Models.LoanClient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<double>("Loan")
                        .HasColumnType("float");

                    b.Property<DateTime>("LoanGotDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Month")
                        .HasColumnType("int");

                    b.Property<int>("MonthDuration")
                        .HasColumnType("int");

                    b.Property<double>("PaidPartOfLoan")
                        .HasColumnType("float");

                    b.Property<int>("Perecents")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClientId")
                        .IsUnique();

                    b.ToTable("LoanClients");
                });

            modelBuilder.Entity("Bank.Models.DebtorClient", b =>
                {
                    b.HasOne("Bank.Models.LoanClient", "LoanClient")
                        .WithMany()
                        .HasForeignKey("LoanClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LoanClient");
                });

            modelBuilder.Entity("Bank.Models.LoanClient", b =>
                {
                    b.HasOne("Bank.Models.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });
#pragma warning restore 612, 618
        }
    }
}
