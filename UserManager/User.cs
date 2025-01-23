namespace UserManager;

public class User
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string Email { get; private set; }

    public User(int id, string name, string email)
    {
        Id = id;
        Name = name ?? throw new ArgumentNullException(nameof(name), "Name cannot be null");
        Email = email ?? throw new ArgumentNullException(nameof(email), "Email cannot be null");
    }

    public void UpdateEmail(string newEmail)
    {
        if (string.IsNullOrWhiteSpace(newEmail))
            throw new ArgumentException("Email cannot be empty", nameof(newEmail));

        Email = newEmail;
    }
}
