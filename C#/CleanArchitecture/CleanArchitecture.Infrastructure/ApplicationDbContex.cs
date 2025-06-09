namespace CleanArchitecture.Infrastructure;

using CleanArchitecture.Application.Exceptions;
using CleanArchitecture.Domain.Abstractions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

public sealed class ApplicationDbContex: DbContext, IUnitOfWork
{
    private readonly IPublisher publisher;
    public ApplicationDbContex( DbContextOptions options, IPublisher publisher ) : base(options)
    {
        this.publisher = publisher;
    }

    Task<Guid> IUnitOfWork.SaveChangesAsync( CancellationToken cancellationToken )
    {
        throw new NotImplementedException();
    }

    protected override void OnModelCreating( ModelBuilder modelBuilder )
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContex).Assembly);

        base.OnModelCreating( modelBuilder );
    }

    public override async Task<int> SaveChangesAsync ( CancellationToken cancellationToken = default )
    {
        try
        {
            var result = await base.SaveChangesAsync(cancellationToken);

            await PublishDomainEventsAsync();

            return result;
        }
        catch ( DbUpdateConcurrencyException ex )
        {
            throw new ConcurrencyException( "The concurrency exception." , ex );
        }
    }

    private  async Task PublishDomainEventsAsync() 
    {
        var domainEvents = ChangeTracker.Entries<Entity>().Select( entity => entity.Entity )
                                                         .SelectMany( entity =>
                                                         {
                                                             var domainEvents = entity.GetDomainEvents();
                                                             entity.ClearEvents();
                                                             return domainEvents;
                                                         }).ToList();

        foreach ( var domainEvent in domainEvents )
        {
            await publisher.Publish( domainEvent );
        }
    }
}
