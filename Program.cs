using System;
using System.Globalization; // för snygg namnformatering


namespace Adventure
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1A:
            Console.WriteLine("Welcome to the Shadow Rift Adventure");
            Console.Write("Enter your name: ");
            string name = Console.ReadLine();
            name = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(name.ToLower());


            Console.WriteLine($"\nHello, {name}! Nice to meet you!");
            Console.ReadKey();



            // 1B:
            Console.WriteLine("\nChoose your class:\n");
            Console.WriteLine(" 1: Warrior = more Dmg - less HP");
            Console.WriteLine(" 2: Mage    = more HP  - less Dmg\n");
            Console.Write("Your choice?: ");
            string choice = Console.ReadLine();

            Player player;
            if (choice == "2")
            {
                player = new Player(name, "Mage", 55, 5, 0);
            }
            else
            {
                player = new Player(name, "Warrior", 40, 8, 0);
            }

            Console.WriteLine();
            Console.WriteLine("---------- Your Hero ----------");
            ShowStatus(player.Name, player.playerClass, player.Hp, player.MaxHp, player.Damage, player.Gold);
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();

           
            
            // 2:
            string[] enemies = { "Duskyworms", "Voidclaws", "Ashloms sentinels", "Bloodveil Harbingers" };
            Random random = new Random();

           
            
            // 3:
            bool playing = true;
            while (playing)
            {
                Console.WriteLine("\n--- Main Menu ---");
                Console.WriteLine("1: Adventure");
                Console.WriteLine("2: Rest");
                Console.WriteLine("3: Status");
                Console.WriteLine("4: Exit");
                Console.Write("Your Choice: ");
                string menuChoice = Console.ReadLine() ?? "4";

                // 4: Adventure (fiende som enkla variabler)
                if (menuChoice == "1")
                {
                    int enemyIndex = random.Next(enemies.Length);
                    string enemyName = enemies[enemyIndex];


                    Enemy enemy;

                    if (enemyName == "Duskyworms")
                    {
                        enemy = new Enemy("Duskyworms", 35, 3, 1);
                    }
                    else if (enemyName == "Ashloms sentinels")
                    {
                        enemy = new Enemy("Ashloms sentinels", 45,5, 3);
                    }
                    else if (enemyName == "Voidclaws")
                    {
                        enemy = new Enemy("Voidclaws", 45, 6, 4);
                    }
                    else // Bloodveil Harbingers
                    {
                        enemy = new Enemy("Bloodveil Harbingers", 55, 8, 6);
                    }

                    Console.WriteLine($"\nYou choose to go on an Adventure...");
                    Console.WriteLine($"\nA {enemyName} appears! (HP: {enemy.Hp}, Damage: {enemy.Damage}, Gold reward: {enemy.GoldReward})");

                    // 5: Strid
                    while (player.Hp > 0 && enemy.Hp > 0)
                    {
                        Console.WriteLine("\n--- Battle Menu ---");
                        Console.WriteLine("1: Attack");
                        Console.WriteLine("2: Heal");
                        Console.WriteLine("3: Run");
                        Console.Write("Your Choice: ");
                        string battleChoice = Console.ReadLine() ?? "1";

                        
                        if (battleChoice == "1")
                        {
                            enemy.Hp -= player.Damage;
                            if (enemy.Hp < 0) enemy.Hp = 0;

                            Console.WriteLine($"You attacked {enemyName} for {player.Damage} damage!");
                            Console.WriteLine($"{enemyName} now has {enemy.Hp} HP left");
                            if (enemy.Hp <= 0) break;
                        }
                        else if (battleChoice == "2")
                        {
                            int healAmount = 7;
                            player.Hp += healAmount;
                            if (player.Hp > player.MaxHp) player.Hp = player.MaxHp;
                            Console.WriteLine($"You heal yourself for {healAmount} HP. Current HP: {player.Hp}/{player.MaxHp}");
                        }
                        else if (battleChoice == "3")
                        {
                            Console.WriteLine("You run away from the battle!");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid choice, try again");
                            continue;
                        }

                        
                        int enemyHit = enemy.Damage;
                        player.Hp -= enemyHit;
                        if (player.Hp < 0) player.Hp = 0;

                        Console.WriteLine($"{enemyName} strikes back for {enemyHit} damage! Your HP: {player.Hp}/{player.MaxHp}");

                        if (player.Hp <= 0) break;
                    }



                    // 6:
                    if (enemy.Hp <= 0)
                    {
                        Console.WriteLine($"\nThe {enemyName} is defeated!");
                        player.Gold += enemy.GoldReward;
                        Console.WriteLine($"{enemy.GoldReward} gold! You now have {player.Gold} gold.");
                        ShowStatus(player.Name, player.playerClass, player.Hp, player.MaxHp, player.Damage, player.Gold);
                    }
                    else if (player.Hp <= 0)
                    {
                        Console.WriteLine("\nYou were defeated...");
                        Console.WriteLine("Game Over...");
                        playing = false;
                    }
                    else
                    {
                        
                        ShowStatus(player.Name, player.playerClass, player.Hp, player.MaxHp, player.Damage, player.Gold);
                    }
                }
              
                
                else if (menuChoice == "2")
                {
                    // 7: Rest
                    Console.WriteLine("You take a rest...");
                    int healAmount = 15;
                    player.Hp += healAmount;
                    if (player.Hp > player.MaxHp) player.Hp = player.MaxHp;
                    Console.WriteLine($"You recovered {healAmount} HP.");
                    ShowStatus(player.Name, player.playerClass, player.Hp, player.MaxHp, player.Damage, player.Gold);
               
                
                }
              
                
                else if (menuChoice == "3")
                {
                    // 8: Status
                    ShowStatus(player.Name, player.playerClass, player.Hp, player.MaxHp, player.Damage, player.Gold);
                }
                else if (menuChoice == "4")
                {
                    Console.WriteLine("You exit the game: Goodbye");
                    playing = false;
                }
                else
                {
                    Console.WriteLine("Invalid Choice, try again!");
                }
            }
        }

        // 9A: Showstatus
        static void ShowStatus(string name, string playerClass, int hp, int maxHp, int damage, int gold)
        {
            Console.Write($"Status: {name} ({playerClass})  ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"HP: {hp}/{maxHp}  ");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"Damage: {damage}  ");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Gold: {gold}");
            Console.ResetColor();

        }
    }
}
