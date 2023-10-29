using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankiSzolgaltatasok
{
    public class Kartya : BankiSzolgaltatas
    {
        private String kartyaSzam;
        private Szamla szamla;

        public Kartya(Tulajdonos tulajdonos, Szamla szamla, string kartyaSzam) : base(tulajdonos)
        {
            this.szamla = szamla;
            this.kartyaSzam = kartyaSzam;
        }

        public string KartyaSzam { get => kartyaSzam; }

        public bool Vasarlas (int osszeg)
        {
            return this.szamla.Kivesz(osszeg);
        }
    }
}
