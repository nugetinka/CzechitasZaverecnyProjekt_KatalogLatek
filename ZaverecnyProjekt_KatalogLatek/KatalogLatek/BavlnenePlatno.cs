namespace ZaverecnyProjekt_KatalogLatek.KatalogLatek
{
    public class BavlnenePlatno : Latka
    {
        public int Srazlivost { get; private set; }

        public BavlnenePlatno(string nazev, EBarva barva, string kategorie, string slozeni, double gramaz, double cena, double zasoba, bool certifikat, int srazlivost)
            : base(nazev, barva, kategorie, slozeni, gramaz, cena, zasoba, certifikat)
        {
            Srazlivost = srazlivost;
        }

        public override void VypisInformaceOLatce()
        {
            base.VypisInformaceOLatce();
            Console.WriteLine($"Srážlivost: {Srazlivost} %");
            Console.WriteLine();
        }
    }
}
