using System.Xml.Serialization;

namespace ZaverecnyProjekt_KatalogLatek.KatalogLatek

{
    public class Uplet : Latka
    {
        public int Pruznost { get; set; }
        public Kategorie KategorieUplet { get; set; }

        [XmlType("KategorieÚplet")]
        public enum Kategorie
        {
            Úplet,
            Náplet,
            Teplákovina
        }

        // Bezparametrový konstruktor
        public Uplet() { }

        public Uplet(string nazev, Barva barva, Kategorie kategorie, string slozeni, double gramaz, double cena, double zasoba, bool certifikat, int pruznost)
            : base(nazev, barva, slozeni, gramaz, cena, zasoba, certifikat)
        {
            Pruznost = pruznost;
            KategorieUplet = kategorie;
        }

        public override string ToString()
        {
            return base.ToString() +
            $"\nPružnost: {Pruznost} %, " +
            $"\nKategorie: {KategorieUplet}";
        }
    }
}
