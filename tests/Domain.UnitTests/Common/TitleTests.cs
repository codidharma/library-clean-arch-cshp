namespace Domain.UnitTests.Common;

public class TitleTests
{
    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    public void WhenEmptyOfWhitespaceIsProvidedAsTitle_ThenCreateMethodThrowsInvalidTitleException(string title)
    {
        //Act
        Action action = () => Title.Create(title);

        //Assert
        action.Should().Throw<InvalidTitleException>();
    }

    [Fact]
    public void WhenValidTitleIsProvided_ThenCreateMethodCreatesAnInstance()
    {
        //Arrange
        string expctedTitle = "Jungle Book";

        //Act
        Title title = Title.Create(expctedTitle);

        //Assert
        title.Should().NotBeNull();
        title.Value.Should().BeEquivalentTo(expctedTitle);
    }
}
