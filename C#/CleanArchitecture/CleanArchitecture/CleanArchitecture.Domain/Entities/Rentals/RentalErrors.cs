namespace CleanArchitecture.Domain.Entities.Rentals;

using CleanArchitecture.Domain.Abstractions;

public static class RentalErrors
{
    public static Error NotFound = new(
            "Rental.Found",
            "The rental with the specified id does not exist."
        );

    public static Error Overlap = new(
            "Rental.Overlap",
            "The vehicle was already rented on those dates."
        );

    public static Error NotReserved = new(
            "Rental.NotReserved",
            "The rental is not reserved."
        );

    public static Error NotConfirm = new(
            "Rental.NotConfirm",
            "The rental is not confirm."
        );

    public static Error AlreadyStarted = new(
            "Rental.AlreadyStarted",
            "Rental has already begun."
        );
}
