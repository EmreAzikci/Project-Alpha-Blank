public class Player
{

    public int CurrentHitPoints;
    public Weapon CurrentWeapon;
    public int MaximumHitPoints;
    public string Name;

    public Player(string name, int currentHitPoints,int maximumHitPoints,Weapon currentWeapon)
    {
        CurrentHitPoints = currentHitPoints;
        CurrentWeapon = currentWeapon;
        MaximumHitPoints = maximumHitPoints;
        Name = name;
    }
}