using System;

namespace practice_RPGDamageRoll
{
    class WeaponDamage
    {
        /// <summary>
        /// Constructor. Calculates damage based on default magic and flaming values and a starting roll.
        /// </summary>
        /// <param name="startingRoll">Starting 3d6 roll</param>
        public WeaponDamage(int startingRoll)
        {
            roll = RollDice(startingRoll);
            CalculateDamage();
        }


        int roll;
        /// <summary>
        /// Sets or gets the 3d6 roll.
        /// </summary>
        public int Roll
        {
            get { return roll; }
            set { roll = value; CalculateDamage(); }
        }

        bool flaming;
        /// <summary>
        /// True if the sword is flaming, false otherwise.
        /// </summary>
        public bool Flaming
        {
            get { return flaming; }
            set { flaming = value; CalculateDamage(); }
        }

        bool magic;
        /// <summary>
        /// True if the sword is magic, false otherwise.
        /// </summary>
        public bool Magic
        {
            get { return magic; }
            set { magic = value; CalculateDamage(); }
        }

        /// <summary>
        /// Contains the calculated damage
        /// </summary>
        public int Damage { get; protected set; }

        /// <summary>
        /// Calculates the damage based on the current properties. Can be private because it just updates the Damage property.
        /// </summary>
        protected virtual void CalculateDamage()
        {
            // Damage calculation is set by the subclasses
        }

        static Random random = new Random();
        /// <summary>
        /// Rolls the amount of d6 entered as the argument
        /// </summary>
        /// <param name="numberOfRolls">Amount of d6 to roll</param>
        /// <returns></returns>
        public int RollDice(int numberOfRolls)
        {
            int total = 0;
            for (int i = 0; i < numberOfRolls; i++)
            {
                total += random.Next(1, 7);
            }
            return total;


        }
    }

    class SwordDamage : WeaponDamage
    {
        public SwordDamage(int startingRoll) : base(startingRoll) { }

        const int BASE_DAMAGE = 3;
        const int FLAME_DAMAGE = 2;

        protected override void CalculateDamage()
        {
            var magicMultiplier = 1M;
            if (Magic) magicMultiplier = 1.75M;

            Damage = (int)(Roll * magicMultiplier) + BASE_DAMAGE;
            if (Flaming) Damage += FLAME_DAMAGE;
        }
    }

    class ArrowDamage : WeaponDamage
    {
        
        public ArrowDamage(int startingRoll) : base(startingRoll) { }

        protected const decimal FLAME_DAMAGE = 1.25M;
        protected const decimal BASE_MULTIPLIER = 0.35M;
        protected const decimal MAGIC_MULTIPLIER = 2.5M;
        protected override void CalculateDamage()
        {
            decimal baseDamage = Roll * BASE_MULTIPLIER;
            if (Magic) baseDamage *= MAGIC_MULTIPLIER;
            if (Flaming) Damage = (int)Math.Ceiling(baseDamage + FLAME_DAMAGE);
            else Damage = (int)Math.Ceiling(baseDamage);
        }
    }

}

