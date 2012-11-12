using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ProjektGrupowy
{
    public class BazaDanych
    {
        public static List<Osoba> ListaOsob = new List<Osoba>();
        public static List<Cepik> ListaCepik = new List<Cepik>();

        public static void Wczytaj()
        {
            if (!File.Exists("Osoby.dat") || !File.Exists("Cepik.dat"))
            {
                return;
            }
            FileStream fs = null;
            BinaryFormatter formater = new BinaryFormatter();
            try
            {
                fs = new FileStream("Osoby.dat", FileMode.Open);
                ListaOsob = (List<Osoba>)formater.Deserialize(fs);
                fs.Close();
                fs = new FileStream("Cepik.dat", FileMode.Open);
                ListaCepik = (List<Cepik>)formater.Deserialize(fs);
            }
            finally
            {
                if (fs != null)
                    fs.Close();
            }
        }

        public static void Zapisz()
        {
            FileStream fs = null;
            BinaryFormatter formater = new BinaryFormatter();
            try
            {
                fs = new FileStream("Osoby.dat", FileMode.Create);
                formater.Serialize(fs, ListaOsob);
                fs.Close();
                fs = new FileStream("Cepik.dat", FileMode.Create);
                formater.Serialize(fs, ListaCepik);
            }
            finally
            {
                if (fs != null)
                    fs.Close();
            }
        }
    }
}
