using StaticData;
using Xunit;

namespace RecordTypes.UnitTests;

public class DuckShould
{
    [Fact]
    public void EqualToValues()
    {
        var duck1 = new Duck(DuckType.Mallard, true, "kwak", Climate.Mild);
        var duck2 = new Duck(DuckType.Mallard, true, "kwak", Climate.Mild);

        Assert.True((bool)duck1.Equals(duck2));
        Assert.Equal(duck1, duck2);
    }

    [Fact]
    public void NotEqualToDifferentValues()
    {
        var duck1 = new Duck(DuckType.Mallard, true, "kwak", Climate.Mild);
        var duck2 = new Duck(DuckType.Mallard, false, "quack", Climate.Mild);

        Assert.False((bool)duck1.Equals(duck2));
        Assert.NotEqual(duck1, duck2);
    }
}