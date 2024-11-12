namespace CleanArchitecture.Domain.Entities.Rentals.Events;

using CleanArchitecture.Domain.Abstractions;

public sealed record RentalCompletedDomainEvents( Guid rentalId ): IDomainEvent
{
}
