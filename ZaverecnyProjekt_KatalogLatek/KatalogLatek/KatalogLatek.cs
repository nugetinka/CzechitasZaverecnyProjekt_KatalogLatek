using System.Data;

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
            // Přidání látky do seznamu v paměti
            Latky.Add(latka);
            // Ulož seznam do souboru
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

        private string ZiskejCestaKSouboru()
        {
            string cestaKeKataloguLatek = ZiskejCestuKeSlozce();
            return Path.Combine(cestaKeKataloguLatek, "katalogLatek.csv");
        }

        public void UlozKatalogLatek()
        {
            try
            {
                string cestaKeKataloguLatek = ZiskejCestuKeSlozce();
                string cestaKCsvSouboru = ZiskejCestaKSouboru();

                if (!Directory.Exists(cestaKeKataloguLatek))
                {
                    Directory.CreateDirectory(cestaKeKataloguLatek);
                }

                List<string> obsah = new List<string>();

                // Pokud soubor již existuje, načteme stávající řádky do seznamu Latky
                if (File.Exists(cestaKCsvSouboru))
                {
                    string[] precteneRadky = File.ReadAllLines(cestaKCsvSouboru);
                    foreach (var radek in precteneRadky)
                    {
                        obsah.Add(radek);
                    }
                }

                // Přidáme novou látku do seznamu
                foreach (var latka in Latky)
                {
                    obsah.Add(latka.ToString());
                }

                File.WriteAllLines(cestaKCsvSouboru, obsah);
                Console.WriteLine("Katalog byl úspěšně uložen do CSV souboru.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Katalog se nepodařilo uložit: {ex.Message}");
            }
        }

        public void NactiKatalogLatek()
        {
            try
            {
                string cestaKCsvSouboru = ZiskejCestaKSouboru();

                if (!File.Exists(cestaKCsvSouboru))
                {
                    Console.WriteLine("Soubor katalogLatek.csv neexistuje.");
                    return;
                }

                string[] precteneRadky = File.ReadAllLines(cestaKCsvSouboru);
                Latky.Clear();

                foreach (var radek in precteneRadky)
                {
                    Console.WriteLine(radek);
                }
                Console.WriteLine("Katalog byl úspěšně načten z CSV souboru.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Katalog se nepodařilo načíst: {ex.Message}");
            }
        }
    }
}
