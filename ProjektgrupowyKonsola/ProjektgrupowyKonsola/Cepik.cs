using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjektGrupowy
{
    [Serializable]
    public class Cepik
    {
        public string Pojazd;
        public string Rejestracja;
        public string Zdarzenia;
        public int ZawarcieUmowyOC;
        Osoba os1 = new Osoba();

        public Cepik() { }

        public Cepik(string pojazd, string rejestracja, string zdarzenia, int zawarcieumowyOC, string imie, string nazwisko, int rokurodzenia, int miesiacurodzenia, int dzienurodzenia, int plec, string PESEL, int wartosoby)
        {
            this.Pojazd = pojazd;
            this.Rejestracja = rejestracja;
            this.Zdarzenia = zdarzenia;
            this.ZawarcieUmowyOC = zawarcieumowyOC;
            this.os1.Imie = imie;
            this.os1.Nazwisko = nazwisko;
            this.os1.RokUrodzenia = rokurodzenia;
            this.os1.MiesiacUrodzenia = miesiacurodzenia;
            this.os1.DzienUrodzenia = dzienurodzenia;
            this.os1.PESEL = PESEL;
            this.os1.wartosoby = wartosoby;
        }

        public string ZwrocCepik(Cepik cp)
        {
            if (ZawarcieUmowyOC == 1)
                return string.Format("Pojazd: {0}, Rejestracja pojazdu: {1}, Zdarzenia zwiazne z pojazdem: {2}, Umowa OC zostala zawarta, Imie {3}, Nazwisko {4}, Data urodzenia {5}/{6}/{7}, PESEL {8}", cp.Pojazd, cp.Rejestracja, cp.Zdarzenia, cp.os1.Imie, cp.os1.Nazwisko, cp.os1.RokUrodzenia, cp.os1.MiesiacUrodzenia, cp.os1.DzienUrodzenia, cp.os1.PESEL);
            else
                return string.Format("Pojazd: {0}, Rejestracja pojazdu: {1}, Zdarzenia zwiazne z pojazdem: {2}, Umowa OC nie zostala zawarta, Imie {3}, Nazwisko {4}, Data urodzenia {5}/{6}/{7}, PESEL {8}\n", cp.Pojazd, cp.Rejestracja, cp.Zdarzenia, cp.os1.Imie, cp.os1.Nazwisko, cp.os1.RokUrodzenia, cp.os1.MiesiacUrodzenia, cp.os1.DzienUrodzenia, cp.os1.PESEL);
        }
        
        public void WyswietlCepik(Cepik cp)
        {
            Console.WriteLine(ZwrocCepik(cp));
        }

        public static void DodajCepik(string pojazd, string rejestracja, string zdarzenia, int zawarcieumowyOC, string imie, string nazwisko, int rokurodzenia, int miesiacurodzenia, int dzienurodzenia, int plec, string PESEL, int wartosoby)
        {
            BazaDanych.ListaCepik.Add(new Cepik(pojazd, rejestracja, zdarzenia, zawarcieumowyOC, imie, nazwisko, rokurodzenia, miesiacurodzenia, dzienurodzenia, plec, PESEL, wartosoby));
        }
    }
}
