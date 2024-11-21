// See https://aka.ms/new-console-template for more information

using Collection;
using StaticData;
using StaticData.BirdTypes;

var gatheringPlace = new Tree("big old tree");

var canadianGoose = new Goose("Canadian", "quack", Climate.Mild);
var greyHeron = new Heron("Grey", "squawk", Climate.Warm);
var blueHeron = new Heron("Great Blue", "squawk", Climate.Warm);

Console.WriteLine($"I found a place to look at some wild birds. I have my eyes on the {gatheringPlace.Name}. Let's wait for them...\n");

//_ = Console.ReadLine();
await BirdIsGatheringAt(canadianGoose, gatheringPlace);
await BirdIsGatheringAt(blueHeron, gatheringPlace);
await BirdIsGatheringAt(greyHeron, gatheringPlace);
await BirdIsGatheringAt(canadianGoose, gatheringPlace);
await BirdIsGatheringAt(greyHeron, gatheringPlace);
await BirdIsGatheringAt(blueHeron, gatheringPlace);

Console.WriteLine("\nAll birds have gathered. Here is some info:\n--------------------------------------------");
await Task.Delay(2000);
        
LogGatheringInfo(gatheringPlace);

void LogGatheringInfo(BirdGatheringPlace place)
{
    var firstArrivedBird = place.GetBirds().FirstOrDefault();
    var lastArrivedBird = place.GetBirds().LastOrDefault();
    var birdsBesidesFirstAndLast = place.GetBirds().Skip(1).Take(place.GetBirdCount - 2).ToArray();
    if (firstArrivedBird is not null)
    {
        Console.WriteLine($"The first bird was a {firstArrivedBird!.FullName}");
        Console.WriteLine($"The last bird was a {lastArrivedBird!.FullName}");
        Console.WriteLine($"({birdsBesidesFirstAndLast.Length} birds have landed in between)\n");
    }
    else
    {
        Console.WriteLine($"The {place.Name} is empty.\n");
    }
    
    var birds = place.GetBirds();
    switch (birds)
    {
        case []:
            Console.WriteLine($"The {place.Name} is empty.\n");
            break;
        case [Bird first, .. Bird[] rest, Bird last]:
            Console.WriteLine($"The first bird was a {first.FullName}");
            Console.WriteLine($"The last bird was a {last.FullName}");
            Console.WriteLine($"({rest.Length} birds have landed in between)\n");
            break;
        default:
            Console.WriteLine("Failed to log gathering info. Unknown data of birds.\n");
            break;
    }
}

async Task BirdIsGatheringAt(Bird bird, BirdGatheringPlace place)
{
    await Task.Delay(new Random().Next(200, 2000));
    Console.WriteLine($"New bird arrived. Kind: {bird.FullName}");
    place.AddBird(bird);
}