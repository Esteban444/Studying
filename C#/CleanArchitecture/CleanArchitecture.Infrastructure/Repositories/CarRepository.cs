namespace CleanArchitecture.Infrastructure.Repositories;

using CleanArchitecture.Domain.Cars;
using CleanArchitecture.Domain.Interfaces;

public sealed class CarRepository( ApplicationDbContext dbContex ) : Repository<Cars>( dbContex ), ICarRepository
{
}
