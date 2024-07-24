using CleanArchitecture.Domain.Abstractions;
using CleanArchitecture.Domain.Cars;
using CleanArchitecture.Domain.Entities.Cars;
using CleanArchitecture.Domain.Entities.Rentals.Events;
using CleanArchitecture.Domain.Services;

namespace CleanArchitecture.Domain.Entities.Rentals
{
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
            Staus = status;
            DateRange = dateRange;
            CreatedAt = createdAt;
        }

        public Guid CarId { get; private set; }

        public Guid UserId { get; private set; }

        public Currency? Price { get; private set; }

        public Currency? Maintenance { get; private set; }

        public Currency? Accesories { get; private set; }

        public Currency? TotalPrice { get; private set; }

        public RentalStatus Staus { get; private set; }

        public DateRange? DateRange { get; private set; }

        public DateTime? CreatedAt { get; private set; }

        public DateTime? ConfirmationDate { get; private set; }

        public DateTime? NegationDate { get; private set; }

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

            rental.AddEvents( new RentalReservedDomainEvents( rental.Id ) );

            car.LastRentalDate = createdAt;

            return rental;
        }

        public Result Confirm( DateTime date)
        {
            if( Staus != RentalStatus.Resererved )
            {
                throw new Exception();
            }
        }
    }
}
