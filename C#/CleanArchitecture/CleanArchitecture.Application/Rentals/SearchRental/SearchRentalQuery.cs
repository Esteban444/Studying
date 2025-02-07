namespace CleanArchitecture.Application.Rentals.SearchRental;

using CleanArchitecture.Application.Abstractions.Messaging;

public class SearchRentalQuery( Guid rentalId ): IQuery<RentalResponse>
{
}
