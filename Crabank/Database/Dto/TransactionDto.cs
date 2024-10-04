namespace Crabank.Database.Dto;

public class TransactionDto
{
    public string Label { get; set; }
    public double Amount { get; set; }
    public string Currency { get; set; }
    public string FromIban { get; set; }
    public string ToIban { get; set; }
}