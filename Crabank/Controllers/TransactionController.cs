using System.Runtime.InteropServices;
using System.Web;
using Crabank.Database;
using Crabank.Database.Dto;
using Crabank.Database.Models;
using Crabank.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace Crabank.Controllers;

public class TransactionController : ControllerBase
{
    /// <summary>
    /// Get a transaction by its GUID
    /// </summary>
    /// <param name="guid"></param>
    /// <returns></returns>
    [HttpGet("/transactions/{guid:guid}")]
    public object GetTransactionById(Guid guid)
    {
        using BankDbContext db = new();

        BankTransaction? transaction = db.Transactions.Find(guid);
        if (transaction == null) return NotFound();

        return Ok(transaction);
    }
    
    /// <summary>
    /// Create a transaction from one account to another
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [HttpPost("/transactions")]
    public object CreateTransaction([FromBody] TransactionDto dto)
    {
        using BankDbContext db = new();

        if (string.IsNullOrWhiteSpace(dto.Label))
            return BadRequest("Invalid label");
        if (string.IsNullOrWhiteSpace(dto.Currency) || !Currencies.IsValid(dto.Currency))
            return BadRequest("Invalid currency, expected a currency like 'usd'");
        if (dto.Amount <= 0)
            return BadRequest("Invalid amount (superior than and not zero)");
        if (!CrabankUtilities.IsValidIban("FR", dto.FromIban))
            return BadRequest("Invalid source IBAN");
        if (!CrabankUtilities.IsValidIban("FR", dto.ToIban))
            return BadRequest("Invalid target IBAN");

        BankAccount? fromAccount = db.Accounts.FirstOrDefault(ac => ac.Iban == dto.FromIban);
        BankAccount? toAccount = db.Accounts.FirstOrDefault(ac => ac.Iban == dto.ToIban);

        if (fromAccount == null || toAccount == null)
            return BadRequest("Source account or destination account is/are not found");

        TransactionStatus status = TransactionStatus.Succeeded;

        double amount = Currencies.CurrencyToUsd(dto.Currency, dto.Amount);
        double fromAccountAmount = Currencies.UsdToCurrency(fromAccount.Currency, amount);
        double toAccountAmount = Currencies.UsdToCurrency(toAccount.Currency, amount);

        if (fromAccount.Take(fromAccountAmount))
        {
            toAccount.Amount += toAccountAmount;
            db.UpdateRange(fromAccount, toAccount);
        }
        else status = TransactionStatus.Rejected;
        
        BankTransaction transaction = new BankTransaction()
        {
            Label = dto.Label,
            Status = status,
            Amount = dto.Amount,
            Currency = dto.Currency,
            Date = DateTime.Now,
            FromAccount = fromAccount,
            ToAccount = toAccount,
            Id = Guid.NewGuid()
        };

        db.Transactions.Add(transaction);
        db.SaveChanges();
        Notifications.SendAsync("New transaction", $"A new transaction has been made from {fromAccount.Name} (-{fromAccountAmount} {fromAccount.Currency}) to {toAccount.Name} (+{toAccountAmount} {toAccount.Currency}) with the amount of {dto.Amount} {dto.Currency} (converted to {amount} USD)");

        return Created($"/transactions/{transaction.Id.ToString()}", transaction);
    }
}