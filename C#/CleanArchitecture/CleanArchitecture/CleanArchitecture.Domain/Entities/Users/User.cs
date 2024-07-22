using CleanArchitecture.Domain.Abstractions;
using CleanArchitecture.Domain.Entities.Users.Events;

namespace CleanArchitecture.Domain.Entities.Users
{
    public class User: Entity
    {
        private User(
            Guid id,
            Name name,
            LastName lastName,
            Email email
            ): base( id ) 
        { 
            this.Name = name;
            this.LastName = lastName;
            this.Email = email;  
        }

        public Name Name {  get; private set; }

        public LastName LastName { get; private set; }

        public Email Email { get; private set; }


        public static User Create( 
            Name name,
            LastName lastName,
            Email email
            )
        {
            var user = new User( Guid.NewGuid(), name, lastName, email);

            user.AddEvents( new UserCreatedEvents( user.Id ) );// al momento que se cree un nuevo usuario se ejecutara este evento.

            return user;
        }
    }
}
