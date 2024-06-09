namespace ZaverecnyProjekt_KatalogLatek.KatalogLatek
{
    public class Softshell : Latka
    {
        public int VodniSloupec { get; private set; }
        public enum EKategorie
        {
            Jarní, Letní, Zimní, SFleecem
        }
        public EKategorie Kategorie { get; private set; }

        public Softshell(string nazev, EBarva barva, EKategorie kategorie, string slozeni, double gramaz, double cena, double zasoba, bool certifikat, int vodniSloupec)
            : base(nazev, barva, slozeni, gramaz, cena, zasoba, certifikat)
        {
            VodniSloupec = vodniSloupec;
            Kategorie = kategorie;
        }

        public override void VypisInformaceOLatce()
        {
            base.VypisInformaceOLatce();
            Console.WriteLine($"Vodní sloupec: {VodniSloupec} mm, \nKategorie: {Kategorie}");
            Console.WriteLine();
        }
    }
}

