namespace CleanArchitecture.Application.Cars.SearchCars;

using CleanArchitecture.Application.Abstractions.Data;

#region Usings
using CleanArchitecture.Application.Abstractions.Messaging;
using CleanArchitecture.Domain.Abstractions;
using CleanArchitecture.Domain.Entities.Rentals;
using Dapper;
#endregion

internal class SearchCarQueryHandler( ISqlConnectionFactory connectionFactory ) : IQueryHandler<SearchCarsQuery, IReadOnlyList<CarResponse>>
{
    private static readonly int[] ActiveRentalStatus =
    {
        (int)RentalStatus.Reserved,
        (int)RentalStatus.Confirmed,
        (int)RentalStatus.Completed
    };
    private readonly ISqlConnectionFactory _connectionFactory = connectionFactory;

    public async Task<Result<IReadOnlyList<CarResponse>>> Handle( SearchCarsQuery request, CancellationToken cancellationToken )
    {
        if ( request.StartDate > request.EndDate ) 
        { 
            return new List<CarResponse>(); 
        }

        using var connection = _connectionFactory.CreateConnection();

        //TODO: recordar asi deben quedar en bd ejm; userId
        const string  sql = """
           SELECT
              a.id as Id,
              a.model as Model,
              a.vin as Vin,
              a.price as Price,
              a.currencyType as CurrencyType,
              a.pais as Country,
              a.depaertment as Department,
              a.town as Town,
              a.city as City,
              a.street as Street

           FROM cars As a WHERE NOT EXISTS
           (
              SELECT 1 FROM rentals AS b
              WHERE 
                b.carId = a.id
                b.initDuration <= @EndDate AND
                b.endDuration >=n@StartDate AND
                b.status = ANY(@ActiveRentalStatus)

           )
         """;

        var cars = await connection.QueryAsync<CarResponse, AddresResponse, CarResponse>
            ( 
               sql,
               ( car, address ) =>
               {
                   car.Address = address;
                   return car;
               },
               new
               {
                   request.StartDate,
                   request.EndDate,
                   ActiveRentalStatus
               },
               splitOn: "Country"
            );

        return cars.ToList();
    }
}
