using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjektGrupowy
{
    class Menu
    {        
        private static int WyswietlMenu()
        {
            Console.WriteLine("1 - Wyswietl Osoby");
            Console.WriteLine("2 - Wyswietl Cepiki");
            Console.WriteLine("3 - Dodaj Osobe");
            Console.WriteLine("4 - Dodaj Cepik");
            Console.WriteLine("5 - Wyszukaj Osobe");
            Console.WriteLine("6 - Wyszukaj Cepik");
            Console.WriteLine("7 - Usun Osobe");
            Console.WriteLine("8 - Usun Cepik");
            Console.WriteLine("9 - Wyjsie");

            int i;
            bool b;
            do
            {
                    do
                    {
                        b = int.TryParse(Console.ReadLine(), out i);
                    } while (!b);
            } while (0 > i || i > 9);

            return i;
        }

        public static void Uruchom()
        {
            int i;
            BazaDanych.Wczytaj();
            do
            {
                i = WyswietlMenu();
                switch (i)
                {
                    case 1:
                        Console.WriteLine("Lista osob");
                        OperacjeNaDanych.WyswietlWszystkieOsoby(BazaDanych.ListaOsob);
                        break;
                    case 2:
                        Console.WriteLine("Lista cepikow");
                        OperacjeNaDanych.WyswietlWszystkieCepiki(BazaDanych.ListaCepik);
                        break;
                    case 3:
                        OperacjeNaDanych.WprowadzOsobe();
                        BazaDanych.Zapisz();
                        break;
                    case 4:
                        OperacjeNaDanych.WprowadzCepik();
                        BazaDanych.Zapisz();
                        break;
                    case 5:
                        Console.WriteLine("Wypisz osoby ktore chesz wyszukac po szukanym parametrze");
                        OperacjeNaDanych.WyszukajOsoby();
                        break;
                    case 6:
                        Console.WriteLine("Wypisz cepiki ktore chesz wyszukac po szukanym parametrze");
                        OperacjeNaDanych.WyszukajCepiki();
                        break;
                    case 7:
                        Console.WriteLine("Wypisz osoby ktore chesz usunac po szukanym parametrze");
                        OperacjeNaDanych.UsunOsoby();
                        BazaDanych.Zapisz();
                        break;
                    case 8:
                        Console.WriteLine("Wypisz cepiki ktore chesz usunac po szukanym parametrze");
                        OperacjeNaDanych.UsunCepiki();
                        BazaDanych.Zapisz();
                        break;
                }
                Console.ReadKey();
                Console.Clear();
            } while (i != 9);
        }
    }
}
