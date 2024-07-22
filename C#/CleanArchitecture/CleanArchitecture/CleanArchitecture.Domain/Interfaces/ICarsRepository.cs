using CleanArchitecture.Domain.Cars;

namespace CleanArchitecture.Domain.Interfaces
{
    public interface ICarsRepository
    {
        Task<Car> GetByIdAsync( Guid carId , CancellationToken cancellationToken = default );
    }
}
