namespace StaticData.BirdTypes;

public record Heron(string Name, string Sound, Climate Climate) : Bird(Name, Sound, Climate, canFly: true)
{
    
}