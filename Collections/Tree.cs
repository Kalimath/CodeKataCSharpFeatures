using System.Collections;
using StaticData;

namespace Collections;

public class Tree(string name) : BirdGatheringPlace(name)
{
    // add a single bird to the tree
    public override void AddBird(Bird bird) => Birds = [..Birds, bird]; //TODO: remove

    // add multiple birds to the tree
    public override void AddBirds(ICollection<Bird> arrivingBirds) => Birds = [..Birds, ..arrivingBirds]; //TODO: remove

    // return the first bird that arrived to the tree, or null if no birds have arrived
    public override Bird? GetFirstArrivedBird() => Birds is [] ? null : Birds[0]; //TODO: remove
    
    // return the last bird that arrived to the tree, or null if no birds have arrived
    public override Bird? GetLastArrivedBird() => Birds is [] ? null : Birds[^1]; //TODO: remove
}