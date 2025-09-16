public class Weapon
{
    public int ID;
    public int MaximumDamage;
    public string Name;
    public Weapon(int id, string name, int maximumDamage)
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
}