using Microsoft.EntityFrameworkCore;

namespace Crabank.Database.Models;

public class BankTransaction
{
    public Guid Id { get; set; }
    public double Amount { get; set; }
    public DateTime Date { get; set; }
    public BankAccount FromAccount { get; set; }
    public BankAccount ToAccount { get; set; }
    public string Label { get; set; }
}