using static ZaverecnyProjekt_KatalogLatek.KatalogLatek.Barva;

namespace ZaverecnyProjekt_KatalogLatek.KatalogLatek
{
    public abstract class Latka
    {
        private static int _idCounter;
        public int Id { get; set; }
        public string Nazev { get; private set; }
        public Barva Barva { get; private set; }
        public string Slozeni { get; private set; }
        public double Gramaz { get; private set; }
        public double Cena { get; private set; }
        public double Zasoba { get; private set; }
        public bool Certifikat { get; private set; }

        public Latka(string nazev, Barva barva, string slozeni, double gramaz, double cena, double zasoba, bool certifikat)
        {
            Id = ++_idCounter;
            Nazev = nazev;
            Barva = barva;
            Slozeni = slozeni;
            Gramaz = gramaz;
            Cena = cena;
            Zasoba = zasoba;
            Certifikat = certifikat;
        }

        public override string ToString()
        {
            return
                $"Kod produktu: {Id}," +
                $"\nNazev: {Nazev}," +
                $"\nBarva: {Barva}," +
                $"\nSlozeni: {Slozeni}," +
                $"\nGramaz: {Gramaz} g/m2," +
                $"\nCena: {Cena} Kc/m," +
                $"\nZasoba: {Zasoba} m," +
                $"\nCertifikat: {(Certifikat ? "true" : "false")}";
        }         
    }
}
