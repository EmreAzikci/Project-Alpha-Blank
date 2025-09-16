public class Monster
{
    public int ID;
    public string Name;
    public int MaximumDamage;
    public int CurrentHitPoints;
    public int MaximumHitPoints;


    public Monster(int id, string name, int maximumDamage, int maximumHitPoints, int currentHitPoints)
    {
        ID = id;
        Name = name;
        MaximumDamage = maximumDamage;
        MaximumHitPoints = maximumHitPoints;
        CurrentHitPoints = currentHitPoints;
    }
}