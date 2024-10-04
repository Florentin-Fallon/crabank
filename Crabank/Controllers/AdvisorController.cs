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
            return BadRequest("Invalid first name");
        if(string.IsNullOrWhiteSpace(advisor.LastName))
            return BadRequest("Invalid last name");
        if(string.IsNullOrWhiteSpace(advisor.Email) || !advisor.Email.Contains('@'))
            return BadRequest("Invalid email");
        
        db.Add(advisor);
        db.SaveChanges();
        
        return Created("/advisors", advisor);
    }
}