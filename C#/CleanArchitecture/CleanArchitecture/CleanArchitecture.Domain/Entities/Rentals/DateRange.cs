namespace CleanArchitecture.Domain.Entities.Rentals
{
    public sealed record DateRange
    {
        private DateRange( )
        {
            
        }

        public DateOnly StartDate {  get; init; } //DateOnly solo almacena la fecha sin horas.

        public DateOnly EndDate { get; init; }

        public int NumberOfDays => EndDate.DayNumber - StartDate.DayNumber;

        public static DateRange Create ( DateOnly startDate, DateOnly endDate )
        {
            if( startDate >  endDate )
            {
                throw new ApplicationException( "The start date is greater than the end date" );
            }

            return new DateRange 
            {
                StartDate = startDate,
                EndDate = endDate
            };
        }
    }
}
