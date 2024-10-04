using Crabank.Database;
using Crabank.Database.Dto;
using Crabank.Database.Models;
using Crabank.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Crabank.Controllers;

[ApiController]
public class AccountsController : ControllerBase
{
    [HttpGet("/accounts")]
    public BankAccount[] GetAllAccounts()
    {
        using BankDbContext db = new();

        return db.Accounts
            .Include(account => account.Advisor)
            .Take(10)
            .ToArray();
    }
    
    [HttpGet("/account/{bban}")]
    public object GetAccount(long bban)
    {
        using BankDbContext db = new();
        BankAccount? account = db.Accounts.Find(bban);

        if (account == null) return NotFound();
        
        return Ok(account);
    }
    
    /// <summary>
    /// Get all the accounts' transactions
    /// </summary>
    /// <param name="bban"></param>
    /// <returns></returns>
    [HttpGet("/account/{bban}/transactions")]
    public object GetAccountTransactions(long bban)
    {
        using BankDbContext db = new();
        BankAccount? account = db.Accounts.Find(bban);
        BankTransaction[] transactions = db.Transactions
            .Include(transaction => transaction.FromAccount)
            .Include(transaction => transaction.ToAccount)
            .Where(transaction => transaction.FromAccount == account || transaction.ToAccount == account)
            .ToArray();
        List<TransactionResultDto> transactionResults = [];

        foreach (BankTransaction transaction in transactions)
        {
            transactionResults.Add(new TransactionResultDto()
            {
                Type = (transaction.FromAccount == account ? TransactionType.Outwards : TransactionType.Inwards).ToString().ToLower(),
                Status = transaction.Status.ToString().ToLower(),
                Label = transaction.Label,
                Currency = transaction.Currency,
                Account = transaction.FromAccount == account ? transaction.ToAccount : transaction.FromAccount,
                Amount = transaction.Amount
            });
        }

        if (account == null) return NotFound();
        
        return Ok(transactionResults);
    }
    
    [HttpPost("/accounts")]
    public object CreateAccount([FromBody] AccountCreationDto dto)
    {
        using BankDbContext db = new();

        if (string.IsNullOrWhiteSpace(dto.Name))
            return BadRequest("Invalid name");
        if (string.IsNullOrWhiteSpace(dto.OwnerName) || dto.OwnerName.Length < 4)
            return BadRequest("Invalid owner name (must be at least 4 characters long)");

        long bban = CrabankUtilities.GenerateBban();
        BankAccount account = new BankAccount
        {
            Name = dto.Name,
            OwnerName = dto.OwnerName,
            CreditLimit = Math.Max(1000, dto.CreditLimit ?? 1000),
            AccountCreationDate = DateTime.Now,
            Advisor = db.Advisors.Find(dto.AdvisorId ?? 1)!,
            Amount = 0,
            Currency = dto.Currency ?? "EUR",
            Bban = bban,
            Iban = CrabankUtilities.GenerateIban(bban, "FR", dto.OwnerName)
        };
        db.Add(account);
        db.SaveChanges();

        return Created($"/account/{bban}", account);
    }
}