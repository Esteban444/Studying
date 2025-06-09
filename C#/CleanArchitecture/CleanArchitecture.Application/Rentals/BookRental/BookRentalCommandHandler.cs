namespace CleanArchitecture.Application.Rentals.BookRental;

using CleanArchitecture.Application.Abstractions.Clock;
using CleanArchitecture.Application.Abstractions.Messaging;
using CleanArchitecture.Application.Exceptions;
using CleanArchitecture.Domain.Abstractions;
using CleanArchitecture.Domain.Entities.Cars;
using CleanArchitecture.Domain.Entities.Rentals;
using CleanArchitecture.Domain.Entities.Users;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Domain.Services;

internal sealed class BookRentalCommandHandler( IUserRepository usersRepository, ICarRepository carsRepository,
                                 IRentalRepository rentalsRepository, PricesService priceService,
                                 IUnitOfWork unitOfWork,IDateTimeProvider dateTimeProvider ) : ICommandHandler<BookRentalCommand, Guid>
{
    private readonly IUserRepository _usersRepository = usersRepository;
    private readonly ICarRepository _carsRepository = carsRepository;
    private readonly IRentalRepository _rentalsRepository = rentalsRepository;
    private readonly PricesService _priceService = priceService;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IDateTimeProvider _dateTimeProvider = dateTimeProvider;

    public async Task<Result<Guid>> Handle( BookRentalCommand request, CancellationToken cancellationToken )
    {
        var user = await _usersRepository.GetByIdAsync( request.UserId , cancellationToken );

        if ( user is null ) 
        { 
            return Result.Failure<Guid>( UserErrors.NotFound );
        }

        var car = await _carsRepository.GetByIdAsync ( request.CarId , cancellationToken );

        if ( car is null )
        {
            return Result.Failure<Guid>( CarErrors.NotFound );
        }

        var duration = DateRanges.Create( request.InitDate, request.EndDate );

        if ( await _rentalsRepository.IsOverlappingAsync( car, duration, cancellationToken ) ) 
        {
            return Result.Failure<Guid>( RentalErrors.Overlap );
        }

        try
        {
            var rental = Rentals.Reserva( car, user.Id, duration, _dateTimeProvider.CurrenTime, _priceService );

            _rentalsRepository.Add( rental );

            await _unitOfWork.SaveChangesAsync( cancellationToken );

            return rental.Id;
        }
        catch ( ConcurrencyException )
        {
            return Result.Failure<Guid>( RentalErrors.Overlap );
        }
    }
}
