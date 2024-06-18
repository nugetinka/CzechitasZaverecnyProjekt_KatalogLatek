using System.Xml.Serialization;

namespace ZaverecnyProjekt_KatalogLatek.KatalogLatek
{
    public class KatalogLatek
    {
        public List<Latka> Latky { get; set; }

        public KatalogLatek()
        {
            Latky = new List<Latka>();
        }

        public void PridejLatku(Latka latka)
        {
            Latky.Add(latka);
            UlozKatalogLatek();
        }

        public void OdeberLatku(int kodProduktu)
        {
            var latkaKOdstraneni = Latky.FirstOrDefault(latka => latka.Id == kodProduktu);
            if (latkaKOdstraneni != null)
            {
                Latky.Remove(latkaKOdstraneni);
                Console.WriteLine($"Látka s kódem = {kodProduktu} byla odstraněna.");
                UlozKatalogLatek();
            }
            else
            {
                Console.WriteLine($"Látka s kódem = {kodProduktu} nebyla nalezena.");
            }
        }

        public override string ToString()
        {
            foreach (var latka in Latky)
            {
                Console.WriteLine(latka.ToString());
                Console.WriteLine();
            }
            return string.Empty;
        }

        public void PridejLatku(TypLatky volba)
        {
            string nazev = ZiskejStringOdUzivatele("Zadejte název: ");

            if (!Enum.TryParse(ZiskejStringOdUzivatele("Zadejte barvu: "), out Barva barva))
            {
                Console.WriteLine("Tato barva není v seznamu.");
                return;
            }

            string slozeni = ZiskejStringOdUzivatele("Zadejte složení: ");

            double gramaz = ZiskejDoubleOdUzivatele("Zadejte gramáž (g/m2): ");

            double cena = ZiskejDoubleOdUzivatele("Zadejte cenu (Kč/m): ");

            double zasoba = ZiskejDoubleOdUzivatele("Zadejte zásobu (m): ");

            bool certifikat = ZiskejBoolOdUzivatele("Je produkt certifikován (true/false)?");

            Latka latka;
            switch (volba)
            {
                case TypLatky.Platno:
                    int srazlivost = ZiskejIntOdUzivatele("Zadejte srážlivost (%): ");

                    if (!Enum.TryParse(ZiskejStringOdUzivatele("Zadejte kategorii: "), out BavlnenePlatno.Kategorie kategoriePlatno))
                    {
                        Console.WriteLine("Tato kategorie není v seznamu.");
                        return;
                    }
                    latka = new BavlnenePlatno(nazev, barva, kategoriePlatno, slozeni, gramaz, cena, zasoba, certifikat, srazlivost);
                    break;
                case TypLatky.Softshell:
                    int vodniSloupec = ZiskejIntOdUzivatele("Zadejte vodní sloupec (mm): ");

                    if (!Enum.TryParse(ZiskejStringOdUzivatele("Zadejte kategorii: "), out Softshell.Kategorie kategorieSoftshell))
                    {
                        Console.WriteLine("Tato kategorie není v seznamu.");
                        return;
                    }
                    latka = new Softshell(nazev, barva, kategorieSoftshell, slozeni, gramaz, cena, zasoba, certifikat, vodniSloupec);
                    break;
                case TypLatky.Uplet:
                    int pruznost = ZiskejIntOdUzivatele("Zadejte pružnost (%): ");

                    if (!Enum.TryParse(ZiskejStringOdUzivatele("Zadejte kategorii: "), out Uplet.Kategorie kategorieUplet))
                    {
                        Console.WriteLine("Tato kategorie není v seznamu.");
                        return;
                    }
                    latka = new Uplet(nazev, barva, kategorieUplet, slozeni, gramaz, cena, zasoba, certifikat, pruznost);
                    break;
                default:
                    Console.WriteLine("Neznámý typ látky");
                    return;
            }

            PridejLatku(latka);
            Console.WriteLine($"Látka byla úspěšně přidána.");
        }

        public enum TypLatky
        {
            Platno,
            Softshell,
            Uplet
        }

        private static string ZiskejStringOdUzivatele(string zadani)
        {
            Console.WriteLine(zadani);
            return Console.ReadLine();
        }

        private static double ZiskejDoubleOdUzivatele(string zadani)
        {
            double hodnota;
            Console.WriteLine(zadani);
            while (!double.TryParse(Console.ReadLine(), out hodnota))
            {
                Console.WriteLine("Neplatná hodnota, zadejte znovu: ");
            }
            return hodnota;
        }

        private static int ZiskejIntOdUzivatele(string zadani)
        {
            int hodnota;
            Console.WriteLine(zadani);
            while (!int.TryParse(Console.ReadLine(), out hodnota))
            {
                Console.WriteLine("Neplatná hodnota, zadejte znovu: ");
            }
            return hodnota;
        }

        private static bool ZiskejBoolOdUzivatele(string zadani)
        {
            bool hodnota;
            Console.WriteLine(zadani);
            while (!bool.TryParse(Console.ReadLine(), out hodnota))
            {
                Console.WriteLine("Zadána neplatná hodnota pro certifikát.");
            }
            return hodnota;
        }

        private string ZiskejCestuKeSlozce()
        {
            string cestaKApplicationData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            return Path.Combine(cestaKApplicationData, "KatalogLatek");
        }

        private string ZiskejCestuKSouboru()
        {
            string cestaKeKataloguLatek = ZiskejCestuKeSlozce();
            return Path.Combine(cestaKeKataloguLatek, "katalogLatek.xml");
        }

        public void UlozKatalogLatek()
        {
            try
            {
                // Vytvoříme si XmlSerializer na typ List<Latka>
                XmlSerializer serializer = new XmlSerializer(typeof(List<Latka>), new Type[] {typeof(BavlnenePlatno), typeof(Softshell), typeof(Uplet)});

                string cestaKeSlozce = ZiskejCestuKeSlozce();
                string cestaKXmlSouboru = ZiskejCestuKSouboru();

                if (!Directory.Exists(cestaKeSlozce))
                {
                    Directory.CreateDirectory(cestaKeSlozce);
                }

                // Vytvoříme stream, pomocí kterého budeme serializovat
                using (StreamWriter streamWriter = new StreamWriter(cestaKXmlSouboru))
                {
                    // Zavoláme metodu Serialize, kde je první parametr stream
                    // Druhý parametr je objekt, který serializujeme
                    serializer.Serialize(streamWriter, Latky);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Katalog se nepodařilo uložit do XML souboru: {ex.Message}");
            }
        }

        public List<Latka> NactiKatalogLatek()
        {
            List<Latka> prectenySeznam = null;

            try
            {
                string cestaKXmlSouboru = ZiskejCestuKSouboru();

                if (!File.Exists(cestaKXmlSouboru))
                {
                    Console.WriteLine($"Soubor \"katalogLatek.xml\" neexistuje.");
                }

                XmlSerializer serializer = new XmlSerializer(typeof(List<Latka>), new Type[] { typeof(BavlnenePlatno), typeof(Softshell), typeof(Uplet) });

                using (StreamReader streamReader = new StreamReader(cestaKXmlSouboru))
                {
                    prectenySeznam = serializer.Deserialize(streamReader) as List<Latka>;
                }
                Console.WriteLine("Katalog byl úspěšně načten z XML souboru");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Katalog se nepodařilo načíst: {ex.Message}");
            }

            return prectenySeznam;
        }
    }
}
