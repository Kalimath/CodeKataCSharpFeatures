using StaticData;

namespace Validation.LicensePlates;

public class BelgianLicensePlate(string value, BasicBelgianNumberplateType type) : LicensePlate(value)
{
    public BasicBelgianNumberplateType Type { get; } = type;

}