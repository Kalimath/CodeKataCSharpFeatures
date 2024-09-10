namespace StaticData.BirdTypes;

public record Goose(string Name, string Sound, Climate Climate) 
        : Bird(Name, Sound, Climate, canFly: true)
{
    
}