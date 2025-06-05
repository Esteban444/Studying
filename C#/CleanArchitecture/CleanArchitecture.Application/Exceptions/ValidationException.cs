namespace CleanArchitecture.Application.Exceptions;
public class ValidationException: Exception
{
    public IEnumerable<ValidationError> Errors { get; set; }

    public ValidationException( IEnumerable<ValidationError> errors)
    {
        Errors = errors;
    }
}
