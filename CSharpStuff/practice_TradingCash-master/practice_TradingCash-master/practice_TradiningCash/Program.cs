using System;

namespace practice_TradingCash
{
    class Program
    {
        static void Main(string[] args)
        {
            Guy joe = new Guy() { Cash = 50, Name = "Joe" };
            Guy bob = new Guy() { Cash = 100, Name = "Bob" };

            while (true)
            {


                bob.WriteMyInfo();
                joe.WriteMyInfo();

                Console.WriteLine("Enter an amount:");
                string howMuch = Console.ReadLine();

                if (howMuch == "") return;
                if (int.TryParse(howMuch, out int howMuchChecked))                
                    {
                        Console.WriteLine("Who should give the cash:");
                        string whichGuy = Console.ReadLine();
                        if (whichGuy.ToLower() == "joe") 
                        {
                        int cashGiven = joe.GiveCash(howMuchChecked);
                        bob.RecieveCash(howMuchChecked);

                        }
                    else if (whichGuy.ToLower() == "bob")
                        {

                        int cashGiven = bob.GiveCash(howMuchChecked);
                        joe.RecieveCash(howMuchChecked);
                    }
                        else
                        {
                            Console.WriteLine("Please enter either 'Joe' or 'Bob'");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Please enter an amount (or blank space to exit).");
                    }
                }
            }
        }
    }

