namespace CleanArchitecture.Domain.Entities.Comments;

using CleanArchitecture.Domain.Abstractions;

public static class CommentsErrors
{
    public static readonly Error NotElegible = new("Comments.NotElegible", "Comment not eligible because not yet completed.");
}
