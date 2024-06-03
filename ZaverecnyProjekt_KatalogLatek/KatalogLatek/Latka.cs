namespace ZaverecnyProjekt_KatalogLatek.KatalogLatek
{
    public abstract class Latka
    {
        public int _id { get; private set; }
        public string _nazev { get; private set; }
        public string _barva { get; private set; }
        public string _kategorie { get; private set; }
        public string _slozeni { get; private set; }
        public double _gramaz { get; private set; }
        public double _cena { get; private set; }
        public double _zasoba { get; private set; }
        public bool _certifikat { get; private set; }

        public Latka(int id, string nazev, string barva, string kategorie, string slozeni, double gramaz, double cena, double zasoba, bool certifikat)
        {
            _id = id;
            _nazev = nazev;
            _barva = barva;
            _kategorie = kategorie;
            _slozeni = slozeni;
            _gramaz = gramaz;
            _cena = cena;
            _zasoba = zasoba;
            _certifikat = certifikat;
        }

        public virtual void VypisInformaceOLatce()
        {
            Console.WriteLine($"Kód produktu: {_id}");
            Console.WriteLine($"Název: {_nazev}");
            Console.WriteLine($"Barva: {_barva}");
            Console.WriteLine($"Kategorie: {_kategorie}");
            Console.WriteLine($"Složení: {_slozeni}");
            Console.WriteLine($"Gramáž: {_gramaz} g/m2");
            Console.WriteLine($"Cena: {_cena} Kč/m");
            Console.WriteLine($"Zásoba: {_zasoba} m");
            Console.WriteLine($"Certifikát: {_certifikat}");
        }
    }
}
