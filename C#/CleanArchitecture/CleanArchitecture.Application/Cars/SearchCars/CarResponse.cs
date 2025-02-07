namespace CleanArchitecture.Application.Cars.SearchCars
{
    public sealed class CarResponse
    {
        public Guid Id { get; init; }

        public string? Model { get; init; }

        public string? Vin { get; init; }

        public decimal Price { get; init; }

        public string? CurrencyType {  get; init; }

        public AddresResponse? Address { get; set; }
    }
}
