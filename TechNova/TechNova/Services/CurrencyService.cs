using TechNova.Shared.Classes.Entities;
using TechNova.Shared.Enums;
using TechNova.Shared.Interfaces;

namespace TechNova.Services;

public class CurrencyService : ICurrencyService
{
    private readonly HttpClient _httpClient;

    private readonly List<string> _currencyPairs = new List<string>() { "EUR_USD", "EUR_GBP" };

    public CurrencyService(IHttpClientFactory httpClient)
    {
        _httpClient = httpClient.CreateClient("CurrencyClient");
    }



    public async Task<List<Currency>> GetCurrenciesAsync()
    {
        List<Currency> currencyList = new List<Currency>();

        var tasks = _currencyPairs.Select(c => _httpClient.GetFromJsonAsync<Currency>($"exchangerate?pair={c}")).ToList();

        var results = await Task.WhenAll(tasks);

        foreach (var currency in results)
        {
            currency.CurrencyId = AssignCurrencyId(currency.CurrencyPair);
            currencyList.Add(currency);
        }

        return currencyList;
    }

    private static CurrencyId AssignCurrencyId(string currencyPair)
    {
        return currencyPair switch
        {
            var pair when pair.Contains("_USD") => CurrencyId.USD,
            var pair when pair.Contains("_GBP") => CurrencyId.GBP,
            _ => throw new ArgumentException("Unsupported currency pair", nameof(currencyPair)),
        };
    }


    public List<Currency> Currencies { get; set; } = new List<Currency> { new Currency() };
    public Currency CurrentCurrency { get; set; } = new Currency();
    public string CurrentCurrencyPair { get; set; } = string.Empty;

    public event Action? OnCurrencyChanged;

    public void GetCurrency(string currencyPair)
    {
        var currency = Currencies.FirstOrDefault(c => c.CurrencyPair == currencyPair);
        CurrentCurrencyPair = currencyPair;

        SetCurrency(currency);
    }

    public void SetCurrency(Currency currency)
    {
        CurrentCurrency = currency;
        OnCurrencyChanged?.Invoke();
    }
}
