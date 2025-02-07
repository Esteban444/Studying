namespace CleanArchitecture.Application.Rentals.SearchRental;

using CleanArchitecture.Application.Abstractions.Data;
using CleanArchitecture.Application.Abstractions.Messaging;
using CleanArchitecture.Domain.Abstractions;
using Dapper;

internal sealed class SearchRentalQueryHandler( ISqlConnectionFactory connectionFactory ) : IQueryHandler<SearchRentalQuery, RentalResponse>
{
    private readonly ISqlConnectionFactory _connectionFactory = connectionFactory;

    public async Task<Result<RentalResponse>> Handle( SearchRentalQuery request, CancellationToken cancellationToken )
    {
        using var connection = _connectionFactory.CreateConnection();
        //TODO: recordar asi deben quedar en bd ejm; userId
        var sql = """
           SELECT
              id AS Id,
              carId AS CarId,
              userId AS UserId,
              status As Status,
              rentalPrice AS RentalPrice,
              typeCurrencyRental AS TypeCurrencyRental,
              maintenancePrice AS MaintenancePrice,
              currencyTypeMaintenance AS CurencyTypeMaintenance,
              accesoriesPrice AS AccesoriesPrice,
              accesoriesCurrencyType AS AccesoriesCurrencyType,
              totalPrice AS TotalPrice,
              totalCurrencyType AS TotalCurrencyType,
              initDuration AS InitDuration,
              endDuration AS EndDuration,
              creation AS CrationDate

           FROM rentals WHERE id=@rentalId
         """;

        var rental = await  connection.QueryFirstOrDefaultAsync<RentalResponse>( sql, new { request.RentalId } );

        return rental!;
    }
}
