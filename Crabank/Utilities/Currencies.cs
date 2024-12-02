using Crabank.Database;
using Crabank.Database.Models;
using Microsoft.VisualBasic;

namespace Crabank.Utilities;

public class Currencies
{
    public static bool IsValid(string currency)
    {
        using BankDbContext db = new();
        return db.Currencies.FirstOrDefault(c => c.Id == currency) != null;
    }

    public static double CurrencyToUsd(string inputCurrency, double value)
    {
        using BankDbContext db = new();
        BankCurrency? currency = db.Currencies.Find(inputCurrency);
        if (currency == null) throw new Exception($"Currency {inputCurrency} not found");
        
        return value / currency.ValueInUsd;
    }

    public static double UsdToCurrency(string outputCurrency, double value)
    {
        using BankDbContext db = new();
        BankCurrency? currency = db.Currencies.Find(outputCurrency);
        if (currency == null) throw new Exception($"Currency {outputCurrency} not found");
        
        return value * currency.ValueInUsd;
    }
}