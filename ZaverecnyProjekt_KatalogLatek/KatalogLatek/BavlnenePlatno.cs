namespace ZaverecnyProjekt_KatalogLatek.KatalogLatek
{
    public class BavlnenePlatno : Latka
    {
        public int Srazlivost { get; private set; }
        public enum Kategorie
        {
            Plátno, 
            Popelín, 
            Košilovina, 
            Kanfas
        }
        public Kategorie KategoriePlatno { get; private set; }

        public BavlnenePlatno(string nazev, Barva barva, Kategorie kategorie, string slozeni, double gramaz, double cena, double zasoba, bool certifikat, int srazlivost)
            : base(nazev, barva, slozeni, gramaz, cena, zasoba, certifikat)
        {
            Srazlivost = srazlivost;
            KategoriePlatno = kategorie;
        }

        public override string ToString()
        {
            return base.ToString() +
            $"\nSrážlivost: {Srazlivost} %, " +
            $"\nKategorie: {KategoriePlatno}";
        }
    }
}
