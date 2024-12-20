using Domain.Common.Exceptions;

namespace Domain.Common.Types;

public sealed record Isbn
{
    const int Isbn10Length = 10;
    const int Isbn13Length = 13;
    const string InvalidIsbnExceptionMessage = "The provided Isbn {0} is not a valid ISBN-13 or ISBN-10 number";
    public string Value { get; init; }
    private Isbn(string isbn)
    {
        Value = isbn;
    }

    public static Isbn Create(string isbn)
    {
        if(! Isbn.IsValid(isbn))
        {
            throw new InvalidIsbnException(string.Format(InvalidIsbnExceptionMessage, isbn));
        }

        return new Isbn(isbn);
    }

    private static bool IsValid(string isbn)
    {
        if(string.IsNullOrWhiteSpace(isbn))
        {
            return false;
        }

        isbn = isbn.Replace("-","").Replace(" ","");

        if(isbn.Length == Isbn10Length)
        {
            return IsValidIsbn10(isbn);
        }

        if(isbn.Length == Isbn13Length)
        {
            return IsValidIsbn13(isbn);
        }
        return false;
    }

    private static bool IsValidIsbn10(string isbn)
    {
        if(!long.TryParse(isbn.Substring(0,9), out _))
        {
            return false;
        }
        int sum = 0;

        for(int i = 0; i < 9; i++)
        {
            sum += (isbn[i] - '0') * (10 - i);
        }
        char checksum = isbn[9];
        sum += (checksum == 'X' ? 10 : checksum - '0');
        return sum % 11 == 0;
    }

    private static bool IsValidIsbn13(string isbn)
    {
        if(!long.TryParse(isbn, out _))
        {
            return false;
        }
        int sum = 0;

        for (int i = 0; i < 12; i++)
        {
            sum += (isbn[i] - '0') * (i % 2 == 0 ? 1 : 3);
        }
        int checksum = (10 - (sum % 10)) % 10;

        return checksum == (isbn[12] - '0');
    }
}
