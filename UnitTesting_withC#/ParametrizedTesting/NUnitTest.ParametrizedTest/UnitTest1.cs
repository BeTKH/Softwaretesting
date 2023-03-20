using ParametrizedTest;

namespace NUnitTest.ParametrizedTest
{
    [TestFixture]
    public class ParamTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test] //Test Add method
        public void Add_whenCalled_ReturnTheSum()
        {
            MatH mathObj = new MatH();

            var resultSum = mathObj.Add(1,2);

            Assert.That(resultSum, Is.EqualTo(3));
        }

        [Test] // Test Sub Method
        public void Sub_WhenCalled_ReturnTheDiff() 
        {
            MatH mathObj = new MatH();

            var resultDiff = mathObj.Sub(1,2);

            Assert.That(resultDiff, Is.EqualTo(-1));
        }

        [Test] // Test Mul Method
        public void Mul_WhenCalled_ReturnTheProd() 
        {
            MatH mathObj = new MatH();

            var resultProd = mathObj.Mul(3,4);

            Assert.That(resultProd, Is.EqualTo(12));
        }


        [Test] // Test the Div method 

        public void Div_WhenCalled_ReturnTheQuot() 
        {
            MatH mathObj = new MatH();

            var resultQuot = mathObj.Div(3,4);

            Assert.That(resultQuot, Is.EqualTo(0.75));
            
        }
    }
}