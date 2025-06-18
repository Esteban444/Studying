namespace CleanArchitecture.Infrastructure.Repositories;

using CleanArchitecture.Domain.Cars;
using CleanArchitecture.Domain.Entities.Rentals;
using CleanArchitecture.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

public sealed class RentalRepository : Repository<Rentals>, IRentalRepository
{
    private readonly RentalStatus[] rentalStatuses = {
        RentalStatus.Reserved,
        RentalStatus.Confirmed,
        RentalStatus.Completed
    };
    public RentalRepository( ApplicationDbContext dbContex ) : base( dbContex )
    {
    }

    public async Task<bool> IsOverlappingAsync( Cars car, DateRanges duration, CancellationToken cancellationToken = default )
    {
        return await dbContex.Set<Rentals>().AnyAsync(
            rental => rental.CarId == car.Id &&
            rental.DateRange!.StartDate <= duration.EndDate &&
            rental.DateRange.EndDate >= duration.StartDate &&
            rentalStatuses.Contains(rental.Status),
            cancellationToken
            );
    }
}
