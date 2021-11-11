using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice_InterfacesTallGuy
{
    interface IClown // interfaces are public and abstract by default
    {
        public string FunnyThingIHave { get; }
        void Honk();
    }
}
