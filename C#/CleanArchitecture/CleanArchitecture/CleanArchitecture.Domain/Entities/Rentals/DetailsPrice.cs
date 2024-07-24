using CleanArchitecture.Domain.Entities.Cars;

namespace CleanArchitecture.Domain.Entities.Rentals
{
    public record DetailsPrice
    (
        Currency Price,
        Currency Mantinance,
        Currency Accesories,
        Currency TotalPrice
    );
}
