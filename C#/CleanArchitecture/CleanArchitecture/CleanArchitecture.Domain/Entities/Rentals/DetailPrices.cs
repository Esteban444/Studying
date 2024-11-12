using CleanArchitecture.Domain.Shared;

namespace CleanArchitecture.Domain.Entities.Rentals
{
    public record DetailPrices
    (
        Currencies Price,
        Currencies Mantinance,
        Currencies Accesories,
        Currencies TotalPrice
    );
}
