using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Crabank.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Iban = table.Column<string>(type: "TEXT", nullable: false),
                    AccountCreationDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Amount = table.Column<double>(type: "REAL", nullable: false),
                    CreditLimit = table.Column<double>(type: "REAL", nullable: false),
                    BankAdvisorName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Iban);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Amount = table.Column<double>(type: "REAL", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    FromAccountIban = table.Column<string>(type: "TEXT", nullable: false),
                    ToAccountIban = table.Column<string>(type: "TEXT", nullable: false),
                    Label = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_Accounts_FromAccountIban",
                        column: x => x.FromAccountIban,
                        principalTable: "Accounts",
                        principalColumn: "Iban",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transactions_Accounts_ToAccountIban",
                        column: x => x.ToAccountIban,
                        principalTable: "Accounts",
                        principalColumn: "Iban",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_FromAccountIban",
                table: "Transactions",
                column: "FromAccountIban");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_ToAccountIban",
                table: "Transactions",
                column: "ToAccountIban");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Accounts");
        }
    }
}
