namespace CleanArchitecture.Domain.Comments.Events;

using CleanArchitecture.Domain.Abstractions;

public sealed record CommentCreatedDomainEvents( Guid rentalId ) : IDomainEvent
{
}
