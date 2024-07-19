using CleanArchitecture.Domain.Abstractions;
using CleanArchitecture.Domain.Entities.Cars;

namespace CleanArchitecture.Domain.Cars;

public sealed class Car: Entity
{
    public Car( Guid id ): base( id )
    {
        
    }

    public Models? Model { get; private set; }

    public Vins? Vin { get; private set; }

    public Address Address { get; private set; }

    public decimal Price { get; private set; }

    public string? TypeCurrency { get; private set; }

    public decimal Maintenance { get; private set;}

    public string? MaintenanceTypeCurrency { get; private set; }

    public DateTime LastRentalDate { get; private set; }

    public List<Accesory>?  Accesories { get; private set;}
}