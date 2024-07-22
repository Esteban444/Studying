namespace CleanArchitecture.Domain.Abstractions
{
    public abstract class Entity
    {
        private readonly List<IDomainEvent> events = new();
        protected Entity(Guid id)
        {
            Id = id;
        }
        //el init es para que el objeto tenga un identificador de por vida y que no cambie
        public Guid Id { get; init; }

        public IReadOnlyList<IDomainEvent> GetDomainEvents()
        {
            return events.ToList();
        }

        public void ClearEvents()
        {
            events.Clear();
        }

        protected void AddEvents( IDomainEvent domainEvents )
        {
            events.Add( domainEvents );
        }
    }
}
