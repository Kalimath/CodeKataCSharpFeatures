using StaticData;
using StaticData.BirdTypes;
using Xunit;

namespace Collections.TreeTests;

public class BirdsTests : TreeTestBase
{
    [Fact]
    public void AddGivenBirdToTree()
    {
        GatheringPlace.AddBird(FirstBird);
        
        Assert.Equal(1, GatheringPlace.GetBirdCount);
    }

    [Fact]
    public void AddMultipleBirdsToTree()
    {
        GatheringPlace.AddBirds(SomeBirds);
        
        Assert.Equal(2, GatheringPlace.GetBirdCount);
    }

    [Fact]
    public void GetFirstArrivedBird()
    {
        GatheringPlace.AddBirds(SomeBirds);
        
        Assert.Equal(FirstBird, GatheringPlace.GetFirstArrivedBird());
    }

    [Fact]
    public void GetFirstArrivedBirdReturnsNullWhenNoBirdsArrived()
    {
        Assert.Null(GatheringPlace.GetFirstArrivedBird());
    }

    [Fact]
    public void GetLastArrivedBird()
    {
        GatheringPlace.AddBirds(SomeBirds);
        
        Assert.Equal(SomeBirds.Last(), GatheringPlace.GetLastArrivedBird());
    }

    [Fact]
    public void GetLastArrivedBirdReturnsNullWhenNoBirdsArrived()
    {
        Assert.Null(GatheringPlace.GetLastArrivedBird());
    }
}

public class TreeTestBase
{
    protected readonly BirdGatheringPlace GatheringPlace = new Tree("someTree");
    protected static readonly Bird FirstBird = new Goose("Mallard", "quack", Climate.Mild);
    protected static readonly Bird SecondBird = new Pinguïn("Emperor", "tweet", Climate.Cold);
    protected readonly Bird[] SomeBirds = [FirstBird, SecondBird];
}