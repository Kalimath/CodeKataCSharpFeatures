using Xunit;
using static Validation.Validators.StringValidators;

namespace Validation.UnitTests.LicenseValidatorsTests;

public class First3CharsAreNumericShould
{
    private static readonly Func<string, bool> Validator = First3CharsAreNumeric;

    [Fact]
    public void ReturnsTrue_WhenFirst3CharsAreNumeric()
    {
        const string input = "123HKENAL";
        
        var result = Validator(input);
        
        Assert.True(result);
    }
    [Fact]
    public void ReturnsFalse_WhenFirst3CharsAreNotNumeric()
    {
        const string input = "12D3HKENAL";
        
        var result = Validator(input);
        
        Assert.False(result);
    }
}