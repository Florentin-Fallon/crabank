using Crabank.Database;
using Crabank.Database.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Crabank.Controllers;

public class AdvisorController : ControllerBase
{
    /// <summary>
    /// Create an advisor
    /// </summary>
    /// <param name="advisor"></param>
    /// <returns></returns>
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

    /// <summary>
    /// Get all advisors by page (containing 10 items each)
    /// </summary>
    /// <param name="page"></param>
    /// <returns></returns>
    [HttpGet("/advisors")]
    public object GetAdvisors(int page = 0)
    {
        using BankDbContext db = new();

        int pageOffset = page * 10;
        
        return Ok(db.Advisors.AsEnumerable().Take(pageOffset..(pageOffset+10)).ToArray());
    }

    /// <summary>
    /// Get an advisor by its id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("/advisor/{id}")]
    public object GetAdvisor(int id = 0)
    {
        using BankDbContext db = new();
        
        return Ok(db.Advisors.Find(id));
    }
}