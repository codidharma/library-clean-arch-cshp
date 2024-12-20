namespace Domain.UnitTests.Common;

public class IsbnTests
{
    [Theory]
    [InlineData("")]
    [InlineData("ABC1236789")]
    [InlineData("1234567891")]
    [InlineData("ABCDE12345678")]
    [InlineData("1234567891234")]
    [InlineData("123456789")]
    [InlineData("ABC")]
    public void WhenIncorrectIsbnStringIsProvided_ThenCreateMethodShouldThrowInvalidIsbnException(string isbnString)
    {
        Action action = () => Isbn.Create(isbnString);

        //Assert
        action.Should().Throw<InvalidIsbnException>();
    }

    [Theory]
    [InlineData("0306406152")]
    [InlineData("9780306406157")]
    public void WhenCorrectIsbnStringIsProvided_ThenCreateMethodShouldReturnAnInstance(string isbnString)
    {
        //Act
        Isbn isbn = Isbn.Create(isbnString);

        //Assert
        isbn.Should().NotBeNull();
        isbn.Value.Should().BeEquivalentTo(isbnString);
    }
}
