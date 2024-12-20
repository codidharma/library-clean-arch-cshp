using Domain.Catalog.Exceptions;

namespace Domain.Catalog.Types;

public sealed record Author
{
    public string Name { get; init; }

    private Author(string firstName, string lastName)
    {
        Name = $"{firstName} {lastName}";
    }

    public static Author Create(string firstName, string lastName)
    {
        if(string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName))
        {
            throw new InvalidAuthorException("First and Last names of the author are mandatory.");
        }
        return new Author(firstName, lastName);
    }
}
