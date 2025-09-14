public class Quest
{
    public string Name;
    public string Description;
    public string Location;
    public int RequiredKills;
    public int CurrentKills;
    public bool IsCompleted;

    public Quest(string name, string description, string location, int requiredKills)
    {
        Name = name;
        Description = description;
        Location = location;
        RequiredKills = requiredKills;
        CurrentKills = 0;
        IsCompleted = false;
    }

    public void RecordKill()
    {
        if (!IsCompleted)
        {
            CurrentKills = CurrentKills + 1;
            Console.WriteLine($"Progress on '{Name}': {CurrentKills}/{RequiredKills}");

            if (CurrentKills >= RequiredKills)
            {
                IsCompleted = true;
                Console.WriteLine($"Quest '{Name}' completed!");
            }
        }
    }
}

public class NPC
{
    public string Name;
    public string Dialogue;
    public Quest QuestToGive;

    public NPC(string name, string dialogue, Quest quest)
    {
        Name = name;
        Dialogue = dialogue;
        QuestToGive = quest;
    }
}

public class GuardNPC
{
    public string Name = "Guard";
    public string Dialogue = "Turn back at once, peasant! Unless thee hast proof of thy grit.";

    public void CheckAccess(Quest farmerQuest, Quest alchemistQuest)
    {
        if (farmerQuest.IsCompleted && alchemistQuest.IsCompleted)
        {
            Console.WriteLine($"{Name}: Very well, you may pass...");
        }
        else
        {
            Console.WriteLine($"{Name}: {Dialogue}");
        }
    }
}


public static class QuestFunctions
{
    public static Quest FarmerQuest(Quest activeQuest, Quest farmerQuest, NPC farmer)
    {
        if (activeQuest != null && !activeQuest.IsCompleted)
        {
            Console.WriteLine($"Finish your current quest '{activeQuest.Name}' first!");
            return activeQuest;
        }

        Console.WriteLine($"{farmer.Name} says: \"{farmer.Dialogue}\"");
        Console.WriteLine($"Quest received: {farmerQuest.Name} - {farmerQuest.Description}");
        return farmerQuest;
    }

    public static Quest AlchemistQuest(Quest activeQuest, Quest alchemistQuest, NPC alchemist)
    {
        if (activeQuest != null && !activeQuest.IsCompleted)
        {
            Console.WriteLine($"Finish your current quest '{activeQuest.Name}' first!");
            return activeQuest;
        }

        Console.WriteLine($"{alchemist.Name} says: \"{alchemist.Dialogue}\"");
        Console.WriteLine($"Quest received: {alchemistQuest.Name} - {alchemistQuest.Description}");
        return alchemistQuest;
    }

    public static Quest SpiderQuest(Quest activeQuest, Quest spiderQuest, NPC spiderSpirit)
    {
        if (activeQuest != null && !activeQuest.IsCompleted)
        {
            Console.WriteLine($"Finish your current quest '{activeQuest.Name}' first!");
            return activeQuest;
        }

        Console.WriteLine($"{spiderSpirit.Name} says: \"{spiderSpirit.Dialogue}\"");
        Console.WriteLine($"Quest received: {spiderQuest.Name} - {spiderQuest.Description}");
        return spiderQuest;
    }
}
