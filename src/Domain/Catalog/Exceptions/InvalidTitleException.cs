namespace Domain.Catalog.Exceptions;

public sealed class InvalidTitleException(string message) : Exception(message);
