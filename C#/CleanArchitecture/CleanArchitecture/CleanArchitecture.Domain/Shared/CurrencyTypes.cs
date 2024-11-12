namespace CleanArchitecture.Domain.Shared;

public record CurrencyTypes
{
    public static readonly CurrencyTypes None = new("");

    public static readonly CurrencyTypes Usd = new("USD");

    public static readonly CurrencyTypes Eur = new("EUR");
    private CurrencyTypes(string code) => Code = code;

    public string Code { get; init; }

    public static readonly IReadOnlyCollection<CurrencyTypes> All = new[]
    {
        Usd, Eur
    };

    public static CurrencyTypes FromCode(string code)
    {
        return All.FirstOrDefault(c => c.Code == code) ??
            throw new ApplicationException("Type currency invalit");
    }
}
