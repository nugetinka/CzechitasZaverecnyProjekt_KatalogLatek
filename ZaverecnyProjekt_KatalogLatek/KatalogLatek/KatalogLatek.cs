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

        public void VypisInformaceOLatce()
        {
            foreach (var latka in Latky)
            {
                latka.VypisInformaceOLatce();
            }
        }

        public void PridejLatkuUI(Type typLatky)
        {
            Console.WriteLine("Zadejte název: ");
            string nazev = Console.ReadLine();

            Console.WriteLine("Zadejte barvu: ");
            if (!Enum.TryParse(Console.ReadLine(), out Latka.EBarva barva))
            {
                Console.WriteLine("Tato barva není v seznamu.");
                return;
            }

            Console.WriteLine("Zadejte složení: ");
            string slozeni = Console.ReadLine();

            Console.WriteLine("Zadejte gramáž: ");
            if (!double.TryParse(Console.ReadLine(), out double gramaz))
            {
                Console.WriteLine("Zadána neplatná gramáž");
                return;
            }

            Console.WriteLine("Zadejte cenu: ");
            if (!double.TryParse(Console.ReadLine(), out double cena))
            {
                Console.WriteLine("Zadána neplatná cena");
                return;
            }

            Console.WriteLine("Zadejte zásobu: ");
            if (!double.TryParse(Console.ReadLine(), out double zasoba))
            {
                Console.WriteLine("Zadána neplatná zásoba");
                return;
            }

            Console.WriteLine("Je produkt certifikován (true/false)?");
            if (!bool.TryParse(Console.ReadLine(), out bool certifikat))
            {
                Console.WriteLine("Zadána neplatná hodnota pro certifikát");
                return;
            }

            object latka;
            if (typLatky == typeof(BavlnenePlatno))
            {
                Console.WriteLine("Zadejte srážlivost: ");
                if (!int.TryParse(Console.ReadLine(), out int srazlivost))
                {
                    Console.WriteLine("Zadaná neplatná srážlivost.");
                    return;
                }

                Console.WriteLine("Zadejte kategorii: ");
                if (!Enum.TryParse(Console.ReadLine(), out BavlnenePlatno.EKategorie kategorie))
                {
                    Console.WriteLine("Tato kategorie není v seznamu.");
                    return;
                }

                latka = new BavlnenePlatno(nazev, barva, kategorie, slozeni, gramaz, cena, zasoba, certifikat, srazlivost);
            }
            else if (typLatky == typeof(Softshell))
            {
                Console.WriteLine("Zadejte vodní sloupec: ");
                if (!int.TryParse(Console.ReadLine(), out int vodniSloupec))
                {
                    Console.WriteLine("Zadaná neplatná hodnota pro vodní sloupec.");
                    return;
                }

                Console.WriteLine("Zadejte kategorii: ");
                if (!Enum.TryParse(Console.ReadLine(), out Softshell.EKategorie kategorie))
                {
                    Console.WriteLine("Tato kategorie není v seznamu.");
                    return;
                }

                latka = new Softshell(nazev, barva, kategorie, slozeni, gramaz, cena, zasoba, certifikat, vodniSloupec);
            }
            else if (typLatky == typeof(Uplet))
            {
                Console.WriteLine("Zadejte pružnost: ");
                if (!int.TryParse(Console.ReadLine(), out int pruznost))
                {
                    Console.WriteLine("Zadaná neplatná hodnota pro pružnost.");
                    return;
                }

                Console.WriteLine("Zadejte kategorii: ");
                if (!Enum.TryParse(Console.ReadLine(), out Uplet.EKategorie kategorie))
                {
                    Console.WriteLine("Tato kategorie není v seznamu.");
                    return;
                }

                latka = new Uplet(nazev, barva, kategorie, slozeni, gramaz, cena, zasoba, certifikat, pruznost);
            }
            else
            {
                Console.WriteLine("Neznámý typ látky");
                return;
            }

            PridejLatku((Latka)latka);
            Console.WriteLine($"{typLatky.Name} byla úspěšně přidána.");
        }
    }
}
