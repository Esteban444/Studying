namespace CleanArchitecture.Domain.Abstractions
{
    public abstract class Entity
    {
        protected Entity(Guid id)
        {
            Id = id;
        }
        //el init es para que el objeto tenga un identificador de por vida y que no cambie
        public Guid Id { get; init; }
    }
}
