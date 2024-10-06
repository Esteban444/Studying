 namespace CleanArchitecture.Domain.Entities.Rentals.Events;

 using CleanArchitecture.Domain.Abstractions;

 public sealed record RentalRejectDomainEvent( Guid rentalId ): IDomainEvent
 {
 }

