namespace ZaverecnyProjekt_KatalogLatek.KatalogLatek
{
    public abstract class Latka
    {
        private static int _idCounter;
        public int Id { get; private set; }
        public string Nazev { get; private set; }
        public enum EBarva
        {
            Bílá, Žlutá, Oranžová, Červená, Fialová, Modrá, Zelená, Hnědá, Černá, Vícebarevná
        }
        public EBarva Barva { get; private set; }
        public string Slozeni { get; private set; }
        public double Gramaz { get; private set; }
        public double Cena { get; private set; }
        public double Zasoba { get; private set; }
        public bool Certifikat { get; private set; }

        public Latka(string nazev, EBarva barva, string slozeni, double gramaz, double cena, double zasoba, bool certifikat)
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
                $"Kód produktu: {Id}," +
                $"\nNázev: {Nazev}," +
                $"\nBarva: {Barva}," +
                $"\nSložení: {Slozeni}," +
                $"\nGramáž: {Gramaz} g/m2," +
                $"\nCena: {Cena} Kč/m," +
                $"\nZásoba: {Zasoba} m," +
                $"\nCertifikát: {Certifikat}";
        }

        public virtual void VypisInformaceOLatce()
        {
            Console.WriteLine(ToString());
        }
    }
}
