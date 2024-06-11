namespace ZaverecnyProjekt_KatalogLatek.KatalogLatek
{
    public class KatalogLatek
    {
        public List<Latka> Latky { get; init; }

        public KatalogLatek()
        {
            Latky = new List<Latka>();
        }

        public void PridejLatku(Latka latka)
        {
            Latky.Add(latka);
        }

        public void OdeberLatku(int kodProduktu)
        {
            var latkaKOdstraneni = Latky.FirstOrDefault(latka => latka.Id == kodProduktu);
            if (latkaKOdstraneni != null)
            {
                Latky.Remove(latkaKOdstraneni);
                Console.WriteLine($"Látka s kódem = {kodProduktu} byla odstraněna.");
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
                case TypLatky.Plátno: 
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
                case TypLatky.Úplet:
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
            Plátno,
            Softshell,
            Úplet
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
    }
}
