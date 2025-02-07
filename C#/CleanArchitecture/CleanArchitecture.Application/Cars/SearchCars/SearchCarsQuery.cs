using CleanArchitecture.Application.Abstractions.Messaging;

namespace CleanArchitecture.Application.Cars.SearchCars;

public sealed record SearchCarsQuery( DateOnly StartDate, DateOnly EndDate ): IQuery<IReadOnlyList<CarResponse>>
{
}
