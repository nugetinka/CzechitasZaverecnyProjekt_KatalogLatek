namespace ZaverecnyProjekt_KatalogLatek.KatalogLatek
{
    public class KatalogLatek
    {
        public List<Latka> _latky { get; init; }

        public KatalogLatek()
        {
            _latky = new List<Latka>();
        }

        public void PridejLatku(Latka latka)
        {
            _latky.Add(latka);
        }

        public void OdeberLatku(int kodProduktu)
        {
            var latkaKOdstraneni = _latky.FirstOrDefault(latka => latka._id == kodProduktu);
            if (latkaKOdstraneni != null)
            {
                _latky.Remove(latkaKOdstraneni);
                Console.WriteLine($"Látka s kódem = {kodProduktu} byla odstraněna.");
            }
            else
            {
                Console.WriteLine($"Látka s kódem = {kodProduktu} nebyla nalezena.");
            }
        }

        public void VypisInformaceOLatce()
        {
            foreach (var latka in _latky)
            {
                latka.VypisInformaceOLatce();
            }
        }
    }
}
