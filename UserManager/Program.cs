using UserManager;

namespace UserManagementApp;

class Program
{
    static void Main(string[] args)
    {
        // Inicjalizacja repozytorium i serwisu
        IUserRepository userRepository = new UserRepository();
        IUserService userService = new UserService(userRepository);

        // Dodanie użytkownika
        Console.WriteLine("Dodawanie użytkownika...");
        userService.RegisterUser(1, "Jan Kowalski", "jan.kowalski@example.com");

        // Pobranie i wyświetlenie dodanego użytkownika
        var user = userRepository.GetUserById(1);
        Console.WriteLine($"Użytkownik dodany: {user.Name}, Email: {user.Email}");

        // Aktualizacja adresu email
        Console.WriteLine("Aktualizacja adresu email...");
        userService.UpdateUserEmail(1, "jan.nowy@example.com");

        // Pobranie i wyświetlenie zaktualizowanego użytkownika
        user = userRepository.GetUserById(1);
        Console.WriteLine($"Zaktualizowany użytkownik: {user.Name}, Email: {user.Email}");
    }
}
