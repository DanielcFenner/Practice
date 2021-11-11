using System;

namespace practice_BirdEggsInheritancePractice
{
    class Bird
    {
        public static Random Randomizer = new Random();
        public virtual Egg[] LayEggs(int numberOfEggs)
        {
            Console.Error.WriteLine("Bird.LayEggs should never get called");
            return new Egg[0];
        }
    }
    class Pigeon : Bird
    {
        public override Egg[] LayEggs(int numberOfEggs)
        {
            if (numberOfEggs > 2) numberOfEggs = 2;
            Egg[] eggs = new Egg[numberOfEggs];
            for (int i = 0; i < numberOfEggs; i++)
            {
                if (Randomizer.Next(4) == 0)
                    eggs[i] = new BrokenEgg("white");
                else
                    eggs[i] = new Egg(Randomizer.NextDouble() * 2 + 1, "white");
            }
            return eggs;
        }
    }

    class Ostrich : Bird
    {
        public override Egg[] LayEggs(int numberOfEggs)
        {
            Egg[] eggs = new Egg[numberOfEggs];
            for (int i = 0; i < numberOfEggs; i++)
            {
                if (Randomizer.Next(4) == 0)
                    eggs[i] = new BrokenEgg("speckled");
                else
                    eggs[i] = new Egg(Randomizer.NextDouble() + 13, "speckled");
            }
            return eggs;
        }
    }
}
