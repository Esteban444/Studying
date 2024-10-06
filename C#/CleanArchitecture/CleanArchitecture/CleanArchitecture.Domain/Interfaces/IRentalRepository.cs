namespace CleanArchitecture.Domain.Interfaces;

#region Usings
using CleanArchitecture.Domain.Cars;
using CleanArchitecture.Domain.Entities.Rentals;
#endregion

public interface IRentalRepository
{
    Task<Rental?> GetRentalByIdAsync( Guid id, CancellationToken cancellationToken = default );

    Task<bool> IsOverlappingAsync(
        Car car,
        DateRange duration,
        CancellationToken cancellationToken = default
    );

    Task<Rental> AddRentalAsync( Rental rental );
}
