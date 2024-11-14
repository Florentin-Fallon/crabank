using Crabank.Database;
using Crabank.Database.Models;
using Microsoft.AspNetCore.Mvc;

namespace Crabank.Controllers;

public class CurrencyController : ControllerBase
{
    [HttpGet("/currency/{id}")]
    public object GetCurrency(string id)
    {
        using BankDbContext db = new();

        BankCurrency? currency = db.Currencies.Find(id);
        if (currency == null) return NotFound();

        return Ok(currency);
    }
    
    [HttpGet("/currencies")]
    public object GetCurrencies([FromQuery] int page = 0)
    {
        using BankDbContext db = new();

        BankCurrency[] currency = db.Currencies
            .AsEnumerable()
            .Take(new Range(page * 10, (page + 1) * 10))
            .ToArray();

        return currency.Select(c => c.Id).ToArray();
    }
}