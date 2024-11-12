namespace CleanArchitecture.Domain.Entities.Rentals;

public sealed record DateRanges
{
    private DateRanges( )
    {
        
    }

    public DateOnly StartDate {  get; init; } //DateOnly solo almacena la fecha sin horas.

    public DateOnly EndDate { get; init; }

    public int NumberOfDays => EndDate.DayNumber - StartDate.DayNumber;

    public static DateRanges Create ( DateOnly startDate, DateOnly endDate )
    {
        if( startDate >  endDate )
        {
            throw new ApplicationException( "The start date is greater than the end date" );
        }

        return new DateRanges 
        {
            StartDate = startDate,
            EndDate = endDate
        };
    }
}
