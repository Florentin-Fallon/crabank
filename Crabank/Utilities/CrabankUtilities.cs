using System.Net.Security;

namespace Crabank.Utilities;

public static class CrabankUtilities
{
    public static long GenerateBban()
    {
        long number = 0;

        for (int i = 0; i < 10; i++)
        {
            int digit = Random.Shared.Next(0, 10);
            number += (long)(digit * MathF.Pow(10, i));
        }
        
        return number;
    }

    public static bool IsValidIban(string country, string input)
        => !string.IsNullOrWhiteSpace(input) && input.StartsWith(country) && input.Replace(" ", "").Length == 26;
    
    public static string GenerateIban(long bban, string country, string ownerName)
    {
        string accountId = "";
        string bbanString = bban.ToString();
        int space = 3;

        for (int i = 0; i < 10; i++)
        {
            accountId += bbanString[i];
            if (space % 4 == 0) accountId += " ";

            space++;
        }

        return $"{country}14 {ownerName[..4].ToUpper()} 9888 88{accountId}69";
    }

    public static string GenerateCreditCardNumbers()
    {
        string final = "";

        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++) final += Random.Shared.Next(9);
            final += " ";
        }        
        
        return final.Trim();
    }
}