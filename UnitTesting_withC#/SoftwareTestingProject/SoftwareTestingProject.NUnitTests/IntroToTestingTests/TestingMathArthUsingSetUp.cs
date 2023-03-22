using SoftwareTestingProject.IntroToTesting;  // shows path to the loaction of the Class i.e. SoftwareTestingProject > IntroToTesting

namespace TestsNUnit.IntroToTestingTests
{
    [TestFixture]
    public class TestingMathArthUsingSetUp
    {

        private MathArth _math;

        [SetUp] // write re-usable components of susequent tests in the SetUp
        public void Setup()
        {
            // re-initialize for each test 
            _math = new MathArth();
        }

        [Test] //Test Add method
        public void Add_whenCalled_ReturnTheSum()
        {


            var resultSum = _math.Add(1, 2);

            Assert.That(resultSum, Is.EqualTo(3));
        }

        [Test] // Test Sub Method
        public void Sub_WhenCalled_ReturnTheDiff()
        {


            var resultDiff = _math.Sub(1, 2);

            Assert.That(resultDiff, Is.EqualTo(-1));
        }

        [Test] // Test Mul Method
        public void Mul_WhenCalled_ReturnTheProd()
        {


            var resultProd = _math.Mul(3, 4);

            Assert.That(resultProd, Is.EqualTo(12));
        }


        [Test] // Test the Div method 
        //[Ignore("I will comeback to this later!")] - to ignore test case  we can use [Ignore("ignore msg")]

        public void Div_WhenCalled_ReturnTheQuot()
        {


            var resultQuot = _math.Div(3, 4);

            Assert.That(resultQuot, Is.EqualTo(0.75));

        }




    }
}