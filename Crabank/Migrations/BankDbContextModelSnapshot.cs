﻿// <auto-generated />
using System;
using Crabank.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Crabank.Migrations
{
    [DbContext(typeof(BankDbContext))]
    partial class BankDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.8");

            modelBuilder.Entity("Crabank.Database.Models.BankAccount", b =>
                {
                    b.Property<string>("Iban")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("AccountCreationDate")
                        .HasColumnType("TEXT");

                    b.Property<double>("Amount")
                        .HasColumnType("REAL");

                    b.Property<string>("BankAdvisorName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("CreditLimit")
                        .HasColumnType("REAL");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Iban");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("Crabank.Database.Models.BankTransaction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<double>("Amount")
                        .HasColumnType("REAL");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<string>("FromAccountIban")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Label")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ToAccountIban")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("FromAccountIban");

                    b.HasIndex("ToAccountIban");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("Crabank.Database.Models.BankTransaction", b =>
                {
                    b.HasOne("Crabank.Database.Models.BankAccount", "FromAccount")
                        .WithMany()
                        .HasForeignKey("FromAccountIban")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Crabank.Database.Models.BankAccount", "ToAccount")
                        .WithMany()
                        .HasForeignKey("ToAccountIban")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FromAccount");

                    b.Navigation("ToAccount");
                });
#pragma warning restore 612, 618
        }
    }
}
