using CleanArchitecture.Domain.Entities.Users;

namespace CleanArchitecture.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<Users> GetByIdAsync( Guid id, CancellationToken cancellationToken = default );

        void Add( Users user );
    }
}
