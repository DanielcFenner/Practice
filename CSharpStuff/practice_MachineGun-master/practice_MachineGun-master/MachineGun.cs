using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice_MachineGun
{
    class MachineGun
    {
        public int MagazineSize { get; private set; } = 16;

        int bullets = 0;
        public int BulletsLoaded { get; private set; }

        public bool IsEmpty() { return BulletsLoaded == 0;  }

        public int Bullets
        {
            get { return bullets; }
            set
            {
                if (value > 0)
                    bullets = value;
            }
        }

        public void Reload()
        {
            if (bullets > MagazineSize)
            {
                BulletsLoaded = MagazineSize;
            }
            else
            {
                BulletsLoaded = bullets;
            }
            Console.WriteLine("Reloading...");
            System.Threading.Thread.Sleep(1000);
        }

        public bool Shoot()
        {
            if (BulletsLoaded == 0) return false;
            BulletsLoaded--;
            bullets--;
            return true;
        }

        public MachineGun(int bullets, int magazineSize, bool loaded)
        {
            this.bullets = bullets;
            MagazineSize = magazineSize;
            BulletsLoaded = magazineSize;
            if (!loaded) Reload();
        }
    }
}
