using CleanArchitecture.Domain.Abstractions;

namespace CleanArchitecture.Domain.Entities.Rentals.Events
{
    public sealed record RentalReservedDomainEvents( Guid rentalId ): IDomainEvent
    {

    }
}
