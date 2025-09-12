// Fields:
// ID
// MaximumDamage
// Name
public class Weapon
{
    public int ID;
    public int MaximumDamage;
    public string Name;
    public Weapon(int id, int maximumDamage, string name)
    {
        ID = id;
        MaximumDamage = maximumDamage;
        Name = name;
    }

    public void DisplayWeapon()
    {
        Console.WriteLine($"Weapon ID: {ID}");
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Maximum Damage: {MaximumDamage}");
    }

    public int Attack()
    {
        bool isCritical = random.NextDouble() < 0.2;

        if (isCritical)
        {
            Console.WriteLine("Critical Hit!");
            return MaximumDamage * 2;
        }
        else
        {
            return MaximumDamage;
        }
    }
}