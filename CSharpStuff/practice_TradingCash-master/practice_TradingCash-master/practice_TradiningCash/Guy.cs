using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice_TradingCash
{
    class Guy
    {
        public string Name;
        public int Cash;

        /// <summary>
        /// Writes Guys name and amount of cash he has to the console.
        /// </summary>
        public void WriteMyInfo()
        {
            Console.WriteLine($"{Name} has {Cash} bux.");
        }

        /// <summary>
        /// Gives some cash and removes it from the wallet (or pints a message showing that he doesnt have enough cash)
        /// </summary>
        /// <param name="amount">Amount of cash to give</param>
        /// <returns>The amount of cash removed from my wallet, or 0 if I don't have enough cash</returns>
        public int GiveCash(int amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine($"{Name} says: {amount} isn't a valid amount");
                return 0;
            }
            if (amount > Cash)
            {
                Console.WriteLine($"{Name} says: I don't have enough cash to give you {amount}");
                return 0;
            }
            Cash -= amount;
            return amount;
        }

        /// <summary>
        /// recieve some cash, adding it to my wallet (or printing a message to the console if the amount is invalid
        /// </summary>
        /// <param name="amount">Amount of cash to give</param>
        public void RecieveCash(int amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine($"{Name} says: {amount} isn't an amount I'll take");
            }
            else
            {
                Cash += amount;
            }
        }

    }
}
