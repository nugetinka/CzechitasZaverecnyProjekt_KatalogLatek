namespace ZaverecnyProjekt_KatalogLatek.KatalogLatek
{
    public class Program
    {
        public static void Main()
        {
            KatalogLatek katalog = new KatalogLatek();

            // Počáteční přidání látek
            // Softshell
            katalog.PridejLatku(new Softshell(
                nazev: "Softshell červený",
                barva: Barva.Fialová,
                kategorie: Softshell.Kategorie.Jarní,
                slozeni: "100% polyester",
                gramaz: 260,
                cena: 199,
                zasoba: 10,
                certifikat: true,
                vodniSloupec: 8000
            ));

            // Bavlněné plátno
            katalog.PridejLatku(new BavlnenePlatno(
                nazev: "Plátno s pruhy",
                barva: Barva.Bílá,
                kategorie: BavlnenePlatno.Kategorie.Popelín,
                slozeni: "100% bavlna",
                gramaz: 120,
                cena: 99,
                zasoba: 5,
                certifikat: false,
                srazlivost: 3
            ));

            // Úplet
            katalog.PridejLatku(new Uplet(
                nazev: "Úplet s jednorožci",
                barva: Barva.Vícebarevná,
                kategorie: Uplet.Kategorie.Teplákovina,
                slozeni: "95% bavlna, 5% elastan",
                gramaz: 160,
                cena: 199,
                zasoba: 12,
                certifikat: true,
                pruznost: 5
            ));

            // Uživatelské rozhraní
            bool ukoncitProgram = false;
            while (!ukoncitProgram)
            {
                ZobrazUzivatelskeRozhrani();
                if (!int.TryParse(Console.ReadLine(), out int volba))
                {
                    Console.WriteLine("Neplatný výběr, zadej volbu znovu: ");
                }

                switch (volba)
                {
                    case 1: // přidej plátno
                        katalog.PridejLatku(KatalogLatek.TypLatky.Plátno);
                        break;
                    case 2: // přidej softshell
                        katalog.PridejLatku(KatalogLatek.TypLatky.Softshell);
                        break;
                    case 3: // přidej úplet
                        katalog.PridejLatku(KatalogLatek.TypLatky.Úplet);
                        break;
                    case 4:
                        katalog.ToString();    
                        break;
                    case 5:
                        Console.WriteLine("Zadejte ID/kód produktu, který má být odstraněn.");
                        bool platnyKodProduktu = int.TryParse(Console.ReadLine(), out int kodProduktu);
                        if (platnyKodProduktu)
                        {
                            katalog.OdeberLatku(kodProduktu);
                        }
                        else
                        {
                            Console.WriteLine("Neplatný kód produktu.");
                        }
                        break;
                    case 6:
                        ukoncitProgram = true;
                        break;
                    case 7:
                        Console.WriteLine("Neplatný výběr, zadej volbu znovu: ");
                        break;
                }
            }
        }

        public static void ZobrazUzivatelskeRozhrani()
        {
            Console.WriteLine("Katalog látek - zvolte jednu z následujících možností:");
            Console.WriteLine();
            Console.WriteLine("1. Přidej bavlněné plátno");
            Console.WriteLine("2. Přidej softshell");
            Console.WriteLine("3. Přidej úplet");
            Console.WriteLine("4. Vypiš všechny látky");
            Console.WriteLine("5. Odeber látku z katalogu podle ID látky");
            Console.WriteLine("6. Ukonči program");
        }
    }
}
