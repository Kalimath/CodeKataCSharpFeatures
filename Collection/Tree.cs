using StaticData;

namespace Collection;

public class Tree(string name) : BirdGatheringPlace(name)
{
    // add a single bird to the tree
    public override void AddBird(Bird bird) => Birds = [..Birds, bird]; //TODO: remove

    // add multiple birds to the tree
    public override void AddBirds(ICollection<Bird> arrivingBirds) => Birds = [..Birds, ..arrivingBirds]; //TODO: remove
}