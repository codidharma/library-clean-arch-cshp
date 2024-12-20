namespace Domain.UnitTests.Catalog;

public class AuthorTests
{
    [Theory]
    [InlineData("","D'Souza")]
    [InlineData(" ","D'Souza")]
    [InlineData("Neil", "")]
    [InlineData("Neil", " ")]
    [InlineData("", "")]
    [InlineData(" ", " ")]
    public void WhenEmptyFirstOrLastNameIsProvided_ThenCreateMethodThroughsInvalidAuthorException(string firstName, string lastName)
    {
        //Act
        Action action = () => Author.Create(firstName, lastName);

        //Assert
        action.Should().Throw<InvalidAuthorException>();
    }

    [Theory]
    [InlineData("Neil", "D'Souza")]
    [InlineData("Padmini", "Shah")]
    public void WhenFirstAndLastNameIsProvided_TheCreateMethodCreatesAnInstance(string firstName, string lastName)
    {
        //Arrange
        string expectedName = $"{firstName} {lastName}";

        //Act
        Author author = Author.Create(firstName, lastName);

        //Assert
        author.Should().NotBeNull();
        author.Name.Should().BeEquivalentTo(expectedName);
    }
}
