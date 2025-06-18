namespace CleanArchitecture.Infrastructure.Repositories;

using CleanArchitecture.Domain.Entities.Users;
using CleanArchitecture.Domain.Interfaces;

public sealed class UserRepository( ApplicationDbContext dbContex ) : Repository<Users>( dbContex ), IUserRepository
{
}
