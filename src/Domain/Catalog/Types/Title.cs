using Domain.Catalog.Exceptions;

namespace Domain.Catalog.Types;

public sealed record Title
{
    public string Value { get; init; }
    private Title(string title)
    {
        Value = title;
    }

    public static Title Create(string title)
    {
        if(string.IsNullOrWhiteSpace(title))
        {
            throw new InvalidTitleException("The title can not be empty or whitespace.");
        }
        return new Title(title);
    }
}
