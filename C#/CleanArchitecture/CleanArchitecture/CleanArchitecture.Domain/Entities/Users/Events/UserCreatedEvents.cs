using CleanArchitecture.Domain.Abstractions;

namespace CleanArchitecture.Domain.Entities.Users.Events
{
    public sealed record UserCreatedEvents( Guid userId ): IDomainEvent
    {
    }
}
