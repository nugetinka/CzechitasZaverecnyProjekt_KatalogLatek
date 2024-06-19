namespace ZaverecnyProjekt_KatalogLatek.KatalogLatek

{
    public class Program
    {
        public static void Main()
        {
            KatalogLatek katalog = new KatalogLatek();

            // Načtení katalogu látek
            List<Latka> prectenyKatalog = katalog.NactiKatalogLatek();

            if (prectenyKatalog != null && prectenyKatalog.Any())
            {
                // Tato část kodu se vykoná jen pokud prectenyKatalog není null a obsahuje alespon jeden prvek
                foreach (var latka in prectenyKatalog)
                {
                    Console.WriteLine(latka);
                    Console.WriteLine();
                }

                // Nastavení statického Id na maximální Id z přečteného katalogu
                Latka.NastavNavazujiciId(prectenyKatalog.Max(l => l.Id));
            }
            else
            {
                // Naseedování defaultních dat
                NaseedujDefaultniData(katalog);
            }

            Console.WriteLine();

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
                        katalog.PridejLatku(KatalogLatek.TypLatky.Platno);
                        break; ;
                    case 2: // přidej softshell
                        katalog.PridejLatku(KatalogLatek.TypLatky.Softshell);
                        break;
                    case 3: // přidej úplet
                        katalog.PridejLatku(KatalogLatek.TypLatky.Uplet);
                        break;
                    case 4: // vypiš látky
                        katalog.ToString();
                        break;
                    case 5:
                        int kodProduktu = KatalogLatek.ZiskejIntOdUzivatele("Zadejte ID/kód produktu, který má být odstraněn." );
                        katalog.OdeberLatku(kodProduktu);
                        break;
                    case 6:
                        ukoncitProgram = true;
                        katalog.UlozKatalogLatek();
                        break;
                    default:
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

        private static void NaseedujDefaultniData(KatalogLatek katalog)
        {
            // Defaultní přidání látek 
            // Softshell
            katalog.PridejLatku(new Softshell(
                nazev: "Softshell červneý",
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

            // Uložení naseedovaných defaultních dat do katalogu
            katalog.UlozKatalogLatek();
            Console.WriteLine("Katalog neobsahuje žádná data. Výchozí data byla přidána do katalogu.");
        }
    }
}
