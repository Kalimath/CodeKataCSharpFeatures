namespace Validation.Validators.Base;

public interface ILicenseValidator
{
    public ValidationResult Validate(string licensePlate);
}