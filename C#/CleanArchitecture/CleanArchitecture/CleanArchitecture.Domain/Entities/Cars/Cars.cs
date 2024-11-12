namespace CleanArchitecture.Domain.Cars;

using CleanArchitecture.Domain.Abstractions;
using CleanArchitecture.Domain.Entities.Cars;
using CleanArchitecture.Domain.Shared;

public sealed class Cars: Entity
{
    public Cars(
        Guid id,
        Models models,
        Vins vin,
        Currencies price,
        Currencies maintenance,
        DateTime? lastRentalDate,
        List<Accesories> accesories,
        Addresses address
        ) : base( id )
    {
        Model = models;
        Vin = vin;
        Price = price;
        Maintenance = maintenance;
        LastRentalDate = lastRentalDate;
        Accesories = accesories;
        Address = address;

    }

    public Models? Model { get; private set; }

    public Vins? Vin { get; private set; }

    public Addresses? Address { get; private set; }

    public Currencies? Price { get; private set; }

    public Currencies? Maintenance { get; private set;}

    public DateTime? LastRentalDate { get; internal set; }

    public List<Accesories>?  Accesories { get; private set;}
}