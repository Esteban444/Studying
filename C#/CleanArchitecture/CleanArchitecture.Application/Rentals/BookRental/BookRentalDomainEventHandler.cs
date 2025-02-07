namespace CleanArchitecture.Application.Rentals.BookRental;

#region Usings
using CleanArchitecture.Application.Abstractions.Email;
using CleanArchitecture.Domain.Entities.Rentals.Events;
using CleanArchitecture.Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
#endregion

public sealed class BookRentalDomainEventHandler(IRentalsRepository rentalsRepository, IUsersRepository usersRepository,
                                     IEmailService emailService) : INotificationHandler<RentalReservedDomainEvents>
{
    private readonly IRentalsRepository _rentalsRepository = rentalsRepository;
    private readonly IUsersRepository _usersRepository = usersRepository;
    private readonly IEmailService _emailService = emailService;

    public async Task Handle( RentalReservedDomainEvents notification, CancellationToken cancellationToken )
    {
        var rental = await _rentalsRepository.GetRentalByIdAsync( notification.rentalId, cancellationToken );

        if (rental is null) { return; }

        var user = await _usersRepository.GetByIdAsync( rental.UserId, cancellationToken );

        if (user is null) { return; }

        await _emailService.SendAsync( user.Email, "Rental Book", "You must confirm your reservation" );
    }
}
