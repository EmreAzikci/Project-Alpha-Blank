
public class Monster
{
    public int ID { get; set; }
    public string Name { get; set; }
    public int CurrentHitPoints { get; set; }
    public int MaximumHitPoints { get; set; }
    public int MaximumDamage { get; set; }

    public Monster(int id, string name, int maximumDamage, int maximumHitPoints, int currentHitPoints)
    {
        ID = id;
        Name = name;
        CurrentHitPoints = currentHitPoints;
        MaximumHitPoints = maximumHitPoints;
        MaximumDamage = maximumDamage;
    }
}
