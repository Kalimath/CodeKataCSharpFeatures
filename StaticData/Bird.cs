namespace StaticData;

public abstract record Bird
{
    protected Bird(string Name, string Sound, Climate Climate, bool canFly = false)
    {
        this.Name = Name;
        this.Sound = Sound;
        this.Climate = Climate;
        CanFly = canFly;
    }

    // Base class for bird types
    public string Name { get; private init; }
    public string Sound { get; private init; }
    public Climate Climate { get; private init; }
    public bool CanFly { get; private set; }
    
    public string FullName => $"{Name} {GetType().Name}";
}