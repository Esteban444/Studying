namespace CleanArchitecture.Dtos.Rentals;

public sealed record RentalRequest( Guid CarId, Guid UserId, DateOnly StartDate, DateOnly EndDate );

