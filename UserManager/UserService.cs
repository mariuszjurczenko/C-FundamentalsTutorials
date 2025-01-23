namespace UserManager;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
    }

    public void RegisterUser(int id, string name, string email)
    {
        var user = new User(id, name, email);
        _userRepository.AddUser(user);
    }

    public void UpdateUserEmail(int id, string newEmail)
    {
        var user = _userRepository.GetUserById(id);
        user.UpdateEmail(newEmail);
        _userRepository.UpdateUser(user);
    }
}
