namespace Domain.Catalog.Exceptions;

public sealed class InvalidAuthorException(string message) : Exception(message);
