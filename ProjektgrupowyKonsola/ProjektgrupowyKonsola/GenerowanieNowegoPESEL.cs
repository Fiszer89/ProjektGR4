using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjektGrupowy
{
    class GenerowanieNowegoPESEL
    {
        private static Osoba os = new Osoba();

        public GenerowanieNowegoPESEL() { }

        public static string ArrToString(int[] tab)
        {
            string result = String.Empty;
            tab.ToList().ForEach(elem => result += elem.ToString());
            return result;
        }

        public static int[] SetBirthYear(int[] PESEL, int year)
        {
            PESEL[0] = (year % 100) / 10;
            PESEL[1] = year % 10;
            return PESEL;
        }

        public static int[] SetBirthMounth(int[] PESEL, int year, int month)
        {
            if (year >= 1800 && year < 1900)
            {
                month = month + 80;
            }
            else if (year >= 1900 && year < 2000)
            {
                month = month + 0;
            }
            else if (year >= 2000 && year < 2100)
            {
                month = month + 20;
            }
            else if (year >= 2100 && year < 2200)
            {
                month = month + 40;
            }
            else if (year >= 2200)
            {
                month = month + 60;
            }
            PESEL[2] = month / 10;
            PESEL[3] = month % 10;
            return PESEL;
        }

        public static int[] SetBirthDay(int[] PESEL, int day)
        {
            PESEL[4] = day / 10;
            PESEL[5] = day % 10;
            return PESEL;
        }

        public static int ZwrocWartPlci(int plec, int rok, int miesiac, int dzien, int wartmezczyzny, int wartkobiety)
        {
            wartmezczyzny = 1;
            wartkobiety = 0;
            if(!(BazaDanych.ListaOsob.Count() < 1))
            {
                for (int i = 0; i < BazaDanych.ListaOsob.Count(); i++)
                {
                    if (BazaDanych.ListaOsob[i].Plec == plec)
                    {
                        if (BazaDanych.ListaOsob[i].RokUrodzenia == rok)
                        {
                            if (BazaDanych.ListaOsob[i].MiesiacUrodzenia == miesiac)
                            {
                                if (BazaDanych.ListaOsob[i].DzienUrodzenia == dzien)
                                {
                                    return BazaDanych.ListaOsob[i].wartosoby += 2;
                                }
                            }
                        }
                    }
                }
            }
            if (plec == 0)
            {
                return wartkobiety;
            }
            else
            {
                return wartmezczyzny;
            }
        }

        public static int[] OrderNumber(int[] PESEL, int plec, int numer)
        {
            PESEL[6] = 0;
            PESEL[7] = 0;
            PESEL[8] = 0;
            PESEL[9] = 0;
           
            if (plec == 1)
            {
                if (numer > 999)
                {
                    PESEL[6] = numer / 1000;
                    PESEL[7] = (numer / 100) % 10;
                    PESEL[8] = (numer / 10) % 10;
                    PESEL[9] = numer % 10;
                }
                if (numer > 99)
                {
                    PESEL[7] = (numer / 100) % 10;
                    PESEL[8] = (numer / 10) % 10;
                    PESEL[9] = numer % 10;
                }
                if (numer > 9)
                {
                    PESEL[8] = (numer / 10) % 10;
                    PESEL[9] = numer % 10;
                }
                else
                {
                    PESEL[9] = numer % 10;
                }
            }

            if (plec == 0)
            {
                if (numer > 999)
                {
                    PESEL[6] = numer / 1000;
                    PESEL[7] = (numer / 100) % 10;
                    PESEL[8] = (numer / 10) % 10;
                    PESEL[9] = numer % 10;
                }
                if (numer > 99)
                {
                    PESEL[7] = (numer / 100) % 10;
                    PESEL[8] = (numer / 10) % 10;
                    PESEL[9] = numer % 10;
                }
                if (numer > 9)
                {
                    PESEL[8] = (numer / 10) % 10;
                    PESEL[9] = numer % 10;
                }
                else
                {
                    PESEL[9] = numer % 10;
                }
            }
            return PESEL;
        }

        public static int[] CheckSum(int[] PESEL)
        {
            int sum = 1 * PESEL[0] + 3 * PESEL[1] + 7 * PESEL[2] + 9 * PESEL[3] + 1 * PESEL[4] + 3 * PESEL[5] + 7 * PESEL[6] + 9 * PESEL[7] + 1 * PESEL[8] + 3 * PESEL[9];
            sum = sum % 10;
            sum = 10 - sum;
            sum %= 10;
            PESEL[10] = sum;
            return PESEL;
        }

        public static bool checkMonth(int month)
        {
            if (month > 0 && month < 13)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool checkDay(int year, int month, int day)
        {
            if ((day > 0 && day < 32) &&
            (month == 1 || month == 3 || month == 5 ||
            month == 7 || month == 8 || month == 10 ||
            month == 12))
            {
                return true;
            }
            else if ((day > 0 && day < 31) && (month == 4 || month == 6 || month == 9 || month == 11))
            {
                return true;
            }
            else if (((day > 0) && (day < 30) || leapYear(year)) || (day > 0 && day < 29 && !leapYear(year)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static bool leapYear(int year)
        {
            if (year % 4 == 0 && year % 100 != 0 || year % 400 == 0)
                return true;
            else
                return false;
        }
    }
}