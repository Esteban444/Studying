namespace CleanArchitecture.Domain.Interfaces;

#region Usings
using CleanArchitecture.Domain.Cars;
using CleanArchitecture.Domain.Entities.Rentals;
#endregion

public interface IRentalRepository
{
    Task<Rentals?> GetByIdAsync( Guid id, CancellationToken cancellationToken = default );

    Task<bool> IsOverlappingAsync(
        Cars car,
        DateRanges duration,
        CancellationToken cancellationToken = default
    );

    void Add( Rentals rental );
}
