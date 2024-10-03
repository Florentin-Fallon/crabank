using Crabank.Database;
using Crabank.Database.Dto;
using Crabank.Database.Models;
using Crabank.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace Crabank.Controllers;

[ApiController]
public class AccountsController : ControllerBase
{
    [HttpGet("/accounts")]
    public BankAccount[] GetAllAccounts()
    {
        using BankDbContext db = new();

        return db.Accounts.Take(10).ToArray();
    }
    
    [HttpPost("/accounts")]
    public object CreateAccount([FromBody] AccountCreationDto dto)
    {
        using BankDbContext db = new();

        if (string.IsNullOrWhiteSpace(dto.Name))
            return BadRequest("Invalid name");
        if (string.IsNullOrWhiteSpace(dto.OwnerName))
            return BadRequest("Invalid owner name");

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

        return Created($"/accounts/{bban}", account);
    }
}