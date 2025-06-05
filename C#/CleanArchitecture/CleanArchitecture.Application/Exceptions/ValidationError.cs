namespace CleanArchitecture.Application.Exceptions;

public record class ValidationError(string PropertyName, string ErrorMessage );

