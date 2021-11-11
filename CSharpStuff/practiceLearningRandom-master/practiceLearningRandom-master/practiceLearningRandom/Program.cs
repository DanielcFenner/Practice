using System;

namespace practiceLearningRandom
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            int randomInt = random.Next();
            Console.WriteLine(randomInt);

            int zeroToNine = random.Next(10);
            Console.WriteLine(zeroToNine);

            int dieRoll = random.Next(1, 7);
            Console.WriteLine(dieRoll);

            double randomDouble = random.NextDouble(); // random.NextDouble creates a double from 0.0 to 1.0
            Console.WriteLine(randomDouble * 100); // you can multiply to get a bigger number
            Console.WriteLine((float)randomDouble * 100F); // and cast to turn it into another type
            Console.WriteLine((decimal)randomDouble * 100M); // and cast to turn it into another type

            int zeroOrOne = random.Next(2);
            bool CoinFlip = Convert.ToBoolean(zeroOrOne); // can use Next(2) to create a true or false boolean
            Console.WriteLine(CoinFlip);

            string[] pepe = new string[3];
            pepe[0] = "peepoClap";
            pepe[1] = "FeelsGoodMan";
            pepe[2] = "Sadge";

            Console.WriteLine(pepe[random.Next(pepe.Length)]); // BRAIN POWER using random to get a random string from the pepe array



        }
    }
}
