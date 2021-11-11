using System;

namespace practice_HiLoGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Welcome to HiLo. You have to guess whether the next random number between 1 and {HiLoGame.MAXIMUM} will be higher or lower than the current number");
            HiLoGame.Hint();
            while (HiLoGame.GetPot() > 0)
            {
                Console.WriteLine("Press h for higher, 1 for lower ? to buy a hint,");
                Console.WriteLine($"or any other key to quit with ${HiLoGame.GetPot()}");
                char key = Console.ReadKey(true).KeyChar;
                if (key == 'h') HiLoGame.Guess(true);
                else if (key == '1') HiLoGame.Guess(false);
                else if (key == '?') HiLoGame.Hint();
                else return;
            }
            Console.WriteLine("The pot is empty. Bye!");
        }
    }
}
