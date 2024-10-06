namespace CleanArchitecture.Domain.Abstractions;

public record Error( string code, string message )
{
    public static Error Nonne = new Error(string.Empty, string.Empty);

    public static Error NullValue = new Error( "Error.Null", "The value is null." );
}
