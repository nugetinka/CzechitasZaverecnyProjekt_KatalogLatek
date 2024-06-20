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
                // Vykonání následující části kódu, pokud prectenyKatalog není null a obsahuje alespon jeden prvek
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
                    Console.WriteLine("Neplatný výběr, zadejte volbu znovu: ");
                    continue;
                }

                switch (volba)
                {
                    case 1: // Přidání plátna
                        katalog.PridejLatku(KatalogLatek.TypLatky.Plátno);
                        break; ;
                    case 2: // Přidání softshellu
                        katalog.PridejLatku(KatalogLatek.TypLatky.Softshell);
                        break;
                    case 3: // Přidání úpletu
                        katalog.PridejLatku(KatalogLatek.TypLatky.Úplet);
                        break;
                    case 4: // Vypsání látek
                        Console.WriteLine(katalog.ToString());
                        Console.WriteLine("Stiskněte libovolnou klávesu pro pokračování...");
                        Console.ReadLine();
                        break;
                    case 5: // Odebrání látky podle ID
                        int kodProduktu = KatalogLatek.ZiskejIntOdUzivatele("Zadejte ID/kód produktu, který má být odstraněn." );
                        katalog.OdeberLatku(kodProduktu);
                        break; 
                    case 6: // Ukončení programu
                        ukoncitProgram = true;
                        katalog.UlozKatalogLatek();
                        break;
                    default:
                        Console.WriteLine("Neplatný výběr, zadejte volbu znovu: ");
                        break;
                }
            }
        }

        public static void ZobrazUzivatelskeRozhrani()
        {
            Console.WriteLine("KATALOG LÁTEK - zvolte jednu z následujících možností:");
            Console.WriteLine();
            Console.WriteLine("1. Přidání bavlněného plátna");
            Console.WriteLine("2. Přidání softshellu");
            Console.WriteLine("3. Přidání úpletu");
            Console.WriteLine("4. Vypsání všech látek");
            Console.WriteLine("5. Odebrání látek z katalogu podle ID látky");
            Console.WriteLine("6. Ukončení programu");
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
            Console.WriteLine("Výchozí data byla přidána do katalogu.");
        }
    }
}
