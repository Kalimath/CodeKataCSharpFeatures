namespace Validation.Validators.Base;

public interface ILicenseValidator
{
    public string[] Validate(string licensePlate);
}