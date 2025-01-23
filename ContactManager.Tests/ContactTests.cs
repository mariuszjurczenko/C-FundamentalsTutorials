namespace ContactManager.Tests
{
    public class ContactTests
    {
        [Fact]
        public void Constructor_SetsAllPropertiesCorrectly()
        {
            // Arrange
            string firstName = "Jan";
            string lastName = "Kowalski";
            string email = "jan@dev-hobby.pl";
            string phoneNumber = "123456789";

            // Act
            Contact contact = new Contact(firstName, lastName, email, phoneNumber);

            // Assert
            Assert.Equal(firstName, contact.FirstName);
            Assert.Equal(lastName, contact.LastName);
            Assert.Equal(email, contact.Email);
            Assert.Equal(phoneNumber, contact.PhoneNumber);
        }

        [Fact]
        public void ToString_ReturnsCorrectString()
        {
            // Arrange
            string firstName = "Marcin";
            string lastName = "Nowak";
            string email = "marcin.nowak@dev-hobby.pl";
            string phoneNumber = "567657285";
            Contact contact = new Contact(firstName, lastName, email, phoneNumber);

            // Act
            var result = contact.ToString();

            // Assert
            Assert.Equal($"Imię: {firstName}, Nazwisko: {lastName}, Email: {email}, Telefon: {phoneNumber}", result);
        }

        [Theory]
        [InlineData("")]
        [InlineData("    ")]
        [InlineData(null)]
        public void Constructor_ThrowsExceptionWhenFirstNameIsNullOrEmpty(string invalidFirstName)
        {
            // Arrange
            string lastName = "Nowak";
            string email = "marcin.nowak@dev-hobby.pl";
            string phoneNumber = "567657285";

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new Contact(invalidFirstName, lastName, email, phoneNumber));
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void Constructor_InvalidLastName_ThrowsArgumentException(string invalidLastName)
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(() => new Contact("Marcin", invalidLastName, "marcin.nowak@dev - hobby.pl", "567657285"));
        }

        [Theory]
        [InlineData("john.doe@com")]
        [InlineData("john.doe@.com")]
        [InlineData("john.doe.com")]
        [InlineData("john.doe@com.")]
        [InlineData("@example.com")]
        [InlineData("")]
        public void Constructor_InvalidEmail_ThrowsArgumentException(string invalidEmail)
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(() => new Contact("Marcin", "Nowak", invalidEmail, "567657285"));
        }

        [Theory]
        [InlineData("123abc")]
        [InlineData("123-456")]
        [InlineData("(123)456")]
        [InlineData("")]
        public void Constructor_InvalidPhoneNumber_ThrowsArgumentException(string invalidPhoneNumber)
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(() => new Contact("Marcin", "Nowak", "john.doe@example.com", invalidPhoneNumber));
        }
    }
}
