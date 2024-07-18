using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.unitTest
{
    [TestFixture]
    public class MathTests
    {
        private Math math;

        //SetUp
        // TearDown

        [SetUp] 
        public void SetUp() 
        { 
            math = new Math();
        }

        [TearDown]
        public void TearDown()
        {

        }

        [Test]
        //[Ignore("Because i wanted to!")] //como inorar una prueba
        public void Add_WhenCalled_ReturnTheSumOfArguments() 
        {
            //Arrange

            //Act
            var result = math.Add( 1, 2 );

            //Assert
            Assert.That( result, Is.EqualTo( 3 ) );
            //Assert.That( result, Is.Not.Null );
        }

        [Test]
        [TestCase ( 2,1, 2 ) ]
        [TestCase ( 1,2, 2 ) ]
        [TestCase ( 1,1, 1) ]
        public void Add_WhenCalled_ReturnTheGreaterArgument( int a, int b, int expectedResult)
        {
            //Arrange

            //Act
            var result = math.Max( a, b );

            //Assert
            Assert.That( result, Is.EqualTo( expectedResult ) );
        }

        [Test]
        public void GetOddNumbers_LimitIsGreaterThanZero_ReturnOddNumbersUpToLimit()
        {
            var result = math.GetOddNumbers( 5 );

            //Assert.That(result, Is.Not.Empty );
            //Assert.That ( result.Count(), Is.EqualTo( 3 ) );
            
            //Assert.That ( result, Does.Contain( 1 ) );
            //Assert.That ( result, Does.Contain( 3 ) );
            //Assert.That ( result, Does.Contain( 5 ) );

            Assert.That ( result, Is.EquivalentTo( new[] { 1,3,5 } ) );
            Assert.That( result, Is.Ordered );
            Assert.That( result, Is.Unique );
        }

        // con la creacion de Add_WhenCalled_ReturnTheGreaterArgument no seria necesario las pruebas comentadas.
        /*
        [Test]
        public void Max_FirstArgumentIsGreater_ReturnTheFirstArgument()
        {
            //Arrange

            //Act
            var result = math.Max( 2, 1 );

            //Assert
            Assert.That( result, Is.EqualTo( 2 )  ); 
        }

        [Test]
        public void Max_SecoundArgumentIsGreater_ReturnTheSecoundArgument()
        {
            //Arrange

            //Act
            var result = math.Max( 1, 2 );

            //Assert
            Assert.That( result, Is.EqualTo( 2 ) );
        }

        [Test]
        public void Max_ArgumentsAreEqual_ReturnSameArgument()
        {
            //Arrange

            //Act
            var result = math.Max( 1, 1 );

            //Assert
            Assert.That( result, Is.EqualTo( 1 ) );
        }*/

    }
}
