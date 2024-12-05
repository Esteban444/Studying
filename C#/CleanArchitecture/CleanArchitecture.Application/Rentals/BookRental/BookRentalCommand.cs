namespace CleanArchitecture.Application.Rentals.BookRental;

using CleanArchitecture.Application.Abstractions.Messaging;

public record BookRentalCommand( Guid CarId, Guid UserId, DateOnly InitDate, DateOnly EndDate ) : ICommand<Guid>;

