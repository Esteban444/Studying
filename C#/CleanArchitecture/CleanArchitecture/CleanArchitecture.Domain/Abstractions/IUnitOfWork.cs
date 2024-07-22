namespace CleanArchitecture.Domain.Abstractions
{
    public interface IUnitOfWork
    {
        Task<Guid> SaveChangesAsync( CancellationToken cancellationToken = default );
    }
}
