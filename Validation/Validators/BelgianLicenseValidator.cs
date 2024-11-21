using Validation.LicensePlates;
using Validation.Validators.Base;
using static Validation.Validators.StringValidators;

namespace Validation.Validators;

public static class BelgianLicenseValidator
{
    public static bool IsValidBelgianLicensePlate(this BelgianLicensePlate plate)
    {
        return IsType6(plate.Value) || IsType7(plate.Value);
    }
    
    public static readonly Func<string, bool> IsType6 = plate =>
    {
        var earlierType6Conditions = new[]
        {
            NotEmpty,
            IsLength7,
            First3CharsAreAlphabetic,
            FourthCharIsDash,
            Last3CharsAreNumeric
        };

        var laterType6Conditions = new[]
        {
            NotEmpty,
            IsLength7,
            First3CharsAreNumeric,
            Last3CharsAreAlphabetic,
            FourthCharIsDash
        };
        
        var isEarlierType6 = plate.Validate(earlierType6Conditions);
        var isLaterType6 = plate.Validate(laterType6Conditions); 
        
        return isEarlierType6 || isLaterType6;
    };
    
    public static readonly Func<string, bool> IsType7 = plate =>
    {
        //TODO: exercise
        
        return false;
    };
}