using StaticData;

namespace Collection;

/// <summary>
/// Large congregation of individuals of one or more species of birds
/// </summary>
public abstract class BirdGatheringPlace(string name)
{
    public string Name { get; } = name;
    
    protected List<Bird> Birds = [];

    public virtual void AddBird(Bird bird)
    {
        Birds.Add(bird); //FYI: this is not correct for the exercise
    }

    public virtual void AddBirds(ICollection<Bird> arrivingBirds)
    {
        foreach (var bird in arrivingBirds) AddBird(bird); //FYI: this is not correct for the exercise
    }
    
    public Bird[] GetBirds() => Birds.ToArray();
    
    public int GetBirdCount => Birds.Count;
}