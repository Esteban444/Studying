namespace CleanArchitecture.Domain.Shared;

public record Currencies(decimal Amount, CurrencyTypes currencyType)
{
    public static Currencies operator +(Currencies first, Currencies secound)
    {
        if (first.currencyType != secound.currencyType)
        {
            throw new InvalidOperationException("The type of currency must be the same.");
        }

        return new Currencies(first.Amount + secound.Amount, first.currencyType);
    }


    public static Currencies Zero() => new(0, CurrencyTypes.None);

    public static Currencies Zero(CurrencyTypes CurrencyType) => new(0, CurrencyType);

    public bool IsZero() => this == Zero(currencyType);

}
