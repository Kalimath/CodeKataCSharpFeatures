using StaticData;
using StaticData.BirdTypes;
using Xunit;

namespace Collection.TreeTests;

public class BirdsTests : GatheringPlaceTestBase
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
}

public class GatheringPlaceTestBase
{
    protected readonly BirdGatheringPlace GatheringPlace = new Tree("someTree");
    protected static readonly Bird FirstBird = new Goose("Mallard", "quack", Climate.Mild);
    protected static readonly Bird SecondBird = new Pinguïn("Emperor", "tweet", Climate.Cold);
    protected readonly Bird[] SomeBirds = [FirstBird, SecondBird];
}