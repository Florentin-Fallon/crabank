using System.Text.Json.Serialization;

namespace Crabank.Database.Models;

public class BankCard
{
    public int Id { get; set; }
    public int AccountId { get; set; }
    [JsonIgnore]
    public BankAccount Account { get; set; }
    
    public string Name { get; set; }
    public string Numbers { get; set; }
    public BankCardNetwork Network { get; set; }
    public BankCardType Type { get; set; }
    public DateTime ExpirationDate { get; set; }
    public short SecurityCode { get; set; }
    public string Style { get; set; }
}

public enum BankCardNetwork
{
    Visa,
    MasterCard,
    Crabe
}

public enum BankCardType
{
    Debit,
    Credit
}