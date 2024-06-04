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
    }
}
