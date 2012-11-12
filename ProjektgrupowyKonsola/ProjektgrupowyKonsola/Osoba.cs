using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjektGrupowy
{
    [Serializable]
    public class Osoba
    {
        public string Imie;
        public string Nazwisko;
        public int RokUrodzenia;
        public int MiesiacUrodzenia;
        public int DzienUrodzenia;
        public int Plec;
        public string PESEL;
        public int wartosoby;

        public Osoba() { }

        public Osoba(string imie, string nazwisko, int rokurodzenia, int miesiacurodzenia, int dzienurodzenia, int plec, string PESEL, int wartosoby)
        {
            this.Imie = imie;
            this.Nazwisko = nazwisko;
            this.RokUrodzenia = rokurodzenia;
            this.MiesiacUrodzenia = miesiacurodzenia;
            this.DzienUrodzenia = dzienurodzenia;
            this.Plec = plec;
            this.PESEL = PESEL;
            this.wartosoby = wartosoby;
        }
        public class PoRoku : IComparer<Osoba>
        {
            public int Compare(Osoba x, Osoba y)
            {
                return x.RokUrodzenia.CompareTo(y.RokUrodzenia);
            }
        }

        public class PoMiesiacu : IComparer<Osoba>
        {
            public int Compare(Osoba x, Osoba y)
            {
                return x.MiesiacUrodzenia.CompareTo(y.MiesiacUrodzenia);
            }
        }

        public class PoDniu : IComparer<Osoba>
        {
            public int Compare(Osoba x, Osoba y)
            {
                return x.DzienUrodzenia.CompareTo(y.DzienUrodzenia);
            }
        }

        private string ZwrocOsobe(Osoba os)
        {
            if (os.Plec == 1)
                return string.Format("Pan {0} {1}, urodzony dnia {2} miesiaca {3} roku {4} PESEL: {5}", os.Imie, os.Nazwisko, os.DzienUrodzenia, os.MiesiacUrodzenia, os.RokUrodzenia, os.PESEL);
            else
                return string.Format("Pani {0} {1}, urodzona dnia{2} miesiaca {3} roku {4} PESEL: {5}", os.Imie, os.Nazwisko, os.DzienUrodzenia, os.MiesiacUrodzenia, os.RokUrodzenia, os.PESEL);
        }

        public void WyswietlOsobe(Osoba os)
        {
            if (os.Plec == 1)
                Console.WriteLine("Pan {0} {1}, urodzony dnia {2} miesiaca {3} roku {4}, PESEL: {5}", os.Imie, os.Nazwisko, os.DzienUrodzenia, os.MiesiacUrodzenia, os.RokUrodzenia, os.PESEL);
            else
                Console.WriteLine("Pani {0} {1}, urodzona dnia {2} miesiaca{3} roku {4} PESEL: {5}", os.Imie, os.Nazwisko, os.DzienUrodzenia, os.MiesiacUrodzenia, os.RokUrodzenia, os.PESEL);
        }

        public static void DodajOsobe(string imie, string nazwisko, int rokurodzenia, int miesiacurodzenia, int dzienurodzenia, int plec, string PESEL, int wartosoby)
        {
            BazaDanych.ListaOsob.Add(new Osoba(imie, nazwisko, rokurodzenia, miesiacurodzenia, dzienurodzenia, plec, PESEL, wartosoby));
        }

    }
}
