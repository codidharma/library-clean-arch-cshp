namespace Domain.Common;

public sealed class InvalidAuthorException(string message) : Exception(message);
