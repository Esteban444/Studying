namespace CleanArchitecture.Infrastructure.Repositories;

using CleanArchitecture.Domain.Cars;
using CleanArchitecture.Domain.Interfaces;

public sealed class CarRepository( ApplicationDbContex dbContex ) : Repository<Cars>( dbContex ), ICarRepository
{
}
