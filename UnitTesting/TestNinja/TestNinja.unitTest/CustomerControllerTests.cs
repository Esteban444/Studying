using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.unitTest
{
    [TestFixture]
    public class CustomerControllerTests
    {
        [Test]
        public void GetCustomer_IdIsZero_ReturnNotFound()
        {
            var customer = new CustomerController();

            var result = customer.GetCustomer(0);

            //NotFound object
            Assert.That(result, Is.TypeOf<NotFound>() );

            //NotFound object or one of its derivatives
            Assert.That ( result, Is.InstanceOf<NotFound>() );
        }

        [Test]
        public void GetCustomer_IdIsNotZero_ReturnOk()
        {
            var customer = new CustomerController();

            var result = customer.GetCustomer(1);

            Assert.That(result, Is.TypeOf<Ok>() );
        }
    }
}
