namespace CleanArchitecture.Infrastructure;

using CleanArchitecture.Domain.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

public sealed class ApplicationDbContex: DbContext, IUnitOfWork
{
    public ApplicationDbContex( DbContextOptions options ): base( options )
    {
        
    }

    Task<Guid> IUnitOfWork.SaveChangesAsync( CancellationToken cancellationToken )
    {
        throw new NotImplementedException();
    }
}
