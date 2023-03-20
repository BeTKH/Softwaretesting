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
        public void Max_SecondArgIsGreater_ReturnSecondArg() 
        {
            var result = _math.Max(1,2);

            Assert.That(result, Is.EqualTo(2));
        }


        [Test]
        public void Max_FirstrgIsGreater_ReturnFirstArg()
        {
            var result = _math.Max(3, 2);

            Assert.That(result, Is.EqualTo(3));
        }


        [Test]
        public void Max_ArgsAreEqual_ReturnFirst()
        {
            var result = _math.Max(3, 3);

            Assert.That(result, Is.EqualTo(3));
        }
    }
}