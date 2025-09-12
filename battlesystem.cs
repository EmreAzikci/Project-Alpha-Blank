// See https://aka.ms/new-console-template for more information


public static partial class Program
{
    public static bool Battle(Player player, Monster monster, Weapon Weapon)
    {    //Handles battle logic between player and monster.//
        bool is_alive(int hitpoints)
        {
            if (hitpoints > 0)
                return true;
            else
                return false;
        }

        Console.WriteLine($"A wild {monster.Name} appears!");

        while (is_alive(player.CurrentHitPoints) && is_alive(monster.CurrentHitPoints))
        {
            Console.WriteLine($"You: {player.CurrentHitPoints} HP | {monster.Name}: {monster.MaximumHitPoints} HP");
            Console.WriteLine("Choose action: Attack , Use health potion, Dodge");
            string choice = Console.ReadLine();

            if (choice == "Attack")
            {
                int damage1 = Weapon.maximum_damage;
                monster.CurrentHitPoints -= damage1;
                Console.WriteLine(
                    $"You dealt {damage1} damage with {player.CurrentWeapon}!");
            }
            else if (choice == "Use Elixir")
            {
                player.CurrentHitPoints += 20;
                Console.WriteLine("You used a health potion and restored 20 HP!");
            }
            else if (choice == "Dodge")
            {
                Random rand = new Random();
                int dodgeChance = rand.Next(0, 2); // 50% chance to dodge
                if (dodgeChance == 1)
                {
                    Console.WriteLine("You successfully dodged the attack!");
                    continue; // Skip monster's turn
                }
                else
                {
                    Console.WriteLine("Dodge failed!");
                }
            }
            else
            {
                Console.WriteLine("Invalid action. Try again.");
                continue;
            }
            // Monster retaliates if still alive
            if (is_alive(monster.CurrentHitPoints))
            {
                int retaliation = monster.MaximumDamage;
                player.CurrentHitPoints -= retaliation;
                Console.WriteLine($"{monster.Name} hits you for {retaliation} damage!");
            }
        }

        if (!is_alive(player.CurrentHitPoints))
        {
            Console.WriteLine("You have been defeated!");
            return false;
        }
        else
        {
            Console.WriteLine($"Defeated {monster.Name}!");
            return true;
        }
    }
}

