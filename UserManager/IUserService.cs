namespace UserManager;

public interface IUserService
{
    void RegisterUser(int id, string name, string email);
    void UpdateUserEmail(int id, string newEmail);
}
