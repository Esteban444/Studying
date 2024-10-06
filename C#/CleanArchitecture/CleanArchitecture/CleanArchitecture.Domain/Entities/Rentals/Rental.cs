namespace CleanArchitecture.Domain.Entities.Rentals;

#region Usings
using CleanArchitecture.Domain.Abstractions;
using CleanArchitecture.Domain.Cars;
using CleanArchitecture.Domain.Entities.Cars;
using CleanArchitecture.Domain.Entities.Rentals.Events;
using CleanArchitecture.Domain.Services;
#endregion

public sealed class Rental : Entity
{
    private Rental( 
        Guid id,
        Guid carId,
        Guid userId,
        Currency price,
        Currency maintenance,
        Currency accesories,
        Currency totalPrice,
        RentalStatus status,
        DateRange dateRange,
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

    public Currency? Price { get; private set; }

    public Currency? Maintenance { get; private set; }

    public Currency? Accesories { get; private set; }

    public Currency? TotalPrice { get; private set; }

    public RentalStatus Status { get; private set; }

    public DateRange? DateRange { get; private set; }

    public DateTime? CreatedAt { get; private set; }

    public DateTime? ConfirmationDate { get; private set; }

    public DateTime? RejectDate { get; private set; }

    public DateTime? CompletedDate { get; private set; }

    public DateTime? CanceledDate { get; private set; }


    public static Rental Reserva( 
        Car car, 
        Guid userId, 
        DateRange dateRange,
        DateTime createdAt,
        PriceService priceService
        )
    {
        var detailsPrice = priceService.CalculatedPrice( 
              car,
              dateRange
            );
        var rental = new Rental
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

        RaiseDomainEvent( new RentalConfirmedDomainEvent( Id ) );

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

        RaiseDomainEvent( new RentalRejectDomainEvent( Id ) );

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

        RaiseDomainEvent( new RentalCanceledDomainEvent( Id ) );

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

        RaiseDomainEvent( new RentalCompletedDomainEvent( Id ) );

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

        RaiseDomainEvent( new RentalCompletedDomainEvent( Id ) );

        return Result.Success();
    }
}
