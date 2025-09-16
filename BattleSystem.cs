public class BattleSystem

{
        public static bool Battle(Player player, Monster monster, Weapon weapon)
        {
                bool IsAlive(int hitPoints) => hitPoints > 0;

                Console.WriteLine($"A wild {monster.Name} appears!");

                while (IsAlive(player.CurrentHitPoints) && IsAlive(monster.CurrentHitPoints))
                {
                        int playerChoice = 0;
                        int maxChoice = Program.potions.Any() ? 3 : 2;

                        // Player chooses action
                        do
                        {
                                Console.Write($"You: {player.CurrentHitPoints} HP | {monster.Name}: {monster.CurrentHitPoints} HP\n");
                                Console.Write("Choose action: [1] Attack, [2] Dodge");
                                if (maxChoice == 3)
                                {
                                        Console.Write(" , [3] Use Health Potion");
                                }
                                Console.WriteLine();

                                playerChoice = Convert.ToInt32(Console.ReadLine());

                        } while (playerChoice < 1 || playerChoice > maxChoice);

                        // Player action
                        if (playerChoice == 1) // Attack
                        {
                                int damage = weapon.MaximumDamage;
                                Random ranAtt = new Random();
                                bool isCritical = ranAtt.NextDouble() < 0.2;

                                if (isCritical)
                                {
                                        Console.WriteLine("Critical Hit!");
                                        damage = weapon.MaximumDamage * 2;
                                }
                                else
                                {
                                        damage = weapon.MaximumDamage;
                                }
                                monster.CurrentHitPoints -= damage;
                                Console.WriteLine($"You dealt {damage} damage with {player.CurrentWeapon.Name}!");
                        }
                        else if (playerChoice == 2) // Dodge
                        {
                                Random rand = new Random();
                                int dodgeChance = rand.Next(2);
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
                        else if (playerChoice == 3) // Potion
                        {
                                player.CurrentHitPoints += 10;
                                Console.WriteLine("You used a health potion and restored 10 HP!");
                                Program.potions.Remove("HealthPotion");
                        }

                        // Monster retaliates
                        if (IsAlive(monster.CurrentHitPoints))
                        {
                                int retaliation = monster.MaximumDamage;
                                player.CurrentHitPoints -= retaliation;
                                Console.WriteLine($"{monster.Name} hits you for {retaliation} damage!");
                        }
                }

                // End of battle 
                if (!IsAlive(player.CurrentHitPoints))
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



        public static void BattleQuest(Location playerLocation)
        {
                Quest currentQuest = null;
                Monster monster = null;
                int battles = 3;

                if (playerLocation.ID == World.LOCATION_ID_FARM_FIELD && Program.QNotDone.Any(q => q.ID == World.QUEST_ID_CLEAR_FARMERS_FIELD))
                {
                        currentQuest = World.QuestByID(World.QUEST_ID_CLEAR_FARMERS_FIELD);
                        monster = World.MonsterByID(World.MONSTER_ID_SNAKE);
                }
                else if (playerLocation.ID == World.LOCATION_ID_ALCHEMISTS_GARDEN && Program.QNotDone.Any(q => q.ID == World.QUEST_ID_CLEAR_ALCHEMIST_GARDEN))
                {
                        currentQuest = World.QuestByID(World.QUEST_ID_CLEAR_ALCHEMIST_GARDEN);
                        monster = World.MonsterByID(World.MONSTER_ID_RAT);
                }
                else if (playerLocation.ID == World.LOCATION_ID_SPIDER_FIELD && Program.QNotDone.Any(q => q.ID == World.QUEST_ID_CLEAR_SPIDER_FOREST))
                {
                        currentQuest = World.QuestByID(World.QUEST_ID_CLEAR_SPIDER_FOREST);
                        monster = World.MonsterByID(World.MONSTER_ID_GIANT_SPIDER);
                }

                if (currentQuest != null && monster != null)
                {
                        for (int i = 0; i < battles; i++)
                        {
                                monster.CurrentHitPoints = monster.MaximumHitPoints;
                                Battle(Program.player, monster, Program.player.CurrentWeapon);
                        }
                        Program.QNotDone.Remove(currentQuest);
                        Program.QDone.Add(currentQuest);
                }
        }
}