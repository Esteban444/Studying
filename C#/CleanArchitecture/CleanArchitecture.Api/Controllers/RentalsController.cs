using CleanArchitecture.Application.Rentals.BookRental;
using CleanArchitecture.Application.Rentals.SearchRental;
using CleanArchitecture.Dtos.Rentals;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Api.Controllers
{
    [Route("api/rentals")]
    [ApiController]
    public class RentalsController : ControllerBase
    {
        private readonly ISender sender;

        public RentalsController( ISender sender )
        {
            this.sender = sender;
        }

        [HttpGet("{rentalId}")]
        public async Task<IActionResult> SearchRentals( Guid rentalId, CancellationToken cancellationToken ) 
        {
            var query = new SearchRentalQuery( rentalId );

            var result = await sender.Send( query, cancellationToken );

            return result.IsSuccess ? Ok( result.Value ) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> AddRental( Guid rentalId, RentalRequest request, CancellationToken cancellationToken )
        {
            var rental = new BookRentalCommand( request.CarId, request.UserId, request.StartDate, request.EndDate );

            var result = await sender.Send( rental, cancellationToken );

            if ( !result.IsSuccess ) 
            {
                return BadRequest( result.Error );
            }

            return CreatedAtAction( nameof( SearchRentals), new { result.Value }, result.Value );
        }
    }
}
