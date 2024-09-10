namespace Validation.LicensePlates;

public abstract class LicensePlate(string value)
{
    public string Value { get; } = value;
}