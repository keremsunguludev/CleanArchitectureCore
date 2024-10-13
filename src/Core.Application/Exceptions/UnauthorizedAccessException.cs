using System;

namespace Core.Application.Exceptions;

public class UnauthorizedAccessException : Exception
{
    public UnauthorizedAccessException(string message) : base(message)
    {
    }

    public UnauthorizedAccessException(string message, Exception innerException) : base(message, innerException)
    {
    }
}