using Crabank.Database;
using Crabank.Database.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Crabank.Controllers;

public class AdvisorController : ControllerBase
{
    [HttpPost("/advisors")]
    
    public object CreateAdvisor([FromBody] BankAdvisor advisor)
    {
        using BankDbContext db = new();
        
        if(string.IsNullOrWhiteSpace(advisor.FirstName))
            return BadRequest("Invalid FirstName");
        if(string.IsNullOrWhiteSpace(advisor.LastName))
            return BadRequest("Invalid LastName");
        if(string.IsNullOrWhiteSpace(advisor.Email) || !advisor.Email.Contains('@'))
            return BadRequest("Invalid Email");
        
        db.Add(advisor);
        db.SaveChanges();
        
        return Created("/advisors", advisor);
    }
}