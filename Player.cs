// Fields:
// CurrentHitPoints
// CurrentLocation
// CurrentWeapon
// MaximumHitPoints
// Name
public class Player
{
 
    public int CurrentHitPoints { get; set; }
    public string CurrentLocation { get; set; }
    public string CurrentWeapon { get; set; }
    public int MaximumHitPoints { get; set; }
    public string Name { get; set; }

    public Player(int currentHitPoints, string currentLocation, string currentweapon ,int maximumHitPoints,  string name)
    {
        CurrentHitPoints = currentHitPoints;
        CurrentLocation = currentLocation;
        CurrentWeapon = currentweapon;
        MaximumHitPoints = maximumHitPoints;
        Name = name;
    }
}
