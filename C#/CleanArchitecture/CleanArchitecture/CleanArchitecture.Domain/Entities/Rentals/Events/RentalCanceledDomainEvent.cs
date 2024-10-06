namespace CleanArchitecture.Domain.Entities.Rentals.Events;

using CleanArchitecture.Domain.Abstractions;

public sealed record  RentalCanceledDomainEvent( Guid rentalId ): IDomainEvent
{
}
