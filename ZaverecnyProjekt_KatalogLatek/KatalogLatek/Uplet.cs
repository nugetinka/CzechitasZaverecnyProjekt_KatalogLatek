namespace ZaverecnyProjekt_KatalogLatek.KatalogLatek
{
    public class Uplet : Latka
    {
        public int Pruznost { get; private set; }

        public Uplet(string nazev, EBarva barva, string kategorie, string slozeni, double gramaz, double cena, double zasoba, bool certifikat, int pruznost)
            : base(nazev, barva, kategorie, slozeni, gramaz, cena, zasoba, certifikat)
        {
            Pruznost = pruznost;
        }

        public override void VypisInformaceOLatce()
        {
            base.VypisInformaceOLatce();
            Console.WriteLine($"Pružnost: {Pruznost} %");
            Console.WriteLine();
        }
    }
}
