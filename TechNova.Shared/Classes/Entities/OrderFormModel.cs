using System.ComponentModel.DataAnnotations;

namespace TechNova.Shared.Classes.Entities;

public class OrderFormModel
{
    public int Id { get; set; }
    public string UserID { get; set; } = string.Empty;
    [Required]
    public string StreetAddress { get; set; } = string.Empty;
    [Required]
    public string CityAddress { get; set; } = string.Empty;
    [Required]
    public string CountryAddress { get; set; } = string.Empty;
    [Required]
    public string PostalCodeAddress { get; set; } = string.Empty;
}
