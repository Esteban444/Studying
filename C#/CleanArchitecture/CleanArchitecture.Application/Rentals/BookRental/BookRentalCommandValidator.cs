namespace CleanArchitecture.Application.Rentals.BookRental;

using FluentValidation;

public class BookRentalCommandValidator: AbstractValidator<BookRentalCommand>
{
    public BookRentalCommandValidator()
    {
        RuleFor( c => c.UserId ).NotEmpty();
        RuleFor ( c => c.CarId ).NotEmpty();
        RuleFor(c => c.InitDate).LessThan(c => c.EndDate );
    }
}
