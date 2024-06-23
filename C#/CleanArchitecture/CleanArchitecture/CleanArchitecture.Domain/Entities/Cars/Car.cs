using System.Dynamic;

namespace CleanArchitecture.Domain.Cars;

public sealed class Car 
{
    public Guid Id { get; private set; }

    public string? Model { get; private set; }

    public string? Vin { get; private set; }

    public string? Address { get; private set; }

    public string? Department { get; private set; }

    public string? Province { get; private set; }

    public string? City { get; private set; }

    public string? Country { get; private set; }

    public decimal Price { get; private set; }

    public string? TypeCurrency { get; private set; }

    public decimal Maintenance { get; private set;}

    public string? MaintenanceTypeCurrency { get; private set; }

    public DateTime LastRentalDate { get; private set; }

    public List<Accesory>?  Accesories { get; private set;}
}