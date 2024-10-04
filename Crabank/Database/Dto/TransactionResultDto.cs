using Crabank.Database.Models;

namespace Crabank.Database.Dto;

public class TransactionResultDto
{
    public string Type { get; set; }
    public string Status { get; set; }
    public string Label { get; set; }
    public string Currency { get; set; }
    public double Amount { get; set; }
    public BankAccount Account { get; set; }
}

public enum TransactionType
{
    Inwards,
    Outwards
}