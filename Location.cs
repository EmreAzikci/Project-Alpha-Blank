public class Location
{
    public int ID { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    // Add these when the classes are done:
        // public Quest QuestAvailableHere { get; set; }
        // public Monster MonsterLivingHere { get; set; }

    public Location LocationToNorth { get; set; }
    public Location LocationToSouth { get; set; }
    public Location LocationToEast { get; set; }
    public Location LocationToWest { get; set; }

    public Location(int id, string name, string description)
    // Add these later into parameters:
        // Quest questAvailableHere = null,
        // Monster monsterLivingHere = null
    {
        ID = id;
        Name = name;
        Description = description;
        // add these later:
            // QuestAvailableHere = questAvailableHere;
            // MonsterLivingHere = monsterLivingHere;
    }

    public override string ToString()
    {
        return Name;
    }
}