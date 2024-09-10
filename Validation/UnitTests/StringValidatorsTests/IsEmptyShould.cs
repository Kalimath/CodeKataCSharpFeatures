using Xunit;
using static Validation.Validators.LicenseValidators;

namespace Validation.UnitTests.StringValidatorsTests;

public class IsEmptyShould
{
    private const string SomeValidLicensePlate = "ABC-123";

    [Theory]
    [InlineData("")]
    [InlineData("  ")]
    [InlineData("     ")]
    [InlineData("   \t   ")]
    public void ReturnFalse_WhenStringIsEmpty(string emptyString)
    {
        Assert.False(NotEmpty(emptyString));
    }

    [Fact]
    public void ReturnTrue_WhenStringIsNotEmpty()
    {
        Assert.True(NotEmpty(SomeValidLicensePlate));
    }
}