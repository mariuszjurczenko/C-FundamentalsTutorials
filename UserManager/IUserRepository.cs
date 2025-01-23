namespace UserManager;

public interface IUserRepository
{
    void AddUser(User user);
    User GetUserById(int id);
    void RemoveUser(int id);
    void UpdateUser(User user);
}
