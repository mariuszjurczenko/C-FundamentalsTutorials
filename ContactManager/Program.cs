namespace ContactManager;

class Program
{
    static void Main(string[] args)
    {
        IContactManager contactManager = new ContactManager();
        string userInput;
        string filePath = "contacts.json";
        contactManager.LoadFromFile(filePath);

        Console.WriteLine("=== Witaj w aplikacji do zarządzania kontaktami ===");

        do
        {
            Console.WriteLine("\nWybierz jedną z opcji:");
            Console.WriteLine("1. Dodaj nowy kontakt");
            Console.WriteLine("2. Wyświetl wszystkie kontakty");
            Console.WriteLine("3. Wyszukaj kontakt po imieniu");
            Console.WriteLine("4. Zapisz kontakty do pliku");
            Console.WriteLine("5. Wczytaj kontakty z pliku");
            Console.WriteLine("6. Wyjdź z aplikacji");
            userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    contactManager.AddContact();
                    break;
                case "2":
                    contactManager.DisplayContacts();
                    break;
                case "3":
                    contactManager.SearchContact();
                    break;
                case "4":
                    contactManager.SaveToFile(filePath);
                    break;
                case "5":
                    contactManager.LoadFromFile(filePath);
                    break;
                case "6":
                    contactManager.SaveToFile(filePath);
                    Console.WriteLine("Dziekujemy za skorzystanie z aplikacji, Do widzenia!");
                    break;
                default:
                    Console.WriteLine("Niepoprawny wybór, Spróbuj ponownie");
                    break;
            }
        } while (userInput != "6");
    }

   
}