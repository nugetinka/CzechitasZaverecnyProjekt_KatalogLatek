namespace ZaverecnyProjekt_KatalogLatek.KatalogLatek
{
    public class BavlnenePlatno : Latka
    {
        public int _srazlivost { get; private set; }

        public BavlnenePlatno(int id, string nazev, string barva, string kategorie, string slozeni, double gramaz, double cena, double zasoba, bool certifikat, int srazlivost)
            : base(id, nazev, barva, kategorie, slozeni, gramaz, cena, zasoba, certifikat)
        {
            _srazlivost = srazlivost;
        }

        public override void VypisInformaceOLatce()
        {
            base.VypisInformaceOLatce();
            Console.WriteLine($"Srážlivost: {_srazlivost} %");
            Console.WriteLine();
        }
    }
}
