using CleanArchitecture.Domain.Cars;

namespace CleanArchitecture.Domain.Interfaces
{
    public interface ICarRepository
    {
        Task<Cars.Cars> GetByIdAsync( Guid carId , CancellationToken cancellationToken = default );
    }
}
