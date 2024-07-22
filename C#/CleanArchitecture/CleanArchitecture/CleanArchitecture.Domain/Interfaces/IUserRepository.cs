using CleanArchitecture.Domain.Entities.Users;

namespace CleanArchitecture.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetByIdAsync( Guid id, CancellationToken cancellationToken = default );

        Task<User> AddUserAsync( User user );
    }
}
