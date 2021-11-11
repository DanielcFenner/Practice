using System;
using RandomNameGeneratorLibrary;
using System.Threading;

namespace practice_TwoElephantReferenceSwapping
{
    class Program
    {
        static void Main(string[] args)
        {
            Elephant lucinda = new Elephant() { Name = "Lucinda", EarSize = 44 };
            Elephant lloyd = new Elephant() { Name = "Lloyd", EarSize = 69 };

            string[] commands = new string[7];
            commands[0] = "Press 1 to find out who Lucinda is";
            commands[1] = "Press 2 to find out who Lloyd is";
            commands[2] = "Press 3 to swap Lloyd and Lucinda's object reference";
            commands[3] = "Press 4 to to turn Lloyd into Lucinda, destroying the original Lucinda object";
            commands[4] = "Press 5 to make Lucinda say hi to Lloyd";
            commands[5] = "Press 6 to create 7 elephants with random ear sizes up 420 inches and run a loop to find the one with the biggest ear size";
            commands[6] = "Press Q to exit";


            foreach (var item in commands)
            {
                Console.WriteLine(item);
            }

            while (true)
            {
                char input = Console.ReadKey(true).KeyChar;

                if (input == '1') lucinda.WhoAmI();
                else if (input == '2') lloyd.WhoAmI();
                else if (input == '3')
                {
                    Elephant movingElephant = lucinda;
                    Elephant movingElephant2 = lloyd;
                    lucinda = movingElephant2;
                    lloyd = movingElephant;
                }
                else if (input == '4')
                {
                    lloyd = lucinda;
                    lloyd.EarSize = 420;
                    lloyd.WhoAmI();
                }
                else if (input == '5')
                {
                    lucinda.SpeakTo(lloyd, "Hi, Lloyd!");
                }
                else if (input == '6') // create 69 elephants in an array with random names and ear sizes (up to 420) and loop to find the one with the biggest ear size
                {
                    Random random = new Random();
                    RandomNameGeneratorLibrary.PersonNameGenerator personGen = new PersonNameGenerator();
                    Elephant[] elephants = new Elephant[69];


                    for (int i = 0; i < elephants.Length; i++)
                    {
                        elephants[i] = new Elephant() { Name = personGen.GenerateRandomFemaleFirstAndLastName(), EarSize = random.Next(420) };
                    }


                    Elephant biggestEars = elephants[0];

                    for (int i = 0; i < elephants.Length; i++)
                    {
                        Console.WriteLine($"Checking {elephants[i].Name}'s ear size...");
                        Thread.Sleep(50);

                        if (elephants[i].EarSize > biggestEars.EarSize)
                        {
                            biggestEars = elephants[i];
                            Console.WriteLine($"{biggestEars.Name} has taken the crown for biggest ears at {biggestEars.EarSize.ToString()} inches long!");
                        }

                    }
                    Console.WriteLine($"IT'S CONFIRMED! {biggestEars.Name} has the biggest ears at {biggestEars.EarSize.ToString()} inches long");
                }
                else if (input == 'q' || input == 'Q') return;

            }
        }
    }
}
