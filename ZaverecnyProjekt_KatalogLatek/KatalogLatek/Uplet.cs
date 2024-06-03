namespace ZaverecnyProjekt_KatalogLatek.KatalogLatek
{
    public class Uplet : Latka
    {
        public int _pruznost { get; private set; }

        public Uplet(int id, string nazev, string barva, string kategorie, string slozeni, double gramaz, double cena, double zasoba, bool certifikat, int pruznost)
            : base(id, nazev, barva, kategorie, slozeni, gramaz, cena, zasoba, certifikat)
        {
            _pruznost = pruznost;
        }

        public override void VypisInformaceOLatce()
        {
            base.VypisInformaceOLatce();
            Console.WriteLine($"Pružnost: {_pruznost} %");
            Console.WriteLine();
        }
    }
}
