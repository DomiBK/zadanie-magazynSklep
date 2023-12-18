// Klasa reprezentująca pojedynczy produkt w systemie.
public class Produkt
{
    public string NazwaProducenta { get; set; } // Nazwa producenta produktu - dostęp do pola za pomocą właściwości (hermetyzacja).
    public string NazwaProduktu { get; set; } // Nazwa produktu - dostęp do pola za pomocą właściwości (hermetyzacja).
    public string Kategoria { get; set; } // Kategoria produktu - dostęp do pola za pomocą właściwości (hermetyzacja).
    public string KodProduktu { get; set; } // Unikalny kod produktu - dostęp do pola za pomocą właściwości (hermetyzacja).
    public decimal Cena { get; set; } // Cena produktu - dostęp do pola za pomocą właściwości (hermetyzacja).
    public string Opis { get; set; } // Opis produktu - dostęp do pola za pomocą właściwości (hermetyzacja).
}

// Klasa reprezentująca adres, który może być wykorzystywany w różnych częściach systemu.
public class Adres
{
    public string Ulica { get; set; } // Nazwa ulicy - dostęp do pola za pomocą właściwości (hermetyzacja).
    public string KodPocztowy { get; set; } // Kod pocztowy - dostęp do pola za pomocą właściwości (hermetyzacja).
    public string Miejscowosc { get; set; } // Miejscowość - dostęp do pola za pomocą właściwości (hermetyzacja).
    public string NumerPosesji { get; set; } // Numer posesji budynku - dostęp do pola za pomocą właściwości (hermetyzacja).
    public string NumerLokalu { get; set; } // Numer lokalu (jeśli istnieje) - dostęp do pola za pomocą właściwości (hermetyzacja).
}

// Klasa reprezentująca magazyn przechowujący produkty.
public class Magazyn
{
    public List<Produkt> Produkty { get; set; } // Lista produktów w magazynie - dostęp do pola za pomocą właściwości (hermetyzacja).
    public Adres AdresMagazynu { get; set; } // Adres magazynu - dostęp do pola za pomocą właściwości (hermetyzacja).
}

class Program
{
    static List<Produkt> ListaProduktów = new List<Produkt>(); // Lista dostępnych produktów.

    // Lista magazynów, dostępna w całym programie (modyfikacja widoczności: private - dostęp tylko w obrębie klasy Program).
    static List<Magazyn> magazyny = new List<Magazyn>();

    static void Main(string[] args)
    {
        Console.WriteLine("Witaj w programie");

        while (true)
        {
            Console.WriteLine("1. Dodaj produkt");
            Console.WriteLine("2. Edytuj produkt");
            Console.WriteLine("3. Usuń produkt");
            Console.WriteLine("4. Dodaj produkt do magazynu");
            Console.WriteLine("5. Usuń produkt z magazynu");
            Console.WriteLine("6. Dodaj magazyn");
            Console.WriteLine("7. Edytuj magazyn");
            Console.WriteLine("8. Usuń magazyn");
            Console.WriteLine("9. Wyjście");

            string wybor = (Console.ReadLine());

            switch (wybor)
            {
                case "1":
                    DodajProdukt();
                    break;
                case "2":
                    EdytujProdukt();
                    break;
                case "3":
                    UsunProdukt();
                    break;
                case "4":
                    DodajProduktDoMagazynu();
                    break;
                case "5":
                    UsunProduktZMagazynu();
                    break;
                case "6":
                    DodajMagazyn();
                    break;
                case "7":
                    EdytujMagazyn();
                    break;
                case "8":
                    UsunMagazyn();
                    break;
                case "9":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("\nNieprawidłowy wybór. Wybierz ponownie.\n");
                    break;
            }
        }
    }

    // Funkcja dodająca nowy produkt do listy dostępnych produktów.
    static void DodajProdukt()
    {
        Produkt produkt = new Produkt();
        while (true)
        {
            Console.WriteLine("Podaj nazwę producenta: ");
            string typ = Console.ReadLine();
            if (typ.Length > 0)
            {
                produkt.NazwaProducenta = typ;
                break;
            }
            Console.WriteLine("spróbuj ponownie");
        }
        Console.WriteLine("Podaj nazwę produktu: ");
        produkt.NazwaProduktu = Console.ReadLine();
        Console.WriteLine("Podaj kategorię: ");
        produkt.Kategoria = Console.ReadLine();
        Console.WriteLine("Podaj kod produktu: ");
        produkt.KodProduktu = Console.ReadLine();
        while (true)
        {
            Console.WriteLine("Podaj cenę: ");
            string userInput = Console.ReadLine();
            decimal number;

            if (decimal.TryParse(userInput, out number))
            {
                
                    produkt.Cena = number;
                break; 
            }
            else
            {
                Console.WriteLine("sprobuj ponownie");
            }
        }

        Console.WriteLine("Podaj opis: ");
        produkt.Opis = Console.ReadLine();

        ListaProduktów.Add(produkt);
        Console.WriteLine("\nProdukt został dodany do listy\n");
    }

    // Funkcja edytująca istniejący produkt na liście produktów.
    static void EdytujProdukt()
    {
        Console.WriteLine("\nLista dostępnych produktów:");
        for (int i = 0; i < ListaProduktów.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {ListaProduktów[i].NazwaProduktu}: {ListaProduktów[i].KodProduktu}");
        }
        Console.WriteLine("Podaj numer produktu do edycji: ");
        int numerProduktu = Convert.ToInt32(Console.ReadLine());


        if (numerProduktu >= 1 && numerProduktu <= ListaProduktów.Count)
        {
            Produkt produktDoEdycji = ListaProduktów[numerProduktu - 1];
            Console.WriteLine("Edycja produktu: " + produktDoEdycji.NazwaProduktu);
            Console.WriteLine("Nowa nazwa producenta: ");
            produktDoEdycji.NazwaProducenta = Console.ReadLine();
            Console.WriteLine("Nowa nazwa produktu: ");
            produktDoEdycji.NazwaProduktu = Console.ReadLine();
            Console.WriteLine("Nowa kategoria: ");
            produktDoEdycji.Kategoria = Console.ReadLine();
            while (true)
            {
                Console.WriteLine("Nowa cena: ");
                string userInput = Console.ReadLine();
                decimal number;

                if (decimal.TryParse(userInput, out number))
                {

                    produktDoEdycji.Cena = number;
                    break;
                }
                else
                {
                    Console.WriteLine("sprobuj ponownie");
                }
            }
            
            Console.WriteLine("Nowy opis: ");
            produktDoEdycji.Opis = Console.ReadLine();
            Console.WriteLine("Produkt zaktualizowany.");
        }
        else
        {
            Console.WriteLine("Produkt o podanym numerze nie został znaleziony.");
        }
    }

    // Funkcja usuwająca produkt z listy dostępnych produktów.
    static void UsunProdukt()
    {
        Console.WriteLine("\nLista dostępnych produktów:");
        for (int i = 0; i < ListaProduktów.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {ListaProduktów[i].NazwaProduktu}: {ListaProduktów[i].KodProduktu}");
        }
        Console.WriteLine("Podaj numer produktu do usunięcia: ");
        int numerProduktu;
        if (int.TryParse(Console.ReadLine(), out numerProduktu) && numerProduktu >= 1 && numerProduktu <= ListaProduktów.Count)
        {
            Produkt produktDoUsuniecia = ListaProduktów[numerProduktu - 1];
            ListaProduktów.Remove(produktDoUsuniecia);
            Console.WriteLine("Produkt został usunięty.");
        }
        else
        {
            Console.WriteLine("Nieprawidłowy numer produktu.");
        }
    }

    // Funkcja dodająca produkt do konkretnego magazynu.
    static void DodajProduktDoMagazynu()
    {
        Console.WriteLine("\nLista dostępnych produktów:");
        for (int i = 0; i < ListaProduktów.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {ListaProduktów[i].NazwaProduktu}: {ListaProduktów[i].KodProduktu}");
        }
        Console.WriteLine("Podaj numer produktu do dodania do magazynu: ");
        int numerProduktu;

        if (int.TryParse(Console.ReadLine(), out numerProduktu) && numerProduktu >= 1 && numerProduktu <= ListaProduktów.Count)
        {
            Console.WriteLine("Podaj nazwę magazynu: ");
            string nazwaMagazynu = Console.ReadLine();

            Magazyn magazyn = ZnajdzMagazynPoNazwie(nazwaMagazynu);

            if (magazyn != null)
            {
                Produkt produkt = ListaProduktów[numerProduktu - 1];
                magazyn.Produkty.Add(produkt);
                Console.WriteLine("Produkt został dodany do magazynu.");
            }
            else
            {
                Console.WriteLine("Magazyn o podanej nazwie nie został znaleziony.");
            }
        }
        else
        {
            Console.WriteLine("Nieprawidłowy numer produktu.");
        }
    }

    // Funkcja usuwająca produkt z konkretnego magazynu.
    static void UsunProduktZMagazynu()
    {
        Console.WriteLine("\nLista dostępnych magazynów:");
        for (int i = 0; i < magazyny.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {magazyny[i].AdresMagazynu.Miejscowosc}");
        }
        Console.WriteLine("Podaj nazwę magazynu: ");
        string nazwaMagazynu = Console.ReadLine();

        Magazyn magazyn = ZnajdzMagazynPoNazwie(nazwaMagazynu);

        if (magazyn != null)
        {
            Console.WriteLine($"\nProdukty w magazynie {nazwaMagazynu}:");
            WyswietlProduktyWMagazynie(magazyn);
            Console.WriteLine("Podaj numer produktu do usunięcia z magazynu: ");
            int numerProduktu;

            if (int.TryParse(Console.ReadLine(), out numerProduktu) && numerProduktu >= 1 && numerProduktu <= magazyn.Produkty.Count)
            {
                Produkt produktDoUsuniecia = magazyn.Produkty[numerProduktu - 1];
                magazyn.Produkty.Remove(produktDoUsuniecia);
                Console.WriteLine("Produkt został usunięty z magazynu.");
            }
            else
            {
                Console.WriteLine("Nieprawidłowy numer produktu.");
            }
        }
        else
        {
            Console.WriteLine("Magazyn o podanej nazwie nie został znaleziony.");
        }
    }

    // Funkcja wyświetlająca listę produktów w danym magazynie.
    static void WyswietlProduktyWMagazynie(Magazyn magazyn)
    {
        for (int i = 0; i < magazyn.Produkty.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {magazyn.Produkty[i].KodProduktu}: {magazyn.Produkty[i].NazwaProduktu}");
        }
    }

    // Funkcja znajdująca magazyn po nazwie miejscowości (unikalna nazwa dla każdego magazynu).
    static Magazyn ZnajdzMagazynPoNazwie(string nazwaMagazynu)
    {
        return magazyny.FirstOrDefault(m => m.AdresMagazynu.Miejscowosc == nazwaMagazynu);
    }

    // Funkcja dodająca nowy magazyn do systemu.
    static void DodajMagazyn()
    {
        Magazyn magazyn = new Magazyn();
        Adres adres = new Adres();

        Console.WriteLine("Podaj nazwę magazynu: ");
        string nazwaMagazynu = Console.ReadLine();

        if (ZnajdzMagazynPoNazwie(nazwaMagazynu) != null)
        {
            Console.WriteLine("Magazyn o podanej nazwie już istnieje.");
            return;
        }

        Console.WriteLine("Podaj ulicę magazynu: ");
        adres.Ulica = Console.ReadLine();
        Console.WriteLine("Podaj kod pocztowy: ");
        adres.KodPocztowy = Console.ReadLine();
        Console.WriteLine("Podaj miejscowość: ");
        adres.Miejscowosc = Console.ReadLine();
        Console.WriteLine("Podaj numer posesji: ");
        adres.NumerPosesji = Console.ReadLine();
        Console.WriteLine("Podaj numer lokalu: ");
        adres.NumerLokalu = Console.ReadLine();

        magazyn.AdresMagazynu = adres;
        magazyn.Produkty = new List<Produkt>(); // Inicjalizacja pustej listy produktów

        magazyny.Add(magazyn);
        Console.WriteLine("Magazyn został dodany.");
    }

    // Funkcja usuwająca magazyn z systemu.
    static void UsunMagazyn()
    {
        Console.WriteLine("\nLista dostępnych magazynów:");
        for (int i = 0; i < magazyny.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {magazyny[i].AdresMagazynu.Miejscowosc}");
        }
        Console.Write("Podaj nazwę magazynu do usunięcia: ");
        string nazwaMagazynu = Console.ReadLine();

        Magazyn magazynDoUsuniecia = ZnajdzMagazynPoNazwie(nazwaMagazynu);

        if (magazynDoUsuniecia != null)
        {
            magazyny.Remove(magazynDoUsuniecia);
            Console.WriteLine("Magazyn został usunięty.");
        }
        else
        {
            Console.WriteLine("Magazyn o podanej nazwie nie został znaleziony.");
        }
    }

    // Funkcja edytująca istniejący magazyn w systemie.
    static void EdytujMagazyn()
    {
        Console.WriteLine("\nLista dostępnych magazynów:");
        for (int i = 0; i < magazyny.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {magazyny[i].AdresMagazynu.Miejscowosc}");
        }
        Console.Write("Podaj nazwę magazynu do edycji: ");
        string nazwaMagazynu = Console.ReadLine();

        Magazyn magazynDoEdycji = ZnajdzMagazynPoNazwie(nazwaMagazynu);

        if (magazynDoEdycji != null)
        {
            Console.WriteLine("Edycja magazynu: " + magazynDoEdycji.AdresMagazynu.Miejscowosc);
            Console.WriteLine("Nowa ulica: ");
            magazynDoEdycji.AdresMagazynu.Ulica = Console.ReadLine();
            Console.WriteLine("Nowy kod pocztowy: ");
            magazynDoEdycji.AdresMagazynu.KodPocztowy = Console.ReadLine();
            Console.WriteLine("Nowa miejscowość: ");
            magazynDoEdycji.AdresMagazynu.Miejscowosc = Console.ReadLine();
            Console.WriteLine("Nowy numer posesji: ");
            magazynDoEdycji.AdresMagazynu.NumerPosesji = Console.ReadLine();
            Console.WriteLine("Nowy numer lokalu: ");
            magazynDoEdycji.AdresMagazynu.NumerLokalu = Console.ReadLine();
            Console.WriteLine("Magazyn zaktualizowany.");
        }
        else
        {
            Console.WriteLine("Magazyn o podanej nazwie nie został znaleziony.");
        }
    }
}
