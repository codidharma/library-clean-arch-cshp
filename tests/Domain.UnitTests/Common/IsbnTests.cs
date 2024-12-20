namespace Domain.UnitTests.Common;

public class IsbnTests
{
    [Theory]
    [InlineData("ABC")]
    public void WhenIncorrectIsbnStringIsProvided_ThenCreateMethodShouldThrowInvalidIsbnException(string isbnString)
    {
        Action action = () => Isbn.Create(isbnString);

        //Assert
        action.Should().Throw<InvalidIsbnException>();
    }
}
