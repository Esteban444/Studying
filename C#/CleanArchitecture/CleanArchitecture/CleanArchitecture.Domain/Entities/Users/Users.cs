using CleanArchitecture.Domain.Abstractions;
using CleanArchitecture.Domain.Entities.Users.Events;

namespace CleanArchitecture.Domain.Entities.Users
{
    public class Users: Entity
    {
        private Users(
            Guid id,
            Names name,
            LastNames lastName,
            Emails email
            ): base( id ) 
        { 
            this.Name = name;
            this.LastName = lastName;
            this.Email = email;  
        }

        public Names Name {  get; private set; }

        public LastNames LastName { get; private set; }

        public Emails Email { get; private set; }


        public static Users Create( 
            Names name,
            LastNames lastName,
            Emails email
            )
        {
            var user = new Users( Guid.NewGuid(), name, lastName, email);

            user.RaiseDomainEvent( new UserCreatedEvents( user.Id ) );// al momento que se cree un nuevo usuario se ejecutara este evento.

            return user;
        }
    }
}
