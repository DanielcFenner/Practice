using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practiceSloppyJoesDiscountSandwiches
{
    class MenuItem
    {
        public static Random Randomizer = new Random();

        public string[] Proteins = { "Refried beans", "Tofu", "Lentils", "Beyond Burger", "Impossible meat", "Dodgy knock off beyond burger" };

        public string[] Condiments = { "franks hot sauce", "cashew cheese sauce", "italian dressing", "thick chocolate sauce", "mustard" };

        public string[] Breads = { "white Bread", "whole Wheat Bread", "a roll", "rye bread", "rour dough bread", "italian cheese bread" };

        public string GenerateMenuItem()
        {
            string randomProtein = Proteins[Randomizer.Next(Proteins.Length)];
            string randomCondiment = Condiments[Randomizer.Next(Condiments.Length)];
            string randomBread = Breads[Randomizer.Next(Breads.Length)];
            return $"{randomProtein} with {randomCondiment} on {randomBread}";
        }

        public string RandomPrice()
        {
            decimal bucks = Randomizer.Next(2, 5);
            decimal cents = Randomizer.Next(1, 98);
            decimal price = bucks + (cents * .01M);
            return price.ToString("c");
        }


    }

}
