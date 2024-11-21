using Validation.Validators;

namespace Validation.LicensePlates;

public class BelgianLicensePlate : LicensePlate
{
    public BelgianLicensePlate(string value, BasicBelgianLicenseType type) : base(value)
    {
        Type = type;
        if (!this.IsValidBelgianLicensePlate()) //TODO: try checking with Bram how to implement the IValidatableObject logic instead
            throw new ArgumentException("Invalid Belgian license plate");
    }

    public BasicBelgianLicenseType Type { get; }
}