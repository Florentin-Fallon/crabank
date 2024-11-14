using Microsoft.EntityFrameworkCore;

namespace Crabank.Database.Models;

[PrimaryKey(propertyName: "Bban")]
public class BankAccount
{
    public long Bban { get; set; }
    public string Iban { get; set; }

    public DateTime AccountCreationDate { get; set; }
    public string Name { get; set; }
    public string OwnerName { get; set; }
    public double Amount { get; set; }
    public string Currency { get; set; }
    public double CreditLimit { get; set; }
    public BankAdvisor Advisor { get; set; }
    public BankAccountType Type { get; set; }
    public ICollection<BankCard> Cards { get; set; }

    public bool Take(double amount)
    {
        if (amount <= 0) return false;
        if (Amount - amount < 0) return false;

        Amount -= amount;
        return true;
    }
}

public enum BankAccountType
{
    Checking,
    Savings,
    Special
} 