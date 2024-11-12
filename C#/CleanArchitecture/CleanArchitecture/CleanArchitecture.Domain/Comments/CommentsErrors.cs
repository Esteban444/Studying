namespace CleanArchitecture.Domain.Comments;

using CleanArchitecture.Domain.Abstractions;

public static class CommentsErrors
{
    public static readonly Error NotElegible = new Error( "Comments.NotElegible", "Comments not elegible." );
}
