namespace CleanArchitecture.Infrastructure.Repositories;

using CleanArchitecture.Domain.Abstractions;
using Microsoft.EntityFrameworkCore;

public abstract class Repository<T> where T : Entity
{
    protected readonly ApplicationDbContext dbContex;

    protected Repository( ApplicationDbContext dbContex )
    {
        this.dbContex = dbContex;
    }


    public async Task<T?> GetByIdAsync( Guid id, CancellationToken cancellationToken = default )
    {
        return await dbContex.Set<T>().FirstOrDefaultAsync( user => user.Id == id, cancellationToken );
    }

    public void Add(T entity) 
    {
        dbContex.Add( entity );
    }
}
