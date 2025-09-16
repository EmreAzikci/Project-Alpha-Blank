public class Quest
{
    public int ID;
    public string Description;
    public string Title;

    public Quest(int id, string title, string description)
    {
        ID = id;
        Description = description;
        Title = title;

    }

    public static void CheckLocAndQuest(Location playerLocation)
    {
        if (playerLocation.ID == World.LOCATION_ID_FARMHOUSE)
        {
            if (Program.QDone.Any(q => q.ID == World.QUEST_ID_CLEAR_FARMERS_FIELD))
            {
                Program.SlowWriteLine("Thanks, kid, here have this …”");
                Program.player.CurrentWeapon = World.WeaponByID(World.WEAPON_ID_DIAMOND_SWORD);
                Program.SlowWriteLine("I heard the alchemist had some problems herself with monsters. Go help her");
            }
            else if (Program.QNotDone.Any(q => q.ID == World.QUEST_ID_CLEAR_FARMERS_FIELD))
            {
                Console.WriteLine("Kill the snakes for the farmer!");
            }
            else
            {
                Program.SlowWriteLine("Oi, youngling, what are you doing here?! Yelled the farmer");
                Program.SlowWriteLine("You replied with: 'I came to ask you for a weapon, sir. I want to slay those monsters.'");
                Program.SlowWriteLine("You are stupid, but I might have something lying around from my good old days");
                Program.SlowWriteLine("But I have a small problem myself, and I am way too old to do it myself; some goddamn snakes are eating my chickens");
                Program.SlowWriteLine("I want them gone; I can't work my own land with those pesky snakes slith'ring around!");
                Program.SlowWriteLine("After you kill those snakes, I will give you the best weapon I have lying around");
                Program.SlowWriteLine("So, what do you say, boy?");
                Program.SlowWriteLine("Of course sir, you replied.");
                Program.QNotDone.Add(World.QuestByID(World.QUEST_ID_CLEAR_FARMERS_FIELD)); ;
            }
        }
        if (playerLocation.ID == World.LOCATION_ID_ALCHEMIST_HUT)
        {
            if (Program.QDone.Any(q => q.ID == World.QUEST_ID_CLEAR_ALCHEMIST_GARDEN))
            {
                Program.SlowWriteLine("The herbs can grow now without any pests eating them");
                Program.SlowWriteLine("Thank you, honey, here, this might help you when in distress.");
                Program.potions.Add("HealthPotion");
            }
            else if (Program.QNotDone.Any(q => q.ID == World.QUEST_ID_CLEAR_ALCHEMIST_GARDEN))
            {
                Console.WriteLine("Kill the rats eating the plants!");
            }
            else
            {
                Program.SlowWriteLine("Hi, honey, good to see you here. I need your help; said the alchemist.");
                Program.SlowWriteLine("I have been struggling with some extra chonky rats'");
                Program.SlowWriteLine("Those rats are nibbling on my own herbs, I couldst very much useth an adventur'r to taketh careth of those folk …");
                Program.SlowWriteLine("I have fewer supplies now to heal people who have been attacked by monsters");
                Program.SlowWriteLine("So, adventurer, if you help me, I might give you something useful or even valuable");
                Program.SlowWriteLine("Will you help a poor woman in distress?");
                Program.SlowWriteLine("Of course miss, you replied.");
                Program.QNotDone.Add(World.QuestByID(World.QUEST_ID_CLEAR_ALCHEMIST_GARDEN));
            }
        }
        if (playerLocation.ID == World.LOCATION_ID_GUARD_POST)
        {
            if (Program.QDone.Any(q => q.ID == World.QUEST_ID_CLEAR_ALCHEMIST_GARDEN) && Program.QDone.Any(q => q.ID == World.QUEST_ID_CLEAR_FARMERS_FIELD))
            {
                Program.SlowWriteLine("The forest is just across the bridge");
                Program.SlowWriteLine("I hope you know what you’re walking into… many have gone, none returned.");
                Program.QNotDone.Add(World.QuestByID(World.QUEST_ID_CLEAR_SPIDER_FOREST));
            }
            else
            {
                Program.SlowWriteLine("Kid, please, turn back at once unless thee hast proof of thy grit");
                Program.SlowWriteLine("You need to solve the problem with some smaller monsters of the farmer and the alchemist");
                Program.SlowWriteLine("They should give you something as proof that you solved their problems");
                return;
            }
        }
    }
}

