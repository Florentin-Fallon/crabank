using Microsoft.EntityFrameworkCore;

namespace Crabank.Database.Models;

[PrimaryKey(propertyName: "Iban")]
public class BankAccount
{
    public string Iban { get; set; }
    
    public DateTime AccountCreationDate { get; set; }
    public string Name { get; set; }
    public double Amount { get; set; }
    public string Currency { get; set; }
    public double CreditLimit { get; set; }
    public string BankAdvisorName { get; set; }
}