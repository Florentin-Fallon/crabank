namespace Crabank.Database.Models;

public class BankAccount
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    public double Amount { get; set; }
    public string Iban { get; set; }
    public double CreditLimit { get; set; }
    public string BankAdvisorName { get; set; }
}