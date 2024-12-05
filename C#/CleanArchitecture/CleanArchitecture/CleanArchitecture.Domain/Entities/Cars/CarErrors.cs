namespace CleanArchitecture.Domain.Entities.Cars;

using CleanArchitecture.Domain.Abstractions;

public static class CarErrors
{
    public static Error NotFound = new( "Car.NotFound", "The car does not exist.");

}
