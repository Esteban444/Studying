using CleanArchitecture.Domain.Entities.Users;

namespace CleanArchitecture.Domain.Interfaces
{
    public interface IUsersRepository
    {
        Task<Users> GetByIdAsync( Guid id, CancellationToken cancellationToken = default );

        Task<Users> AddUserAsync( Users user );
    }
}
