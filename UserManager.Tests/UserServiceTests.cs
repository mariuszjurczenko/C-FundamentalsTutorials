using Moq;
using Xunit;

namespace UserManager.Tests;

public class UserServiceTests
{
    [Fact]
    public void RegisterUser_ShouldAddUserToRepository()
    {
        // Arrange
        var mockRepo = new Mock<IUserRepository>();
        var userService = new UserService(mockRepo.Object);

        // Act
        userService.RegisterUser(1, "Jan Kowalski", "jan.kowalski@example.com");

        // Assert
        mockRepo.Verify(repo => repo.AddUser(It.Is<User>(u =>
            u.Id == 1 && u.Name == "Jan Kowalski" && u.Email == "jan.kowalski@example.com")), Times.Once);
    }

    [Fact]
    public void UpdateUserEmail_ShouldUpdateUserEmailInRepository()
    {
        // Arrange
        var mockRepo = new Mock<IUserRepository>();
        var user = new User(1, "Jan Kowalski", "jan.kowalski@example.com");
        mockRepo.Setup(repo => repo.GetUserById(1)).Returns(user);

        var userService = new UserService(mockRepo.Object);

        // Act
        userService.UpdateUserEmail(1, "jan.nowy@example.com");

        // Assert
        Assert.Equal("jan.nowy@example.com", user.Email);
        mockRepo.Verify(repo => repo.UpdateUser(user), Times.Once);
    }

    [Fact]
    public void UpdateUserEmail_ShouldThrowException_WhenUserNotFound()
    {
        // Arrange
        var mockRepo = new Mock<IUserRepository>();
        mockRepo.Setup(repo => repo.GetUserById(1)).Throws(new KeyNotFoundException("User not found"));

        var userService = new UserService(mockRepo.Object);

        // Act & Assert
        Assert.Throws<KeyNotFoundException>(() => userService.UpdateUserEmail(1, "jan.nowy@example.com"));
    }
}
