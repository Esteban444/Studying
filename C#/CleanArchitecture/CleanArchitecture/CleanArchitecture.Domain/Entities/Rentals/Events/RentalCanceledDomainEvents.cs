namespace CleanArchitecture.Domain.Entities.Rentals.Events;

using CleanArchitecture.Domain.Abstractions;

public sealed record  RentalCanceledDomainEvents( Guid rentalId ): IDomainEvent
{
}
