using System;

namespace practcing_RPGDamageRollWPF
{
    class SwordDamage
    {
        /// <summary>
        /// Constructor. Calculates damage based on default magic and flaming values and a starting roll.
        /// </summary>
        /// <param name="startingRoll">Starting 3d6 roll</param>
        public SwordDamage(int startingRoll)
        {
            roll = startingRoll;
            CalculateDamage();
        }

        private const int BASE_DAMAGE = 3;
        private const int FLAME_DAMAGE = 2;

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
        public int Damage { get; private set; }

        /// <summary>
        /// Calculates the damage based on the current properties. Can be private because it just updates the Damage property.
        /// </summary>
        private void CalculateDamage()
        {
            var magicMultiplier = 1M;
            if (magic) magicMultiplier = 1.75M;

            Damage = (int)(Roll * magicMultiplier) + BASE_DAMAGE;
            if (flaming) Damage += FLAME_DAMAGE;
        }
    }
}

