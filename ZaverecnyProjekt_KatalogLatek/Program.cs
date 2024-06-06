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
                "Softshell červený",
                Latka.EBarva.Červená,
                Softshell.EKategorie.Jarní,
                "100% polyester",
                260,
                199,
                10,
                true,
                8000
            ));

            // Bavlněné plátno
            katalog.PridejLatku(new BavlnenePlatno(
                "Plátno s pruhy",
                Latka.EBarva.Bílá,
                BavlnenePlatno.EKategorie.Popelín,
                "100% bavlna",
                120,
                99,
                5,
                false,
                3
            ));

            // Úplet
            katalog.PridejLatku(new Uplet(
                "Úplet s jednorožci",
                Latka.EBarva.Vícebarevná,
                Uplet.EKategorie.Teplákovina,
                "95% bavlna, 5% elastan",
                160,
                199,
                12,
                true,
                5
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
                    case 1: // plátno

                 
                    //case 2: // softshell

                    //case 3: // úplet

                    case 4:
                        katalog.VypisInformaceOLatce();
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
