using Microsoft.VisualBasic;

namespace Crabank.Utilities;

public class Currencies
{
    public static Dictionary<string, float> Dictionary = new()
    {
        { "AED", 3.67f },
        { "AFN", 87.25f },
        { "ALL", 107.15f },
        { "AMD", 386.30f },
        { "ANG", 1.79f },
        { "AOA", 825.50f },
        { "ARS", 350.15f },
        { "AUD", 1.57f },
        { "AWG", 1.80f },
        { "AZN", 1.70f },
        { "BAM", 1.95f },
        { "BBD", 2.00f },
        { "BDT", 109.85f },
        { "BGN", 1.96f },
        { "BHD", 0.38f },
        { "BIF", 2800.00f },
        { "BMD", 1.00f },
        { "BND", 1.37f },
        { "BOB", 6.92f },
        { "BRL", 5.25f },
        { "BSD", 1.00f },
        { "BTN", 83.25f },
        { "BWP", 13.05f },
        { "BYN", 3.16f },
        { "BZD", 2.00f },
        { "CAD", 1.35f },
        { "CDF", 2005.00f },
        { "CHF", 0.92f },
        { "CLP", 780.25f },
        { "CNY", 7.15f },
        { "COP", 4030.00f },
        { "CRC", 540.75f },
        { "CUP", 24.00f },
        { "CVE", 110.50f },
        { "CZK", 22.05f },
        { "DJF", 178.00f },
        { "DKK", 6.85f },
        { "DOP", 56.55f },
        { "DZD", 136.70f },
        { "EGP", 30.85f },
        { "ERN", 15.00f },
        { "ETB", 55.75f },
        { "EUR", 0.91f },
        { "FJD", 2.15f },
        { "FKP", 0.75f },
        { "FOK", 6.85f },
        { "GBP", 0.75f },
        { "GEL", 2.95f },
        { "GGP", 0.75f },
        { "GHS", 11.25f },
        { "GIP", 0.75f },
        { "GMD", 65.00f },
        { "GNF", 8550.00f },
        { "GTQ", 7.75f },
        { "GYD", 210.00f },
        { "HKD", 7.85f },
        { "HNL", 24.65f },
        { "HRK", 6.85f },
        { "HTG", 140.00f },
        { "HUF", 335.00f },
        { "IDR", 15250.00f },
        { "ILS", 3.85f },
        { "IMP", 0.75f },
        { "INR", 83.25f },
        { "IQD", 1460.00f },
        { "IRR", 42000.00f },
        { "ISK", 137.00f },
        { "JEP", 0.75f },
        { "JMD", 154.50f },
        { "JOD", 0.71f },
        { "JPY", 147.50f },
        { "KES", 146.00f },
        { "KGS", 89.50f },
        { "KHR", 4115.00f },
        { "KID", 1.57f },
        { "KMF", 455.00f },
        { "KRW", 1350.00f },
        { "KWD", 0.31f },
        { "KYD", 0.83f },
        { "KZT", 465.50f },
        { "LAK", 19785.00f },
        { "LBP", 1515.00f },
        { "LKR", 320.50f },
        { "LRD", 185.00f },
        { "LSL", 19.00f },
        { "LYD", 4.85f },
        { "MAD", 10.00f },
        { "MDL", 17.85f },
        { "MGA", 4700.00f },
        { "MKD", 56.50f },
        { "MMK", 2100.00f },
        { "MNT", 3450.00f },
        { "MOP", 8.10f },
        { "MRU", 37.00f },
        { "MUR", 45.15f },
        { "MVR", 15.45f },
        { "MWK", 1175.00f },
        { "MXN", 18.75f },
        { "MYR", 4.60f },
        { "MZN", 63.50f },
        { "NAD", 19.00f },
        { "NGN", 770.00f },
        { "NIO", 36.15f },
        { "NOK", 11.00f },
        { "NPR", 133.25f },
        { "NZD", 1.67f },
        { "OMR", 0.38f },
        { "PAB", 1.00f },
        { "PEN", 3.80f },
        { "PGK", 3.50f },
        { "PHP", 56.75f },
        { "PKR", 305.00f },
        { "PLN", 4.20f },
        { "PYG", 7300.00f },
        { "QAR", 3.65f },
        { "RON", 4.60f },
        { "RSD", 107.50f },
        { "RUB", 95.00f },
        { "RWF", 1200.00f },
        { "SAR", 3.75f },
        { "SBD", 8.30f },
        { "SCR", 13.85f },
        { "SDG", 575.00f },
        { "SEK", 11.00f },
        { "SGD", 1.37f },
        { "SHP", 0.75f },
        { "SLE", 21000.00f },
        { "SOS", 575.00f },
        { "SRD", 37.00f },
        { "SSP", 790.00f },
        { "STN", 22.50f },
        { "SYP", 2500.00f },
        { "SZL", 19.00f },
        { "THB", 36.00f },
        { "TJS", 11.30f },
        { "TMT", 3.50f },
        { "TND", 3.10f },
        { "TOP", 2.35f },
        { "TRY", 27.50f },
        { "TTD", 6.80f },
        { "TVD", 1.57f },
        { "TWD", 32.50f },
        { "TZS", 2400.00f },
        { "UAH", 36.75f },
        { "UGX", 3800.00f },
        { "USD", 1.00f },
        { "UYU", 39.50f },
        { "UZS", 12250.00f },
        { "VES", 34.50f },
        { "VND", 24500.00f },
        { "VUV", 115.00f },
        { "WST", 2.70f },
        { "XAF", 620.00f },
        { "XCD", 2.70f },
        { "XOF", 620.00f },
        { "XPF", 110.50f },
        { "YER", 250.00f },
        { "ZAR", 19.00f },
        { "ZMW", 22.50f },
        { "ZWL", 5400.00f }
    };
}