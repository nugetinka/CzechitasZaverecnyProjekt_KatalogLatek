namespace ZaverecnyProjekt_KatalogLatek.KatalogLatek
{
    public class Uplet : Latka
    {
        public int Pruznost { get; private set; }
        public enum EKategorie
        {
            Úplet, Náplet, Teplákovina
        }
        public EKategorie Kategorie { get; private set; }

        public Uplet(string nazev, EBarva barva, EKategorie kategorie, string slozeni, double gramaz, double cena, double zasoba, bool certifikat, int pruznost)
            : base(nazev, barva, slozeni, gramaz, cena, zasoba, certifikat)
        {
            Pruznost = pruznost;
            Kategorie = kategorie;
        }

        public override void VypisInformaceOLatce()
        {
            base.VypisInformaceOLatce();
            Console.WriteLine($"Pružnost: {Pruznost} %, \nKategorie: {Kategorie}");
            Console.WriteLine();
        }

        public override void PridejLatku()
        {
            throw new NotImplementedException();
        }
    }
}
