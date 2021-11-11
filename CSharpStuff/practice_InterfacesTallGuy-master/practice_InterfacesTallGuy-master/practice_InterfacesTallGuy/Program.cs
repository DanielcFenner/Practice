using System;

namespace practice_InterfacesTallGuy
{
    class Program
    {
        static void Main(string[] args)
        {
            TallGuy tallGuy = new TallGuy() { Height = 74, Name = "Johnson" };
            tallGuy.TalkAboutYourself();
            Console.WriteLine($"The tall guy has {tallGuy.FunnyThingIHave}");
            tallGuy.Honk();
        }
    }
}
