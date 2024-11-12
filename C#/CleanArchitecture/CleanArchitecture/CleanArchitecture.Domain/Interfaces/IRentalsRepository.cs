namespace CleanArchitecture.Domain.Interfaces;

#region Usings
using CleanArchitecture.Domain.Cars;
using CleanArchitecture.Domain.Entities.Rentals;
#endregion

public interface IRentalsRepository
{
    Task<Rentals?> GetRentalByIdAsync( Guid id, CancellationToken cancellationToken = default );

    Task<bool> IsOverlappingAsync(
        Cars car,
        DateRanges duration,
        CancellationToken cancellationToken = default
    );

    Task<Rentals> AddRentalAsync( Rentals rental );
}
