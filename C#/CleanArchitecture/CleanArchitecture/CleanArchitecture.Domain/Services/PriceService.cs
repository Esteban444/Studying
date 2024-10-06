namespace CleanArchitecture.Domain.Services;

#region Usings
using CleanArchitecture.Domain.Cars;
using CleanArchitecture.Domain.Entities.Cars;
using CleanArchitecture.Domain.Entities.Rentals;
#endregion

public class PriceService
{
    public PriceService()
    {
        
    }

    public DetailsPrice CalculatedPrice ( Car car , DateRange dateRange)
    {
        var typeCurrency = car.Price!.currencyType;

        var price = new Currency( dateRange.NumberOfDays* car.Price.Amount, typeCurrency);

        decimal percentageChange = 0;

        foreach ( var accesory in car.Accesories! )
        {
            percentageChange += accesory switch
            {
                Accesory.AppleCar or Accesory.AndroidCar => 0.05m,
                Accesory.AirConditioning => 0.01m,
                Accesory.Maps => 0.01m,
                _ =>  0
            };
        }

        var accesoriesCharges = Currency.Zero(typeCurrency);

        if ( percentageChange > 0 )
        {
            accesoriesCharges = new Currency( price.Amount* percentageChange, typeCurrency );
        }

        var totalPrice = Currency.Zero();
        totalPrice += price;

        if( !car.Maintenance!.IsZero())
        {
            totalPrice += car.Maintenance;
        }

        totalPrice += accesoriesCharges;

        return new DetailsPrice ( 
            price, 
            car.Maintenance, 
            accesoriesCharges,
            totalPrice
            );
    }
}
