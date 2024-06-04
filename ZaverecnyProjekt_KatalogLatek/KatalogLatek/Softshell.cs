namespace ZaverecnyProjekt_KatalogLatek.KatalogLatek
{
    public class Softshell : Latka
    {
        public int VodniSloupec { get; private set; } 

        public Softshell(string nazev, EBarva barva, string kategorie, string slozeni, double gramaz, double cena, double zasoba, bool certifikat, int vodniSloupec)
            : base(nazev, barva, kategorie, slozeni, gramaz, cena, zasoba, certifikat)
        {
            VodniSloupec = vodniSloupec;
        }

        public override void VypisInformaceOLatce()
        {
            base.VypisInformaceOLatce();
            Console.WriteLine($"Vodní sloupec: {VodniSloupec} mm");
            Console.WriteLine();
        }
    }
}

