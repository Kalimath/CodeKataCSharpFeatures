using Validation.Validators.Base;

namespace Validation.Validators;

public static class LicenseValidators
{
    public static readonly Func<string, bool> NotEmpty = s => !string.IsNullOrWhiteSpace(s);
    public static readonly Func<string, bool> IsNumber = s => s.All(char.IsDigit);
    public static readonly Func<string, bool> IsAlphabetic = s => s.All(char.IsLetter);
    public static readonly Func<string, bool> IsDash = s => s.Equals("-");
    public static readonly Func<string, bool> IsNumberGreaterThanZero = s => int.TryParse(s, out var number) && number > 0;
    public static readonly Func<string, bool> IsNumberSmallerThan1000 = s => int.TryParse(s, out var number) && number < 1000;
    public static readonly Func<string, bool> IsNumberBetween1And999 = s => IsNumberGreaterThanZero(s) && IsNumberSmallerThan1000(s);

    public static readonly Func<string, bool> Last3CharsAreAlphabetic = s => IsAlphabetic(s[^3..]);
    public static readonly Func<string, bool> First3CharsAreAlphabetic = s => IsAlphabetic(s[..3]);
    
    public static readonly Func<string, bool> Last3CharsAreNumeric = s => IsNumberBetween1And999(s[^3..]);
    public static readonly Func<string, bool> First3CharsAreNumeric = s => IsNumberBetween1And999(s[..3]);
    
    public static readonly Func<string, bool> IsLength7 = s => s.Length == 7;
    public static readonly Func<string, bool> FourthCharIsDash = s => IsDash(s.Substring(3,1));
    
    
    public static readonly Func<string, bool> IsBelgianLicensePlateOfType6 = plate =>
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
}