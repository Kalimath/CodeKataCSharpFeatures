using StaticData;

namespace RecordTypes;

//Use this file for the exercise
public class Duck
{
    public Duck(DuckType type, bool canFly, string sound, Climate climate)
    {
        Type = type;
        CanFly = canFly;
        Sound = sound;
        Climate = climate;
    }

    public DuckType Type { get; init; }
    public bool CanFly { get; init; }
    public string Sound { get; init; }
    public Climate Climate { get; init; }
}