using System.Text.RegularExpressions;

namespace ContactManager;

public class Contact
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }

    public Contact(string firstName, string lastName, string email, string phoneNumber)
    {
        if (string.IsNullOrWhiteSpace(firstName))
        {
            throw new ArgumentException("Imię nie może być puste", nameof(firstName));
        }
        if (string.IsNullOrWhiteSpace(lastName))
        {
            throw new ArgumentException("Nazwisko nie może być puste", nameof(lastName));
        }
        if (!IsValidRmail(email))
        {
            throw new ArgumentException("Nieprawidłowy format adresu email", nameof(email));
        }
        if (!IsValidPhoneNumber(phoneNumber))
        {
            throw new ArgumentException("Nieprawidłowy numer telefonu. Dozwolone są tylko cyfry", nameof(phoneNumber));
        }


        FirstName = firstName;
        LastName = lastName;
        Email = email;
        PhoneNumber = phoneNumber;
    }

    override public string ToString()
    {
        return $"Imię: {FirstName}, Nazwisko: {LastName}, Email: {Email}, Telefon: {PhoneNumber}";
    }

    private bool IsValidRmail(string email)
    {
        return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
    }

    private bool IsValidPhoneNumber(string phoneNumber)
    {
        return Regex.IsMatch(phoneNumber, @"^\d+$");
    }
}