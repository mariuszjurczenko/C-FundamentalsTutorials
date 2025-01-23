using Xunit;

namespace UserManager.Tests;

public class UserRepositoryTests
{
    [Fact]
    public void AddUser_ShouldAddUserToList()
    {
        // Arrange
        var userRepository = new UserRepository();
        var user = new User(1, "Jan Kowalski", "jan.kowalski@example.com");

        // Act
        userRepository.AddUser(user);

        // Assert
        var result = userRepository.GetUserById(1);
        Assert.Equal(user, result);
    }

    [Fact]
    public void GetUserById_ShouldReturnUser_WhenUserExists()
    {
        // Arrange
        var userRepository = new UserRepository();
        var user = new User(1, "Jan Kowalski", "jan.kowalski@example.com");
        userRepository.AddUser(user);

        // Act
        var result = userRepository.GetUserById(1);

        // Assert
        Assert.Equal(user, result);
    }

    [Fact]
    public void GetUserById_ShouldThrowException_WhenUserDoesNotExist()
    {
        // Arrange
        var userRepository = new UserRepository();

        // Act & Assert
        Assert.Throws<KeyNotFoundException>(() => userRepository.GetUserById(1));
    }

    [Fact]
    public void UpdateUser_ShouldUpdateUserInList()
    {
        // Arrange
        var userRepository = new UserRepository();
        var user = new User(1, "Jan Kowalski", "jan.kowalski@example.com");
        userRepository.AddUser(user);

        // Act
        user.UpdateEmail("jan.nowy@example.com");
        userRepository.UpdateUser(user);

        // Assert
        var result = userRepository.GetUserById(1);
        Assert.Equal("jan.nowy@example.com", result.Email);
    }



    [Fact]
    public void RemoveUser_ShouldRemoveUserFromList()
    {
        // Arrange
        var userRepository = new UserRepository();
        var user = new User(1, "Jan Kowalski", "jan.kowalski@example.com");
        userRepository.AddUser(user);

        // Act
        userRepository.RemoveUser(1);

        // Assert
        Assert.Throws<KeyNotFoundException>(() => userRepository.GetUserById(1));
    }
}

