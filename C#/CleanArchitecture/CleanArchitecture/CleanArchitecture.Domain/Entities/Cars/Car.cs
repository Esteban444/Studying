using CleanArchitecture.Domain.Abstractions;
using CleanArchitecture.Domain.Entities.Cars;

namespace CleanArchitecture.Domain.Cars;

public sealed class Car: Entity
{
    public Car(
        Guid id,
        Models models,
        Vins vin,
        Currency price,
        Currency maintenance,
        DateTime? lastRentalDate,
        List<Accesory> accesories,
        Address address
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

    public Address? Address { get; private set; }

    public Currency? Price { get; private set; }

    public Currency? Maintenance { get; private set;}

    public DateTime? LastRentalDate { get; internal set; }

    public List<Accesory>?  Accesories { get; private set;}
}