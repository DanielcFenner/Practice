using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice_TwoElephantReferenceSwapping
{
    class Elephant
    {
        public string Name;
        public int EarSize;

        public void WhoAmI()
        {
            Console.WriteLine($"I am {Name}");
            Console.WriteLine($"My ears are {EarSize} inches long");

        }

        public void HearMessage(string message, Elephant whoSaidIt)
        {
            Console.WriteLine($"{Name} heard a message");
            Console.WriteLine($"{whoSaidIt.Name} said this: {message}");
        }

        public void SpeakTo(Elephant whoToTalkTo, string message)
        {
            whoToTalkTo.HearMessage(message, this);
        }
    }
}
