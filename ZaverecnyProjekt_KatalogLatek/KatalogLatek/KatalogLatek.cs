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

        public void PridejLatku()
        {
            Console.WriteLine("Zadejte název: ");
            string nazev = Console.ReadLine();

            Console.WriteLine("Zadejte barvu: ");
            if (!Enum.TryParse(Console.ReadLine(), out Latka.EBarva barva))
            {
                Console.WriteLine("Tato barva není v seznamu.");
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

            //KatalogLatek novaLatka = new KatalogLatek(nazev, barva, slozeni, gramaz, cena, zasoba, certifikat);
            //PridejLatku(nazev, barva, slozeni, gramaz, cena, zasoba, certifikat);
            //Console.WriteLine("Látka byla úspěšně přidána.");
        }
    }
}
