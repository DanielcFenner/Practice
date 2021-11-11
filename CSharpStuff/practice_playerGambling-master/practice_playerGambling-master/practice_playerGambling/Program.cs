using System;

namespace practice_playerGambling
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new();
            double odds = .75;

            Console.WriteLine("Welcome to the casino, please enter your name:");
            string name = Console.ReadLine();
            Player player = new Player() { Name = name, Cash = 100 };
            
            while (player.Cash > 0)
            {
                    player.WriteMyInfo();
                    Console.WriteLine($"How much would you like to bet, {player.Name}?:");
                    string howMuch = Console.ReadLine();

                    if (int.TryParse(howMuch, out int amount))
                    {
                        int pot = player.GiveCash(amount) * 2;

                            if (random.NextDouble() > odds)
                            {
                                Console.WriteLine($"You win ${pot}!");
                            player.RecieveCash(pot);
                            }
                            else
                            {
                                Console.WriteLine($"You lost ${amount}");
                            }
                    }
                    else 
                {
                    Console.WriteLine("Please enter a valid number");
                }

            }

            Console.WriteLine("You have no money. You're broke. Zero dollars. Go home. The casino ALWAYS wins");


        }
    }
}
