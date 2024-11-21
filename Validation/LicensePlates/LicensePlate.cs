using System.ComponentModel.DataAnnotations;

namespace Validation.LicensePlates;

public abstract class LicensePlate(string value)
{
    [Required]
    public string Value { get; } = value;
}