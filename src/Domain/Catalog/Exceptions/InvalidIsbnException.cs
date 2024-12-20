namespace Domain.Catalog.Exceptions;

public sealed class InvalidIsbnException(string message) : Exception(message);
