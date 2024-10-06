namespace CleanArchitecture.Domain.Abstractions;

using System.Diagnostics.CodeAnalysis;

public class Result
{
    protected internal Result( bool isSuccess, Error error)
    {
        if ( IsSuccess && error != Error.Nonne ) 
        {
            throw new InvalidOperationException();
        }

        if ( IsSuccess && error == Error.Nonne) 
        {
            throw new InvalidOperationException();
        }

        this.IsSuccess = isSuccess;
        this.Error = error;

    }

    public bool IsSuccess { get; }

    public bool IsFailure => !IsSuccess; // negacion del Success

    public Error Error { get; }

    public static Result Success () => new( true, Error.Nonne );

    public static Result Failure( Error error ) => new( false, error );

    public static Result<TValue> Success<TValue>( TValue value ) => new( value, true, Error.Nonne );

    public static Result<TValue> Failure<TValue>( Error error ) => new( default, false, error );

    public static Result<TValue> Create<TValue>( TValue? value ) =>  value is not null ? Success( value ) : Failure<TValue>( Error.NullValue );
}

public class Result<TValue>: Result
{
    private readonly TValue? _value;

    protected internal Result( TValue? value, bool isSuccess, Error error )
    : base( isSuccess, error )
    {
        _value = value;
    }

    [NotNull]
    public TValue? Value => IsSuccess ? _value! : throw new InvalidOperationException("Error value is not supported." );

    public static implicit operator Result<TValue>(TValue value) => Create(value);
}


