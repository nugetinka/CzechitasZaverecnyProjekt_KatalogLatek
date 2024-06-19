using System.Xml.Serialization;

namespace ZaverecnyProjekt_KatalogLatek.KatalogLatek

{
    public class Softshell : Latka
    {
        public int VodniSloupec { get; set; }
        public Kategorie KategorieSoftshell { get; set; }

        [XmlType("KategorieSoftshell")]
        public enum Kategorie
        {
            Jarní,
            Letní,
            Zimní,
            SFleecem
        }

        // Bezparametrový konstruktor
        public Softshell() { }

        public Softshell(string nazev, Barva barva, Kategorie kategorie, string slozeni, double gramaz, double cena, double zasoba, bool certifikat, int vodniSloupec)
            : base(nazev, barva, slozeni, gramaz, cena, zasoba, certifikat)
        {
            VodniSloupec = vodniSloupec;
            KategorieSoftshell = kategorie;
        }

        public override string ToString()
        {
            return base.ToString() +
            $"\nVodní sloupec: {VodniSloupec} mm, " +
            $"\nKategorie: {KategorieSoftshell}";
        }
    }
}

