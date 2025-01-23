namespace UserManager;

public class UserRepository : IUserRepository
{
    private readonly List<User> _users = new List<User>();

    public void AddUser(User user)
    {
        if (user == null) throw new ArgumentNullException(nameof(user));
        _users.Add(user);
    }

    public User GetUserById(int id)
    {
        return _users.FirstOrDefault(u => u.Id == id) ?? throw new KeyNotFoundException("User not found");
    }

    public void RemoveUser(int id)
    {
        var user = GetUserById(id);
        _users.Remove(user);
    }

    public void UpdateUser(User user)
    {
        var existingUser = GetUserById(user.Id);
        existingUser.UpdateEmail(user.Email);
    }
}
