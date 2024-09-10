using StaticData;
using Validation.LicensePlates;
using Validation.Validators.Base;
using static Validation.Validators.LicenseValidators;

namespace Validation;

public static class BelgianLicenseplateValidator
{
        
    public static ValidationResult Validate(BelgianLicensePlate licensePlate)
    {
        return licensePlate.Type switch
        {
            BasicBelgianNumberplateType.Type1 => ValidateType1(licensePlate),
            BasicBelgianNumberplateType.Type2 => ValidateType2(licensePlate),
            BasicBelgianNumberplateType.Type3 => ValidateType3(licensePlate),
            BasicBelgianNumberplateType.Type4 => ValidateType4(licensePlate),
            BasicBelgianNumberplateType.Type5 => ValidateType5(licensePlate),
            BasicBelgianNumberplateType.Type6 => ValidateType6(licensePlate),
            BasicBelgianNumberplateType.Type7 => ValidateType7(licensePlate),
            _ => new ValidationResult(false, "Invalid number plate type")
        };
    }

    private static ValidationResult ValidateType1(BelgianLicensePlate licensePlate)
    {
        var conditions = new []
        {
            NotEmpty,
            IsNumber,
            IsNumberGreaterThanZero,
            (s => int.TryParse(s.Value, out var result) && result <= 28000), // IsNumberNotGreaterThan28000 
        };
        var isValid = licensePlate.Validate(conditions);
            
        return new ValidationResult(isValid, isValid ? null : "Invalid Belgian type1 licensePlate value");
    }

    private static ValidationResult ValidateType2(BelgianLicensePlate licensePlate)
    {
        //TODO: Implement validation logic for Type 2 number plates
        return new ValidationResult(false, "Type 2 number plates are not yet implemented");
    }

    private static ValidationResult ValidateType3(BelgianLicensePlate licensePlate)
    {
        //TODO: Implement validation logic for Type 3 number plates
        return new ValidationResult(false, "Type 3 number plates are not yet implemented");
    }

    private static ValidationResult ValidateType4(BelgianLicensePlate licensePlate)
    {
        //TODO: Implement validation logic for Type 4 number plates
        return new ValidationResult(false, "Type 4 number plates are not yet implemented");
    }

    private static ValidationResult ValidateType5(BelgianLicensePlate licensePlate)
    {
        //TODO: Implement validation logic for Type 5 number plates
        return new ValidationResult(false, "Type 5 number plates are not yet implemented");
    }

    private static ValidationResult ValidateType6(BelgianLicensePlate licensePlate)
    {
        var isValid = licensePlate.Value.Validate(IsBelgianLicensePlateOfType6);
            
        return new ValidationResult(isValid, isValid ? null : "Invalid Belgian type6 licensePlate value");
    }

    private static ValidationResult ValidateType7(BelgianLicensePlate licensePlate)
    {
        var conditions = new[]
        {
            NotEmpty,
            s => s.Length == 7, //FirstCharacterIsAlphaOrNumber;FirstCharacterIsFollowedByDash;
            s => s.StartsWith("w"),
        };
            
        var isValid = licensePlate.Value.Validate(conditions);
        return new ValidationResult(isValid, isValid ? null : "Invalid Belgian type6 licensePlate value");    
        
        //TODO: Implement validation logic for Type 7 number plates
        return new ValidationResult(false, "Type 7 number plates are not yet implemented");
    }
}