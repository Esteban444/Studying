namespace CleanArchitecture.Domain.Services;

#region Usings
using CleanArchitecture.Domain.Cars;
using CleanArchitecture.Domain.Entities.Rentals;
using CleanArchitecture.Domain.Shared;
#endregion

public class PricesService
{
    public PricesService()
    {
        
    }

    public DetailPrices CalculatedPrice ( Cars car , DateRanges dateRange)
    {
        var typeCurrency = car.Price!.currencyType;

        var price = new Currencies( dateRange.NumberOfDays* car.Price.Amount, typeCurrency);

        decimal percentageChange = 0;

        foreach ( var accesory in car.Accesories! )
        {
            percentageChange += accesory switch
            {
                Accesories.AppleCar or Accesories.AndroidCar => 0.05m,
                Accesories.AirConditioning => 0.01m,
                Accesories.Maps => 0.01m,
                _ =>  0
            };
        }

        var accesoriesCharges = Currencies.Zero(typeCurrency);

        if ( percentageChange > 0 )
        {
            accesoriesCharges = new Currencies( price.Amount* percentageChange, typeCurrency );
        }

        var totalPrice = Currencies.Zero();
        totalPrice += price;

        if( !car.Maintenance!.IsZero())
        {
            totalPrice += car.Maintenance;
        }

        totalPrice += accesoriesCharges;

        return new DetailPrices ( 
            price, 
            car.Maintenance, 
            accesoriesCharges,
            totalPrice
            );
    }
}
