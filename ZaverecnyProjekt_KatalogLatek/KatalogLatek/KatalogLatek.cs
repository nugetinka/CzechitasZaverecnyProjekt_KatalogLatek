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

        public enum TypLatky
        {
            Plátno,
            Softshell,
            Úplet
        }

        public void PridejLatku(Latka latka)
        {
            Latky.Add(latka);
            // Uložení katalogu po přidání látky
            UlozKatalogLatek();
        }

        public void OdeberLatku(int kodProduktu)
        {
            try
            {
                // Načtení aktuálního katalogu ze souboru
                NactiKatalogLatek();

                var latkaKOdstraneni = Latky.FirstOrDefault(l => l.Id == kodProduktu);

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
            catch (Exception ex)
            {
                Console.WriteLine($"Nastala chyba při aktualizaci katalogu {ex.Message}.");
            }
        }

        public override string ToString()
        {
            if (Latky.Count == 0)
            {
                Console.WriteLine($"Katalog je prázdný.");
            }
            foreach (var latka in Latky)
            {
                Console.WriteLine(latka.ToString());
                Console.WriteLine();
            }
            return string.Empty;
        }

        public void PridejLatku(TypLatky typLatky)
        {
            string nazev = ZiskejStringOdUzivatele("Zadejte název: ");

            Barva barva = ZiskejBarvuOdUzivatele("Zadejte barvu: ");

            string slozeni = ZiskejStringOdUzivatele("Zadejte složení: ");

            double gramaz = ZiskejDoubleOdUzivatele("Zadejte gramáž (g/m2): ");

            double cena = ZiskejDoubleOdUzivatele("Zadejte cenu (Kč/m): ");

            double zasoba = ZiskejDoubleOdUzivatele("Zadejte zásobu (m): ");

            bool certifikat = ZiskejBoolOdUzivatele("Je produkt certifikován (true/false)?");

            Latka latka;
            switch (typLatky)
            {
                case TypLatky.Plátno:
                    int srazlivost = ZiskejIntOdUzivatele("Zadejte srážlivost (%): ");
                    var kategoriePlatno = ZiskejKategoriiOdUzivatelePlatno("Zadejte kategorii: ");
                    latka = new BavlnenePlatno(nazev, barva, kategoriePlatno, slozeni, gramaz, cena, zasoba, certifikat, srazlivost);
                    break;
                case TypLatky.Softshell:
                    int vodniSloupec = ZiskejIntOdUzivatele("Zadejte vodní sloupec (mm): ");
                    var kategorieSoftshell = ZiskejKategoriiOdUzivateleSoftshell("Zadejte kategorii: ");
                    latka = new Softshell(nazev, barva, kategorieSoftshell, slozeni, gramaz, cena, zasoba, certifikat, vodniSloupec);
                    break;
                case TypLatky.Úplet:
                    int pruznost = ZiskejIntOdUzivatele("Zadejte pružnost (%): ");
                    var kategorieUplet = ZiskejKategoriiOdUzivateleUplet("Zadejte kategorii: ");
                    latka = new Uplet(nazev, barva, kategorieUplet, slozeni, gramaz, cena, zasoba, certifikat, pruznost);
                    break;
                default:
                    Console.WriteLine("Neznámý typ látky.");
                    return;
            }

            PridejLatku(latka);
            Console.WriteLine($"Látka byla úspěšně přidána.");
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

        public static int ZiskejIntOdUzivatele(string zadani)
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
                Console.WriteLine("Neplatná hodnota pro certifikát, zadejte znovu: ");
            }
            return hodnota;
        }

        private static Barva ZiskejBarvuOdUzivatele(string zadani)
        {
            Barva barva;
            while (!Enum.TryParse(ZiskejStringOdUzivatele(zadani), out barva))
            {
                Console.WriteLine("Tato barva není v seznamu, zadejte znovu: ");
            }
            return barva;
        }

        private static BavlnenePlatno.Kategorie ZiskejKategoriiOdUzivatelePlatno(string zadani)
        {
            BavlnenePlatno.Kategorie kategorie;
            while (!Enum.TryParse(ZiskejStringOdUzivatele(zadani), out kategorie))
            {
                Console.WriteLine("Neplatná kategorie, zadejte znovu: ");
            }
            return kategorie;
        }

        private static Softshell.Kategorie ZiskejKategoriiOdUzivateleSoftshell(string zadani)
        {
            Softshell.Kategorie kategorie;
            while (!Enum.TryParse(ZiskejStringOdUzivatele(zadani), out kategorie))
            {
                Console.WriteLine("Neplatná kategorie, zadejte znovu: ");
            }
            return kategorie;
        }

        private static Uplet.Kategorie ZiskejKategoriiOdUzivateleUplet(string zadani)
        {
            Uplet.Kategorie kategorie;
            while (!Enum.TryParse(ZiskejStringOdUzivatele(zadani), out kategorie))
            {
                Console.WriteLine("Neplatná kategorie, zadejte znovu: ");
            }
            return kategorie;
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
                XmlSerializer serializer = new XmlSerializer(typeof(List<Latka>), new Type[] { typeof(BavlnenePlatno), typeof(Softshell), typeof(Uplet) });

                string cestaKeSlozce = ZiskejCestuKeSlozce();
                string cestaKXmlSouboru = ZiskejCestuKSouboru();

                if (!Directory.Exists(cestaKeSlozce))
                {
                    Directory.CreateDirectory(cestaKeSlozce);
                }

                // Vytvoření streamu, pomocí kterého budeme serializovat
                using (StreamWriter streamWriter = new StreamWriter(cestaKXmlSouboru))
                {
                    // Zavolání metody Serialize, kde je první parametr stream a druhý je objekt, který serializujeme
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
            try
            {
                string cestaKXmlSouboru = ZiskejCestuKSouboru();

                if (File.Exists(cestaKXmlSouboru))
                {
                    // Vytvoření XML serializátoru na typ List<Latka>
                    XmlSerializer serializer = new XmlSerializer(typeof(List<Latka>), new Type[] { typeof(BavlnenePlatno), typeof(Softshell), typeof(Uplet) });

                    // Použití StreamReaderu k načtení ze souboru
                    using (StreamReader streamReader = new StreamReader(cestaKXmlSouboru))
                    {
                        Latky = serializer.Deserialize(streamReader) as List<Latka>;
                    }
                }
                else
                {
                    Console.WriteLine("Katalog látek nebyl nalezen, bude vytvořen nový.");
                    return new List<Latka>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Chyba při načítání katalogu: {ex.Message}");
            }
            return Latky;
        }
    }
}
