using TechNova.Shared.Classes.Entities;

namespace TechNova.Shared.Interfaces;

public interface ICurrencyService
{
    string CurrentCurrencyPair { get; set; }
    List<Currency> Currencies { get; }
    Currency CurrentCurrency { get; set; }
    public event Action OnCurrencyChanged;
    Task<List<Currency>> GetCurrenciesAsync();
    void GetCurrency(string currencyPair);
    void SetCurrency(Currency currency);
}
