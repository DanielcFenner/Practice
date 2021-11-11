using System;

namespace practice_RPGDamageRoll
{
    class Program
    {
        static Random random = new Random();
        static void Main(string[] args)
        {
            SwordDamage swordDamage = new SwordDamage(3);
            ArrowDamage arrowDamage = new ArrowDamage(1);

            while (true)
            {
                Console.WriteLine($"\nS for sword, A for arrow: ");
                char weaponKey = Char.ToUpper(Console.ReadKey().KeyChar);

                Console.WriteLine($"\n0 for no magic/flaming, 1 for magic, 2 for flaming, 3 for both, anything else to quit: ");
                char key = Console.ReadKey().KeyChar;
                if (key != '0' && key != '1' && key != '2' && key != '3') return;

                switch (weaponKey)
                {
                    case 'S':
                        swordDamage.RollDice(5);
                        swordDamage.Magic = (key == '1' || key == '3');
                        swordDamage.Flaming = (key == '2' || key == '3');
                        Console.WriteLine($"\nRolled {swordDamage.Roll} and hit for {swordDamage.Damage} HP \n");
                        break;

                    case 'A':
                        arrowDamage.RollDice(3);
                        arrowDamage.Magic = (key == '1' || key == '3');
                        arrowDamage.Flaming = (key == '2' || key == '3');
                        Console.WriteLine($"\nRolled {arrowDamage.Roll} and hit for {arrowDamage.Damage} HP \n");
                        break;

                    default:
                        return;
                }

            }
        }

    }
}
