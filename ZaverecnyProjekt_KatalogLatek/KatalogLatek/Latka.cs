namespace ZaverecnyProjekt_KatalogLatek.KatalogLatek
{
    public abstract class Latka
    {
        private static int _idCounter;
        public int Id { get; set; }
        public string Nazev { get; set; }
        public Barva Barva { get; set; }
        public string Slozeni { get; set; }
        public double Gramaz { get; set; }
        public double Cena { get; set; }
        public double Zasoba { get; set; }
        public bool Certifikat { get; set; }

        // Bezparametrový konstuktor
        public Latka() { }

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
