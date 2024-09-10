namespace StaticData.BirdTypes;

public record Pinguïn(string Name, string Sound, Climate Climate) : Bird(Name, Sound, Climate, canFly: false)
{
    
}