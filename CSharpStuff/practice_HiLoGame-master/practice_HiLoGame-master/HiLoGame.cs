using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice_HiLoGame
{
    static class HiLoGame
    {
        public const int MAXIMUM = 10;
        private static Random random = new Random();
        private static int currentNumber = random.Next(1, MAXIMUM + 1);
        private static int pot = 10;

        public static void Guess(bool higher)
        {
            int nextNumber = random.Next(MAXIMUM);
            if (higher && nextNumber >= currentNumber)
            {
                Console.Write($"You guessed right! The number was {nextNumber}, $1 added to the pot.");
                pot++;
            }
            else if (higher && nextNumber <= currentNumber)
            {
                Console.WriteLine($"Bad luck, you guessed wrong. The number was {nextNumber}, $1 removed from the pot");
                pot--;
            }
            else if (!higher && nextNumber >= currentNumber)
            {
                Console.WriteLine($"Bad luck, you guessed wrong. The number was {nextNumber}, $1 removed from the pot");
                pot--;
            }
            else if (!higher && nextNumber <= currentNumber)
            {
                Console.WriteLine($"You guessed right! The number was {nextNumber}, $1 added to the pot.");
                pot++;
            }
            currentNumber = nextNumber;
            Console.WriteLine($"The current number is {currentNumber}");
        }

        public static int GetPot()
        {
            return pot;
        }

        public static void Hint()
        {
            int findHint = MAXIMUM / 2;
            if (currentNumber >= findHint) Console.WriteLine($"The number is at least {findHint}");
            else Console.WriteLine($"The number is at most {findHint}");
            pot--;
        }

    }
}
