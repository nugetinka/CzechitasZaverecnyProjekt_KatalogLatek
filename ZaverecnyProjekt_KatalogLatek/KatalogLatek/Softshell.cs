namespace ZaverecnyProjekt_KatalogLatek.KatalogLatek
{
    public class Softshell : Latka
    {
        public int _vodniSloupec { get; private set; } 

        public Softshell(int id, string nazev, string barva, string kategorie, string slozeni, double gramaz, double cena, double zasoba, bool certifikat, int vodniSloupec)
            : base(id, nazev, barva, kategorie, slozeni, gramaz, cena, zasoba, certifikat)
        {
            _vodniSloupec = vodniSloupec;
        }

        public override void VypisInformaceOLatce()
        {
            base.VypisInformaceOLatce();
            Console.WriteLine($"Vodní sloupec: {_vodniSloupec} mm");
            Console.WriteLine();
        }
    }
}

