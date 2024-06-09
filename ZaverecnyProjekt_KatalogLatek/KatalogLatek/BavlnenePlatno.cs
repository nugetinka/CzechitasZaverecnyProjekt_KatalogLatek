namespace ZaverecnyProjekt_KatalogLatek.KatalogLatek
{
    public class BavlnenePlatno : Latka
    {
        public int Srazlivost { get; private set; }
        public enum EKategorie
        {
            Plátno, Popelín, Košilovina, Kanfas
        }
        public EKategorie Kategorie { get; private set; }

        public BavlnenePlatno(string nazev, EBarva barva, EKategorie kategorie, string slozeni, double gramaz, double cena, double zasoba, bool certifikat, int srazlivost)
            : base(nazev, barva, slozeni, gramaz, cena, zasoba, certifikat)
        {
            Srazlivost = srazlivost;
            Kategorie = kategorie;
        }

        public override void VypisInformaceOLatce()
        {
            base.VypisInformaceOLatce();
            Console.WriteLine($"Srážlivost: {Srazlivost} %, \nKategorie: {Kategorie} ");
            Console.WriteLine();
        }
    }
}
