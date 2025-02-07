namespace CleanArchitecture.Application.Rentals.SearchRental;

public sealed class RentalResponse
{
    public Guid  Id { get; init; }

    public Guid UserId { get; init; }

    public Guid CarId { get; init; }

    public decimal RentalPrice { get; init; }

    public string? TypeCurrencyRental { get; init; }

    public decimal MaintenancePrice { get; init; }

    public string? CurencyTypeMaintenance { get; init; }

    public decimal AccesoriesPrice { get; init; }

    public string? AccesoriesCurrencyType {  get; init; }

    public decimal TotalPrice { get; init; }

    public string? TotalCurrencyType { get; init ; }

    public DateOnly InitDuration { get; init; }

    public DateOnly EndDuration { get; init; }

    public DateTime CrationDate { get; init; }
}
