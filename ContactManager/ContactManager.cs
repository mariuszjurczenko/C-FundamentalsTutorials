using System.Text.Json;

namespace ContactManager;

internal class ContactManager : IContactManager
{
    List<Contact> contacts = new List<Contact>();

    public void AddContact()
    {
        Console.WriteLine("\n=== Dodaj nowy kontakt ===");
        Console.Write("Podaj Imię: ");
        string firstName = Console.ReadLine();
        Console.Write("Podaj Nazwisko: ");
        string lastName = Console.ReadLine();
        Console.Write("Podaj Email: ");
        string email = Console.ReadLine();
        Console.Write("Podaj Telefon: ");
        string phoneNumber = Console.ReadLine();

        contacts.Add(new Contact(firstName, lastName, email, phoneNumber));
        Console.WriteLine("Kontakt został dodany");
    }

    public void DisplayContacts()
    {
        Console.WriteLine("\n=== Lista kontaktów ===");

        if (contacts.Count == 0)
        {
            Console.WriteLine("Brak kontaktów do wyświetlenia");
            return;
        }

        foreach (var contact in contacts)
        {
            Console.WriteLine(contact);
        }
    }

    public void SearchContact()
    {
        Console.WriteLine("\n=== Wyszukaj kontakt ===");
        Console.Write("Podaj Imię do wyszukania: ");
        string searchName = Console.ReadLine();

        var foundContacts = contacts.FindAll(c => c.FirstName.Equals(searchName, StringComparison.OrdinalIgnoreCase)).ToList();

        if (foundContacts.Count > 0)
        {
            Console.WriteLine($"Znaleziono {foundContacts.Count} kontakt(ów)");
            foreach (var contact in foundContacts)
            {
                Console.WriteLine(contact);
            }
        }
        else
        {
            Console.WriteLine("Brak kontaktów do wyświetlenia");
        }
    }

    public void SaveToFile(string filePath)
    {
        try
        {
            var json = JsonSerializer.Serialize(contacts, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
            Console.WriteLine($"Kontakty zostały zapisane do pliku: {filePath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Błąd podczas zapisywania do pliku: {filePath}");
        }
    }

    public void LoadFromFile(string filePath)
    {
        try
        {
            if (File.Exists(filePath))
            {
                var json = File.ReadAllText(filePath);
                contacts = JsonSerializer.Deserialize<List<Contact>>(json) ?? new List<Contact>();
                Console.WriteLine($"Kontakty zostały wczytane z pliku: {filePath}");
            }
            else
            {
                Console.WriteLine($"Plik o ścieżce {filePath} nie istnieje. Nie można wczytać kontaktów.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Błąd podczas wczytywania z pliku: {ex.Message}");
        }
    }
}
