namespace Validation.LicensePlates;

/// <summary>
/// Format: AA-001-AA
/// </summary>
public class FrenchLicensePlate(string value) : LicensePlate(value);