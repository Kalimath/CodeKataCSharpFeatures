using System.ComponentModel.DataAnnotations;
using Validation.LicensePlates;
using Validation.Validators.Base;
using ValidationResult = System.ComponentModel.DataAnnotations.ValidationResult;

namespace Validation.Car;

public class Car(LicensePlate licensePlate) : IValidatableObject
{
    private LicensePlate LicensePlate { get; } = licensePlate;
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        var validLicense = LicensePlate.Validate();
        return [new ValidationResult(validLicense? null : "Invalid license plate format", new[] { "LicensePlate" })];
    }
}