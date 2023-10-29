using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankiSzolgaltatasok
{
    public abstract class Szamla : BankiSzolgaltatas
    {
        protected int aktualisEgyenleg;

        protected Szamla(Tulajdonos tulajdonos) : base(tulajdonos)
        {
        }

        public int AktualisEgyenleg { get => aktualisEgyenleg; }
        

        public void Befizet(int osszeg)
        {
            if (osszeg >= 0)
            {
                this.aktualisEgyenleg += osszeg;
            }
        }

        public abstract bool Kivesz(int osszeg);

        public Kartya UjKartya(String kartyaSzam)
        {
            return new Kartya(this.Tulajdonos, this, kartyaSzam);
        }
    }
}
