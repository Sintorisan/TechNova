using System.Text.Json.Serialization;
using TechNova.Shared.Enums;

namespace TechNova.Shared.Classes.Entities;

public class Currency
{
    [JsonPropertyName("currency_pair")]
    public string CurrencyPair { get; set; } = "EUR";
    [JsonPropertyName("exchange_rate")]
    public double ExchangeRate { get; set; }
    public CurrencyId CurrencyId { get; set; } = CurrencyId.Euro;
    public string CurrencySymbols
    {
        get => CurrencyId switch
        {
            CurrencyId.Euro => "€",
            CurrencyId.USD => "$",
            CurrencyId.GBP => "£",
            _ => throw new Exception()
        };
    }
}
