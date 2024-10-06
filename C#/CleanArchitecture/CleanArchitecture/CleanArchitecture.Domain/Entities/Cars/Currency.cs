namespace CleanArchitecture.Domain.Entities.Cars;

public record Currency( decimal Amount, CurrencyType currencyType )
{
    public static Currency operator +( Currency first, Currency secound ) 
    { 
        if ( first.currencyType != secound.currencyType )
        {
            throw new InvalidOperationException("The type of currency must be the same.");
        }

        return new Currency( first.Amount + secound.Amount , first.currencyType );
    }


    public static Currency Zero () => new( 0 , CurrencyType.None  );

    public static Currency Zero( CurrencyType CurrencyType ) => new ( 0, CurrencyType );

    public bool IsZero() => this == Zero( currencyType );

}
