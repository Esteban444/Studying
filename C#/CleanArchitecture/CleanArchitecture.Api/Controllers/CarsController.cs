namespace CleanArchitecture.Api.Controllers;

using CleanArchitecture.Application.Cars.SearchCars;
using MediatR;
using Microsoft.AspNetCore.Mvc;

[Route("api/cars")]
[ApiController]
public class CarsController : ControllerBase
{
    private readonly ISender sender;
    public CarsController( ISender sender )
    {
        this.sender = sender;
    }

    [HttpGet]
    public async Task<IActionResult> SearchCars( DateOnly startDate, DateOnly endDate, CancellationToken cancellationToken ) 
    {
        var query = new SearchCarsQuery( startDate, endDate );

        var results = await sender.Send( query, cancellationToken );

        return Ok( results.Value );
    }
}
