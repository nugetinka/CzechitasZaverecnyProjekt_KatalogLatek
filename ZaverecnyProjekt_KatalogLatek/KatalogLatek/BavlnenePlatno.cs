using System.Xml.Serialization;

namespace ZaverecnyProjekt_KatalogLatek.KatalogLatek
{
    public class BavlnenePlatno : Latka
    {
        public int Srazlivost { get; set; }
        public Kategorie KategoriePlatno { get; set; }

        [XmlType("KategoriePlátno")]
        public enum Kategorie
        {
            Plátno,
            Popelín,
            Košilovina,
            Kanfas
        }

        // Bezparametrový konstruktor
        public BavlnenePlatno() { }

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
