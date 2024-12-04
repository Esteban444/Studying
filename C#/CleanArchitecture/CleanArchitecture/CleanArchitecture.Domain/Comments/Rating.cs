namespace CleanArchitecture.Domain.Comments;

using CleanArchitecture.Domain.Abstractions;

public sealed record Rating
{
    public static readonly Error invalid = new("Rating.Invalid", "The rating is invalid.");

    public int Value { get; init; }

    private Rating ( int value ) => Value = value;

    public static Result<Rating> Create(int value)
    {
        if (value < 1 || value > 5)
        {
            return Result.Failure<Rating>( invalid );
        }

        return new Rating( value );
    }
}
