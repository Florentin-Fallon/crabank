﻿// <auto-generated />
using System;
using Crabank.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Crabank.Migrations
{
    [DbContext(typeof(BankDbContext))]
    [Migration("20241114141556_Cards")]
    partial class Cards
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.8");

            modelBuilder.Entity("Crabank.Database.Models.BankAccount", b =>
                {
                    b.Property<long>("Bban")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("AccountCreationDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("AdvisorId")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Amount")
                        .HasColumnType("REAL");

                    b.Property<double>("CreditLimit")
                        .HasColumnType("REAL");

                    b.Property<string>("Currency")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Iban")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("OwnerName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Type")
                        .HasColumnType("INTEGER");

                    b.HasKey("Bban");

                    b.HasIndex("AdvisorId");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("Crabank.Database.Models.BankAdvisor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Advisors");
                });

            modelBuilder.Entity("Crabank.Database.Models.BankCard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long>("AccountBban")
                        .HasColumnType("INTEGER");

                    b.Property<int>("AccountId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("Network")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Numbers")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<short>("SecurityCode")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Style")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Type")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("AccountBban");

                    b.ToTable("Cards");
                });

            modelBuilder.Entity("Crabank.Database.Models.BankTransaction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<double>("Amount")
                        .HasColumnType("REAL");

                    b.Property<string>("Currency")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<long>("FromAccountBban")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Label")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<long>("ToAccountBban")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("FromAccountBban");

                    b.HasIndex("ToAccountBban");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("Crabank.Database.Models.BankAccount", b =>
                {
                    b.HasOne("Crabank.Database.Models.BankAdvisor", "Advisor")
                        .WithMany()
                        .HasForeignKey("AdvisorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Advisor");
                });

            modelBuilder.Entity("Crabank.Database.Models.BankCard", b =>
                {
                    b.HasOne("Crabank.Database.Models.BankAccount", "Account")
                        .WithMany("Cards")
                        .HasForeignKey("AccountBban")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("Crabank.Database.Models.BankTransaction", b =>
                {
                    b.HasOne("Crabank.Database.Models.BankAccount", "FromAccount")
                        .WithMany()
                        .HasForeignKey("FromAccountBban")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Crabank.Database.Models.BankAccount", "ToAccount")
                        .WithMany()
                        .HasForeignKey("ToAccountBban")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FromAccount");

                    b.Navigation("ToAccount");
                });

            modelBuilder.Entity("Crabank.Database.Models.BankAccount", b =>
                {
                    b.Navigation("Cards");
                });
#pragma warning restore 612, 618
        }
    }
}
