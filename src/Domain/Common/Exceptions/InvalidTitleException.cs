namespace Domain.Common.Exceptions;

public sealed class InvalidTitleException(string message) : Exception(message);
