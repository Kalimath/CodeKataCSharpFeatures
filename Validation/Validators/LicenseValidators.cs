using Validation.Validators.Base;

namespace Validation.Validators;

public static class LicenseValidators
{
    public static readonly Func<string, bool> NotEmpty = s =>
    {
        LogCall(nameof(NotEmpty));
        return !string.IsNullOrWhiteSpace(s);
    };
    public static readonly Func<string, bool> IsAlphabetic = s =>
    {
        LogCall(nameof(IsAlphabetic));
        return s.All(char.IsLetter);
    };
    public static readonly Func<string, bool> IsDash = s =>
    {
        LogCall(nameof(IsDash));
        return s.Equals("-");
    };
    public static readonly Func<string, bool> IsNumberGreaterThanZero = s =>
    {
        LogCall(nameof(IsNumberGreaterThanZero));
        return int.TryParse(s, out var number) && number > 0;
    };
    public static readonly Func<string, bool> IsNumberSmallerThan1000 = s =>
    {
        LogCall(nameof(IsNumberSmallerThan1000));
        return int.TryParse(s, out var number) && number < 1000;
    };
    public static readonly Func<string, bool> IsNumberBetween1And999 = s =>
    {
        LogCall(nameof(IsNumberBetween1And999));
        return IsNumberGreaterThanZero(s) && IsNumberSmallerThan1000(s);
    };
    public static readonly Func<string, bool> Last3CharsAreAlphabetic = s =>
    {
        LogCall(nameof(Last3CharsAreAlphabetic));
        return IsAlphabetic(s[^3..]);
    };
    public static readonly Func<string, bool> First3CharsAreAlphabetic = s =>
    {
        LogCall(nameof(First3CharsAreAlphabetic));
        return IsAlphabetic(s[..3]);
    };
    public static readonly Func<string, bool> Last3CharsAreNumeric = s =>
    {
        LogCall(nameof(Last3CharsAreNumeric));
        return IsNumberBetween1And999(s[^3..]);
    };
    public static readonly Func<string, bool> First3CharsAreNumeric = s =>
    {
        LogCall(nameof(First3CharsAreNumeric));
        return IsNumberBetween1And999(s[..3]);
    };
    public static readonly Func<string, bool> IsLength7 = s =>
    {
        LogCall(nameof(IsLength7));
        return s.Length == 7;
    };
    public static readonly Func<string, bool> FourthCharIsDash = s =>
    {
        LogCall(nameof(FourthCharIsDash));
        return IsDash(s.Substring(3, 1));
    };
    
    
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
    
    public static void LogCall(string methodName) => Console.WriteLine($"Calling {methodName}");
}