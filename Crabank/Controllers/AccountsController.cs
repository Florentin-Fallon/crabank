using Crabank.Database;
using Crabank.Database.Models;
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
    public object CreateAccount()
    {
        using BankDbContext db = new();

        return StatusCode(418);
    }
}