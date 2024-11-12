using CleanArchitecture.Domain.Cars;

namespace CleanArchitecture.Domain.Interfaces
{
    public interface ICarsRepository
    {
        Task<Cars.Cars> GetByIdAsync( Guid carId , CancellationToken cancellationToken = default );
    }
}
