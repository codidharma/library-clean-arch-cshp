using System.Text.RegularExpressions;

namespace Domain.Common;

public sealed class Isbn
{
    const string InvalidIsbnExceptionMessage = "The provided Isbn {0} is not a valid ISBN-13 or ISBN-10 number";
    public string Value { get; init; }
    private Isbn(string isbnNumber)
    {
        Value = isbnNumber;

    }

    public static Isbn Create(string isbnNumber)
    {
        if(! Isbn.IsValid(isbnNumber))
        {
            throw new InvalidIsbnException(string.Format(InvalidIsbnExceptionMessage, isbnNumber));
        }

        return new Isbn(isbnNumber);
    }

    private static bool IsValid(string isbnNumber)
    {
        const string IsbnValidationRegexPattern = @"/^(?=(?:\D*\d){10}(?:(?:\D*\d){3})?$)[\d-]+$/";
        Regex regex = new Regex(IsbnValidationRegexPattern);
        bool isValidIsbnNumber = regex.IsMatch(isbnNumber);
        return isValidIsbnNumber;
    }
}
