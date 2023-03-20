using ParametrizedTest;

namespace NUnitTest.ParametrizedTest
{
    [TestFixture]
    public class ParamTests
    {

        private MatH _math;

        [SetUp] // write re-usable components of susequent tests in the SetUp
        public void Setup()
        {   
            // re-initialize for each test 
            _math= new MatH();
        }

        [Test] //Test Add method
        public void Add_whenCalled_ReturnTheSum()
        {
           

            var resultSum = _math.Add(1,2);

            Assert.That(resultSum, Is.EqualTo(3));
        }

        [Test] // Test Sub Method
        public void Sub_WhenCalled_ReturnTheDiff() 
        {
           

            var resultDiff = _math.Sub(1,2);

            Assert.That(resultDiff, Is.EqualTo(-1));
        }

        [Test] // Test Mul Method
        public void Mul_WhenCalled_ReturnTheProd() 
        {
            

            var resultProd = _math.Mul(3,4);

            Assert.That(resultProd, Is.EqualTo(12));
        }


        [Test] // Test the Div method 

        public void Div_WhenCalled_ReturnTheQuot() 
        {
            

            var resultQuot = _math.Div(3,4);

            Assert.That(resultQuot, Is.EqualTo(0.75));
            
        }



        [Test]
        [TestCase(2,1,1)]  // Parametrized testing
        [TestCase(1,2,2)]
        [TestCase(2,2,2)]
        public void Max_WhenCalled_ReturnGreaterArge(int a, int b, int expectedResult) 
        {
            var result = _math.Max(a,b);

            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}