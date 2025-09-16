using System.Net.WebSockets;
using System.Security.AccessControl;

public class Program
{
    public static List<Quest> QDone = new List<Quest>();
    public static List<Quest> QNotDone = new List<Quest>();
    public static List<string> potions = new List<string>();
    public static Player player = new Player("Hero", 20, 20, World.WeaponByID(World.WEAPON_ID_RUSTY_SWORD));

    static void Main()
    {

        System.Console.WriteLine("Hello and welcome to:");
        SlowWriteLine("  --PEST CONTROL--  ");
        SlowWriteLine("Would you like to?");
        int menuChoice = 0;
        do
        {
            SlowWriteLine("[1] START GAME");
            SlowWriteLine("[2] EXIT");
            menuChoice = Convert.ToInt32(Console.ReadLine());

        } while (menuChoice != 1 && menuChoice != 2);

        if (menuChoice == 1)
        {
            Console.WriteLine("You wake up at your home!");
            SlowWriteLine("For years, monsters have been terrorising the people in your town. Since you were a kid, you decided to do what you could to help, you trained with a rusty sword you found near a dead body for as long as you can remember. ");
            SlowWriteLine("One day, you decided that you had had enough —enough of rats, snakes, and giant spiders attacking your people.");
            SlowWriteLine("You have heard legends that there are three spiders in a forest, now known as the Spider Forest, that are said to be the cause of everything; they are the source of chaos and monsters.");
            SlowWriteLine("If you kill them, everything should stop. The town folk would be safe again.");
            SlowWriteLine("So, you grab your rusty sword, which has seen better days; maybe you should find a better weapon first before you go out to kill all those monsters.");
            SlowWriteLine("In the old days, farmers used to be blacksmiths; perhaps he still has something you could use.");
            SlowWriteLine("I should head up North and than West");
            Location currentLocation = World.LocationByID(World.LOCATION_ID_HOME);

            while (true)
            {

                Console.Clear();
                DrawMap(currentLocation);

                Console.WriteLine();
                Console.WriteLine($"You are at: {currentLocation.Name}");
                Console.WriteLine(currentLocation.Description);
                Console.WriteLine();

                Console.WriteLine("Where do you want to go? (N/E/S/W or Q to quit)");
                string input = Console.ReadLine().ToUpper();

                if (input == "Q") break;

                Location newLocation = input switch
                {
                    "N" => currentLocation.LocationToNorth,
                    "E" => currentLocation.LocationToEast,
                    "S" => currentLocation.LocationToSouth,
                    "W" => currentLocation.LocationToWest,
                    _ => null
                };

                if (newLocation == null)
                {
                    Console.WriteLine("You can't go that way!");
                }
                else
                {
                    currentLocation = newLocation;
                }

                Quest.CheckLocAndQuest(currentLocation);
                BattleSystem.BattleQuest(currentLocation);
                WinGame();
                DrawMap(currentLocation);
            }


        }
        else if (menuChoice == 2)
        {
            System.Console.WriteLine("BYE BYE!");
        }
    }


    public static void SlowWriteLine(string text, int delayMilliseconds = 50)
    {
        foreach (char c in text)
        {
            Console.Write(c);
            Thread.Sleep(delayMilliseconds);
        }
        Console.WriteLine();
    }

    static void DrawMap(Location playerLocation)
    {
        // Top row
        Console.WriteLine("      " + (playerLocation.ID == World.LOCATION_ID_ALCHEMISTS_GARDEN ? "[P]" : " P "));

        // Second row
        Console.WriteLine("      " + (playerLocation.ID == World.LOCATION_ID_ALCHEMIST_HUT ? "[A]" : " A "));

        // Main row
        string mainRow =
        (playerLocation.ID == World.LOCATION_ID_FARM_FIELD ? "[V]" : " V ") +
        (playerLocation.ID == World.LOCATION_ID_FARMHOUSE ? "[F]" : " F ") +
        (playerLocation.ID == World.LOCATION_ID_TOWN_SQUARE ? "[T]" : " T ") +
        (playerLocation.ID == World.LOCATION_ID_GUARD_POST ? "[G]" : " G ");

        // Only show bridge + spider field if both quests are done
        if (QDone.Any(q => q.ID == World.QUEST_ID_CLEAR_ALCHEMIST_GARDEN) &&
            QDone.Any(q => q.ID == World.QUEST_ID_CLEAR_FARMERS_FIELD))
        {
            mainRow +=
                (playerLocation.ID == World.LOCATION_ID_BRIDGE ? "[B]" : " B ") +
                (playerLocation.ID == World.LOCATION_ID_SPIDER_FIELD ? "[S]" : " S ");
        }

        Console.WriteLine(mainRow);

        // Bottom row
        Console.WriteLine("      " + (playerLocation.ID == World.LOCATION_ID_HOME ? "[H]" : " H "));
    }


    static void WinGame()
    {
        if (QDone.Any(q => q.ID == World.QUEST_ID_CLEAR_SPIDER_FOREST))
        {
            SlowWriteLine("You did it, you have killed those spiders, those monsters. For years, nobody could do it.");
            SlowWriteLine("Now the people will be safe, at least for a while.");
            System.Environment.Exit(0);
        }

    }
}

