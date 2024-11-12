 namespace CleanArchitecture.Domain.Entities.Rentals.Events;

 using CleanArchitecture.Domain.Abstractions;

 public sealed record RentalRejectDomainEvents( Guid rentalId ): IDomainEvent
 {
 }

