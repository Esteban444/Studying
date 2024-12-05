namespace CleanArchitecture.Application.Rentals.BookRental;

using CleanArchitecture.Application.Abstractions.Messaging;
using CleanArchitecture.Domain.Abstractions;
using CleanArchitecture.Domain.Entities.Cars;
using CleanArchitecture.Domain.Entities.Rentals;
using CleanArchitecture.Domain.Entities.Users;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Domain.Services;

internal sealed class BookRentalCommandHandler : ICommandHandler<BookRentalCommand, Guid>
{
    private readonly IUsersRepository usersRepository;
    private readonly ICarsRepository carsRepository;
    private readonly IRentalsRepository rentalsRepository;
    private readonly PricesService priceService;
    private readonly IUnitOfWork unitOfWork;

    public BookRentalCommandHandler( IUsersRepository usersRepository, ICarsRepository carsRepository, 
                                     IRentalsRepository rentalsRepository, PricesService priceService, 
                                     IUnitOfWork unitOfWork)
    {
        this.usersRepository = usersRepository;
        this.carsRepository = carsRepository;
        this.rentalsRepository = rentalsRepository;
        this.priceService = priceService;
        this.unitOfWork = unitOfWork;
    }

    public async Task<Result<Guid>> Handle( BookRentalCommand request, CancellationToken cancellationToken )
    {
        var user = await usersRepository.GetByIdAsync( request.UserId , cancellationToken );

        if (user == null) 
        { 
            return Result.Failure<Guid>( UserErrors.NotFound );
        }

        var car = await carsRepository.GetByIdAsync ( request.CarId , cancellationToken );

        if (car is null)
        {
            return Result.Failure<Guid>( CarErrors.NotFound );
        }

        var duration = DateRanges.Create(request.InitDate, request.EndDate);

        if (await rentalsRepository.IsOverlappingAsync(car, duration, cancellationToken) ) 
        {
            return Result.Failure<Guid>(RentalErrors.Overlap);
        }

        var rental = Rentals.Reserva( car, user.Id, duration, DateTime.UtcNow, priceService ); 

        await rentalsRepository.AddRentalAsync( rental );

        await unitOfWork.SaveChangesAsync( cancellationToken );

        return rental.Id;
    }
}
