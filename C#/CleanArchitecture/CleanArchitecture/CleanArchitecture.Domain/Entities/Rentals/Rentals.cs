namespace CleanArchitecture.Domain.Entities.Rentals;

#region Usings
using CleanArchitecture.Domain.Abstractions;
using CleanArchitecture.Domain.Cars;
using CleanArchitecture.Domain.Entities.Rentals.Events;
using CleanArchitecture.Domain.Services;
using CleanArchitecture.Domain.Shared;
#endregion

public sealed class Rentals : Entity
{
    private Rentals( 
        Guid id,
        Guid carId,
        Guid userId,
        Currencies price,
        Currencies maintenance,
        Currencies accesories,
        Currencies totalPrice,
        RentalStatus status,
        DateRanges dateRange,
        DateTime createdAt
        ) : base( id )
    {
        CarId = carId;
        UserId = userId;
        Price = price;
        Maintenance = maintenance;
        Accesories = accesories;
        TotalPrice = totalPrice;
        Status = status;
        DateRange = dateRange;
        CreatedAt = createdAt;
    }

    public Guid CarId { get; private set; }

    public Guid UserId { get; private set; }

    public Currencies? Price { get; private set; }

    public Currencies? Maintenance { get; private set; }

    public Currencies? Accesories { get; private set; }

    public Currencies? TotalPrice { get; private set; }

    public RentalStatus Status { get; private set; }

    public DateRanges? DateRange { get; private set; }

    public DateTime? CreatedAt { get; private set; }

    public DateTime? ConfirmationDate { get; private set; }

    public DateTime? RejectDate { get; private set; }

    public DateTime? CompletedDate { get; private set; }

    public DateTime? CanceledDate { get; private set; }


    public static Rentals Reserva( 
        Cars car, 
        Guid userId, 
        DateRanges dateRange,
        DateTime createdAt,
        PricesService priceService
        )
    {
        var detailsPrice = priceService.CalculatedPrice( 
              car,
              dateRange
            );
        var rental = new Rentals
            (
              Guid.NewGuid(),
              car.Id,
              userId,
              detailsPrice.Price,
              detailsPrice.Mantinance,
              detailsPrice.Accesories,
              detailsPrice.TotalPrice,
              RentalStatus.Resererved,
              dateRange,
              createdAt
            );

        rental.RaiseDomainEvent( new RentalReservedDomainEvents( rental.Id ) );

        car.LastRentalDate = createdAt;

        return rental;
    }

    public Result Confirm( DateTime dateUtcNow )
    {
        if( Status != RentalStatus.Resererved )
        {
            return Result.Failure( RentalErrors.NotReserved );
        }

        Status = RentalStatus.Confirmed;
        ConfirmationDate = dateUtcNow;

        RaiseDomainEvent( new RentalConfirmedDomainEvents( Id ) );

        return Result.Success();
    }

    public Result Reject( DateTime dateUtcNow )
    {
        if ( Status != RentalStatus.Resererved )
        {
            return Result.Failure( RentalErrors.NotReserved );
        }

        Status = RentalStatus.Rejected;
        RejectDate = dateUtcNow;

        RaiseDomainEvent( new RentalRejectDomainEvents( Id ) );

        return Result.Success();
    }

    public Result Canceled( DateTime dateUtcNow )
    {
        if ( Status != RentalStatus.Confirmed )
        {
            return Result.Failure( RentalErrors.NotConfirm );
        }

        var currentDate  = DateOnly.FromDateTime( dateUtcNow );

        if( currentDate >  DateRange!.StartDate)
        {
            return Result.Failure( RentalErrors.AlreadyStarted );   
        }

        Status = RentalStatus.Canceled;
        CanceledDate = dateUtcNow;

        RaiseDomainEvent( new RentalCanceledDomainEvents( Id ) );

        return Result.Success();
    }

    public Result Created( DateTime utcNow )
    {
        if ( Status != RentalStatus.Confirmed )
        {
            return Result.Failure( RentalErrors.NotConfirm );
        }

        Status = RentalStatus.Completed;
        CompletedDate = utcNow;

        RaiseDomainEvent( new RentalCompletedDomainEvents( Id ) );

        return Result.Success();
    }

    public Result Completed( DateTime dateUtcNow )
    {
        if ( Status != RentalStatus.Confirmed )
        {
            return Result.Failure( RentalErrors.NotConfirm );
        }

        Status = RentalStatus.Completed;
        CompletedDate = dateUtcNow;

        RaiseDomainEvent( new RentalCompletedDomainEvents( Id ) );

        return Result.Success();
    }
}
