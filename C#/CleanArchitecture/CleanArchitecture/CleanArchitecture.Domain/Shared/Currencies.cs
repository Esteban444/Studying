namespace CleanArchitecture.Domain.Shared;

public record Currencies( decimal Amount, CurrencyTypes CurrencyType )
{
    public static Currencies operator +( Currencies first, Currencies secound )
    {
        if ( first.CurrencyType != secound.CurrencyType )
        {
            throw new InvalidOperationException( "The type of currency must be the same." );
        }

        return new Currencies( first.Amount + secound.Amount, first.CurrencyType );
    }


    public static Currencies Zero() => new( 0, CurrencyTypes.None );

    public static Currencies Zero( CurrencyTypes CurrencyType ) => new( 0, CurrencyType );

    public bool IsZero() => this == Zero( CurrencyType );

}
