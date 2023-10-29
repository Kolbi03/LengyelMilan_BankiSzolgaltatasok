using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankiSzolgaltatasok
{
    public class Bank
    {
        private List<Szamla> szamlaLista;

        public Bank()
        {
            this.szamlaLista = new List<Szamla>();
        }

        public long OsszHitelkeret
        {
            get
            {
                long osszKeret = 0;
                foreach (Szamla item in szamlaLista)
                {
                    if (item.GetType() == typeof(HitelSzamla))
                    {
                        HitelSzamla sz = (HitelSzamla)item;
                        osszKeret += sz.HitelKeret;
                    }
                }
                return osszKeret;
            }
        }

        public Szamla GetLegnagyobbEgyenleguSzamla(Tulajdonos tulajdonos)
        {
            Szamla sz = this.szamlaLista[0];
            int maxEgyenleg = 0;
            foreach (Szamla item in szamlaLista)
            {
                if (item.Tulajdonos == tulajdonos && maxEgyenleg < item.AktualisEgyenleg)
                {
                    sz = item;
                    maxEgyenleg = item.AktualisEgyenleg;
                }
            }
            return sz;
        }

        public long GetOsszEgyenleg(Tulajdonos tulajdonos)
        {
            long osszEgyenleg = 0;
            foreach (Szamla item in szamlaLista)
            {
                if (item.Tulajdonos == tulajdonos)
                {
                    osszEgyenleg += item.AktualisEgyenleg;
                }
            }
            return osszEgyenleg;
        }

        public Szamla SzamlaNyitas(Tulajdonos tulajdonos, int hitelKeret)
        {
            if (hitelKeret < 0)
            {
                throw new ArgumentException("Nem lehet negatív", nameof(hitelKeret));
            }
            else if (hitelKeret == 0)
            {
                MegtakaritasiSzamla m = new MegtakaritasiSzamla(tulajdonos);
                szamlaLista.Add(m);
                return m;
            }
            else
            {
                HitelSzamla h = new HitelSzamla(tulajdonos, hitelKeret);
                szamlaLista.Add(h);
                return h;
            }
        }
    }
}
