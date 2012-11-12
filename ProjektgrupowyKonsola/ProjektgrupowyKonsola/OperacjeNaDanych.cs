using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjektGrupowy
{
    public class OperacjeNaDanych
    {
        static Osoba os1 = new Osoba();
        static Cepik cp1 = new Cepik();
        public static void WprowadzOsobe()
        {
            Console.WriteLine("Podaj imie: ");
            string imie = Console.ReadLine();
            Console.WriteLine("Podaj nazwisko: ");
            string nazwisko = Console.ReadLine();
            int rok;
            do
            {
                Console.WriteLine("Rok urodzenia: ");
            }
            while (!int.TryParse(Console.ReadLine(), out rok));
            
            int miesiac;
            do
            {
                Console.WriteLine("Miesiac urodzenia: ");
                Console.WriteLine("Podaj od 1 do 12: ");
                miesiac = int.Parse(Console.ReadLine());
            } while (!GenerowanieNowegoPESEL.checkMonth(miesiac));

            int dzien;
            do
            {                
                    Console.WriteLine("Dzien urodzenia: ");
                    dzien = int.Parse(Console.ReadLine());
            } while (!GenerowanieNowegoPESEL.checkDay(rok, miesiac, dzien));

            Console.WriteLine("Podaj plec: ");


            int plec;
            do
            {
                do
                {
                    Console.WriteLine("Plec, 1 - mezczyzna, 0 - kobieta: ");
                }
                while (!int.TryParse(Console.ReadLine(), out plec));
            } while (!(plec == 0 || plec == 1));

            int wkobiety = 0;
            int wmezczyzny = 1;

            string pesel;
            int[] PESEL = new int[11];
            PESEL = GenerowanieNowegoPESEL.SetBirthYear(PESEL, rok);
            PESEL = GenerowanieNowegoPESEL.SetBirthMounth(PESEL, rok, miesiac);
            PESEL = GenerowanieNowegoPESEL.SetBirthDay(PESEL, dzien);
            int i = GenerowanieNowegoPESEL.ZwrocWartPlci(plec, rok, miesiac, dzien, wkobiety, wmezczyzny);
            PESEL = GenerowanieNowegoPESEL.OrderNumber(PESEL, plec, i);
            PESEL = GenerowanieNowegoPESEL.CheckSum(PESEL);
            pesel = GenerowanieNowegoPESEL.ArrToString(PESEL);

            if (plec == 1)
            {
                Osoba.DodajOsobe(imie, nazwisko, rok, miesiac, dzien, plec, pesel, wmezczyzny);
            }
            else
            {
                Osoba.DodajOsobe(imie, nazwisko, rok, miesiac, dzien, plec, pesel, wkobiety);
            }
        }

        public static void WprowadzCepik()
        {
            Console.WriteLine("Podaj marke pojazdu: ");
            string Pojazd = Console.ReadLine();
            Console.WriteLine("Podaj rejestracje: ");
            string Rejestracja = Console.ReadLine();
            Console.WriteLine("Podaj zdarzenia zwiazane z pojazdem: ");
            string Zdarzenia = Console.ReadLine();
            Console.WriteLine("Czy umowa zostala zawarta, 1 - tak 0 - nie: ");
            int zawarcieUmowyOC;
            do
            {
                do
                {
                    Console.WriteLine("Podaj status umowy: ");
                } while (!int.TryParse(Console.ReadLine(), out zawarcieUmowyOC));
            }
            while (!(zawarcieUmowyOC == 1 || zawarcieUmowyOC == 0));
            Console.WriteLine("Podaj imie: ");
            string imie = Console.ReadLine();
            Console.WriteLine("Podaj nazwisko: ");
            string nazwisko = Console.ReadLine();
            int rok;
            do
            {
                Console.WriteLine("Rok urodzenia: ");
            }
            while (!int.TryParse(Console.ReadLine(), out rok));

            int miesiac;
            do
            {
                Console.WriteLine("Miesiac urodzenia: ");
                Console.WriteLine("Podaj od 1 do 12: ");
                miesiac = int.Parse(Console.ReadLine());
            } while (!GenerowanieNowegoPESEL.checkMonth(miesiac));

            int dzien;
            do
            {
                Console.WriteLine("Dzien urodzenia: ");
                dzien = int.Parse(Console.ReadLine());
            } while (!GenerowanieNowegoPESEL.checkDay(rok, miesiac, dzien));

            Console.WriteLine("Podaj plec: ");


            int plec;
            do
            {
                do
                {
                    Console.WriteLine("Plec, 1 - mezczyzna, 0 - kobieta: ");
                }
                while (!int.TryParse(Console.ReadLine(), out plec));
            } while (!(plec == 0 || plec == 1));

            int wkobiety = 0;
            int wmezczyzny = 1;

            bool im1 = BazaDanych.ListaOsob.Exists(element => element.Imie == imie);
            bool nz1 = BazaDanych.ListaOsob.Exists(element => element.Nazwisko == nazwisko);
            bool r1 = BazaDanych.ListaOsob.Exists(element => element.RokUrodzenia == rok);
            bool m1 = BazaDanych.ListaOsob.Exists(elemnt => elemnt.MiesiacUrodzenia == miesiac);
            bool dz1 = BazaDanych.ListaOsob.Exists(element => element.DzienUrodzenia == dzien);
            bool p1 = BazaDanych.ListaOsob.Exists(element => element.Plec == plec);

            string pesel;
            int[] PESEL = new int[11];
            PESEL = GenerowanieNowegoPESEL.SetBirthYear(PESEL, rok);
            PESEL = GenerowanieNowegoPESEL.SetBirthMounth(PESEL, rok, miesiac);
            PESEL = GenerowanieNowegoPESEL.SetBirthDay(PESEL, dzien);
            int i = GenerowanieNowegoPESEL.ZwrocWartPlci(plec, rok, miesiac, dzien, wkobiety, wmezczyzny);
            if (im1)
            {
                if (nz1)
                {
                    if (r1)
                    {
                        if (m1)
                        {
                            if (dz1)
                            {
                                if (p1)
                                {
                                    int j = BazaDanych.ListaCepik.Count();
                                    PESEL = GenerowanieNowegoPESEL.OrderNumber(PESEL, plec, i - (2 * j));
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                PESEL = GenerowanieNowegoPESEL.OrderNumber(PESEL, plec, i);
            }
            PESEL = GenerowanieNowegoPESEL.CheckSum(PESEL);
            pesel = GenerowanieNowegoPESEL.ArrToString(PESEL);
            pesel = GenerowanieNowegoPESEL.ArrToString(PESEL);

            if (BazaDanych.ListaCepik.Count() < 1)
            {
                if (plec == 1)
                {
                    Osoba.DodajOsobe(imie, nazwisko, rok, miesiac, dzien, plec, pesel, wmezczyzny);
                    Cepik.DodajCepik(Pojazd, Rejestracja, Zdarzenia, zawarcieUmowyOC, imie, nazwisko, rok, miesiac, dzien, plec, pesel, wmezczyzny);
                }
                else
                {
                    Osoba.DodajOsobe(imie, nazwisko, rok, miesiac, dzien, plec, pesel, wkobiety);
                    Cepik.DodajCepik(Pojazd, Rejestracja, Zdarzenia, zawarcieUmowyOC, imie, nazwisko, rok, miesiac, dzien, plec, pesel, wkobiety);
                }                
            }
            else
            {
                bool exists = BazaDanych.ListaCepik.Exists(element => element.Rejestracja == Rejestracja);
                if (exists)
                {
                    Console.WriteLine("Podany numer rejestracyjny wystepuje juz w bazie");
                    Console.ReadKey();
                }
                else
                {
                    bool im = BazaDanych.ListaOsob.Exists(element => element.Imie == imie);
                    bool nz = BazaDanych.ListaOsob.Exists(element => element.Nazwisko == nazwisko);
                    bool r = BazaDanych.ListaOsob.Exists(element => element.RokUrodzenia == rok);
                    bool m = BazaDanych.ListaOsob.Exists(elemnt => elemnt.MiesiacUrodzenia == miesiac);
                    bool dz = BazaDanych.ListaOsob.Exists(element => element.DzienUrodzenia == dzien);
                    bool p = BazaDanych.ListaOsob.Exists(element => element.Plec == plec);
                    
                    if (im)
                    {
                        if (nz)
                        {
                            if (r)
                            {
                                if (m)
                                {
                                    if (dz)
                                    {
                                        if (p)
                                        {
                                            if (plec == 1)
                                            {
                                                Cepik.DodajCepik(Pojazd, Rejestracja, Zdarzenia, zawarcieUmowyOC, imie, nazwisko, rok, miesiac, dzien, plec, pesel, wmezczyzny);
                                            }
                                            else
                                            {                                                
                                                Cepik.DodajCepik(Pojazd, Rejestracja, Zdarzenia, zawarcieUmowyOC, imie, nazwisko, rok, miesiac, dzien, plec, pesel, wkobiety);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }

                    else
                    {
                        if (plec == 1)
                        {
                            Osoba.DodajOsobe(imie, nazwisko, rok, miesiac, dzien, plec, pesel, wmezczyzny);
                            Cepik.DodajCepik(Pojazd, Rejestracja, Zdarzenia, zawarcieUmowyOC, imie, nazwisko, rok, miesiac, dzien, plec, pesel, wmezczyzny);
                        }
                        else
                        {
                            Osoba.DodajOsobe(imie, nazwisko, rok, miesiac, dzien, plec, pesel, wkobiety);
                            Cepik.DodajCepik(Pojazd, Rejestracja, Zdarzenia, zawarcieUmowyOC, imie, nazwisko, rok, miesiac, dzien, plec, pesel, wkobiety);
                        }
                    }
                }
            }
        }

        public static void WyswietlWszystkieOsoby(List<Osoba> Osoby)
        {
            if (Osoby.Count == 0)
                Console.WriteLine("Baza danych nie zawiera wprowadzonych osob");
            else
                foreach (var os in Osoby)
                {
                    os1.WyswietlOsobe(os);
                }
        }

        public static void WyswietlWszystkieCepiki(List<Cepik> Cepiki)
        {
            if (Cepiki.Count == 0)
                Console.WriteLine("Baza danych nie zawiera wprowadzonych CEPIK");
            else
                foreach (var cp in Cepiki)
                {
                    cp1.WyswietlCepik(cp);
                }
        }

        public static List<Osoba> WyszukajOsoby()
        {
            List<Osoba> wyniki = new List<Osoba>();
            Console.WriteLine("1. Imie\n2. Nazwisko\n3. Rok\n4. Miesiac\n5. Dzien\n6. Plec\n7. PESEL\n");
            int z;
            do
            {
                do
                {
                    Console.WriteLine("Wedlug której wartości chcesz szukać?");
                } while (!int.TryParse(Console.ReadLine(), out z));
            } while (!(z == 1 || z == 2 || z == 3 || z == 4 || z == 5 || z == 6 || z == 7));
            Console.WriteLine("Podaj slowo wedlug ktorego chcesz szukac");
            string slowokluczowe = Console.ReadLine();

            switch (z)
            {
                case 1:
                    foreach (Osoba os in BazaDanych.ListaOsob)
                        if (os.Imie.Contains(slowokluczowe))
                            wyniki.Add(os);
                    break;
                case 2:
                    foreach (Osoba os in BazaDanych.ListaOsob)
                        if (os.Nazwisko.Contains(slowokluczowe))
                            wyniki.Add(os);
                    break;
                case 3:
                    foreach (Osoba os in BazaDanych.ListaOsob)
                        if (os.RokUrodzenia == int.Parse(slowokluczowe))
                            wyniki.Add(os);
                    break;
                case 4:
                    foreach (Osoba os in BazaDanych.ListaOsob)
                        if (os.MiesiacUrodzenia == int.Parse(slowokluczowe))
                            wyniki.Add(os);
                    break;
                case 5:
                    foreach (Osoba os in BazaDanych.ListaOsob)
                        if (os.DzienUrodzenia == int.Parse(slowokluczowe))
                            wyniki.Add(os);
                    break;
                case 6:
                    foreach (Osoba os in BazaDanych.ListaOsob)
                        if (os.Plec == int.Parse(slowokluczowe))
                            wyniki.Add(os);
                    break;
                case 7:
                    foreach (Osoba os in BazaDanych.ListaOsob)
                        if (os.PESEL.Contains(slowokluczowe))
                            wyniki.Add(os);
                    break;
                default:
                    break;
            }
            WyswietlWszystkieOsoby(wyniki);
            return wyniki;
        }

        public static void UsunOsoby()
        {
            List<Osoba> OsobyDoUsuniecia = new List<Osoba>(WyszukajOsoby());
            List<Cepik> CepikiDoUsuniecia = new List<Cepik>(WyszukajCepiki());
            foreach (Osoba os in OsobyDoUsuniecia)
                BazaDanych.ListaOsob.Remove(os);
            foreach (Cepik cp in CepikiDoUsuniecia)
                BazaDanych.ListaCepik.Remove(cp);
            if (OsobyDoUsuniecia.Count > 0)
                Console.WriteLine("Gratuluje operacja usuniecia sie powiodla");
            else
                Console.WriteLine("Nie ma osob do usuniecia");
        }

        public static List<Cepik> WyszukajCepiki()
        {
            List<Cepik> wyniki = new List<Cepik>();
            Console.WriteLine("1. Marka\n2. Rejestracja\n3.Zdarzenia\n4. ZawarcieUmowy");
            int z;
            do
            {
                do
                {
                    Console.WriteLine("Wedlug której wartości chcesz szukać?");
                } while (!int.TryParse(Console.ReadLine(), out z));
            } while (!(z == 1 || z == 2 || z == 3 || z == 4));
            Console.WriteLine("Podaj slowo wedlug ktorego chcesz szukac");
            string slowokluczowe = Console.ReadLine();

            switch (z)
            {
                case 1:
                    foreach (Cepik cp in BazaDanych.ListaCepik)
                        if (cp.Pojazd.Contains(slowokluczowe))
                            wyniki.Add(cp);
                    break;
                case 2:
                    foreach (Cepik cp in BazaDanych.ListaCepik)
                        if (cp.Rejestracja.Contains(slowokluczowe))
                            wyniki.Add(cp);
                    break;

                case 3:
                    foreach (Cepik cp in BazaDanych.ListaCepik)
                        if (cp.Zdarzenia.Contains(slowokluczowe))
                            wyniki.Add(cp);
                    break;
                case 4:
                    foreach (Cepik cp in BazaDanych.ListaCepik)
                        if (cp.ZawarcieUmowyOC == int.Parse(slowokluczowe))
                            wyniki.Add(cp);
                    break;
                default:
                    break;
            }
            WyswietlWszystkieCepiki(wyniki);
            return wyniki;
        }

        public static void UsunCepiki()
        {
            List<Cepik> CepikiDoUsuniecia = new List<Cepik>(WyszukajCepiki());
            foreach (Cepik cp in CepikiDoUsuniecia)
                BazaDanych.ListaCepik.Remove(cp);
            if (CepikiDoUsuniecia.Count > 0)
                Console.WriteLine("Gratuluje operacja usuniecia sie powiodla");
            else
                Console.WriteLine("Nie ma cepikow do usuniecia");
        }       
    }
}
