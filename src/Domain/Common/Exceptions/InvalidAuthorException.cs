namespace Domain.Common.Exceptions;

public sealed class InvalidAuthorException(string message) : Exception(message);
