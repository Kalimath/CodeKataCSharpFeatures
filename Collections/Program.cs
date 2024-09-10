// See https://aka.ms/Car-console-template for more information

using StaticData;
using StaticData.BirdTypes;

namespace Collections;

internal class Program
{
    public static async Task Main()
    {
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

        Console.WriteLine("\nAll birds have gathered. Here is some info:");
        await Task.Delay(2000);
        
        LogGatheringInfo(gatheringPlace);
    }
    
    private static void LogGatheringInfo(BirdGatheringPlace place)
    {
        var firstArrivedBird = place.GetFirstArrivedBird();
        if (firstArrivedBird is not null)
        {
            Console.WriteLine($"\nThe {place.Name} contains {place.GetBirdCount} birds.");
            Console.WriteLine($"The first bird was a {place.GetFirstArrivedBird()!.FullName}");
            Console.WriteLine($"The last bird was a {place.GetLastArrivedBird()!.FullName}\n");
        }
        else
        {
            Console.WriteLine($"The {place.Name} is empty.\n");
        }
    }

    private static async Task BirdIsGatheringAt(Bird bird, BirdGatheringPlace place)
    {
        await Task.Delay(new Random().Next(200, 2000));
        Console.WriteLine($"New bird arrived. Kind: {bird.FullName}");
        place.AddBird(bird);
    }
}