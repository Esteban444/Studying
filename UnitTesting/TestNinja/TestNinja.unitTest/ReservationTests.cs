using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.unitTest
{
    //[TestClass] // pruebas con visual MStest
    [TestFixture]
    public class ReservationTests
    {
        //[TestMethod] pruebas con Mstest
        /* Al cambiar de MSTest a NUnit se genera un error en Assert y es porque el compilador no sabe de donde usar la
         * clase Assert se remueve using Microsoft.VisualStudio.TestTools.UnitTesting;, para solucionar. */

        [Test]
        public void CanBeCancelledBy_UserIsAdmin_ReturnsTrue()
        {
            //Arrange
            var reservation = new Reservation();


            //Act
            var result  = reservation.CanBeCancelledBy( new User { IsAdmin = true });

            //Assert
            Assert.That( result, Is.True );
            //Assert.IsTrue( result ); con Mstest

        }

        [Test]
        public void CanBeCancelledBy_SameUserCancellingTheReservation_ReturnTrue()
        {
            //Arrange
            var user = new User ();
            var reservation = new Reservation { MadeBy = user };

            //Act
            var result = reservation.CanBeCancelledBy( user );

            //Assert
            Assert.That(result, Is.True);

        }

        [Test]
        public void CanBeCancelledBy_AnotherUserCancellingReservation_ReturnFalse ()
        {
            //Arrange
            var reservation = new Reservation { MadeBy = new User() };

            //Act
            var result = reservation.CanBeCancelledBy( new User() );

            //Assert
            Assert.That(result, Is.False);

        }
    }
}
