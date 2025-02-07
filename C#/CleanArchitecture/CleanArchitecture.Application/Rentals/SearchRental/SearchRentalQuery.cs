namespace CleanArchitecture.Application.Rentals.SearchRental;

using CleanArchitecture.Application.Abstractions.Messaging;

public sealed record SearchRentalQuery( Guid RentalId ): IQuery<RentalResponse>
{
}
