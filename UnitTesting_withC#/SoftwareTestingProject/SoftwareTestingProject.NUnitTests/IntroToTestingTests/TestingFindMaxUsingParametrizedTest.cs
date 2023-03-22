using SoftwareTestingProject.IntroToTesting; // shows path to the loaction of the Class i.e. SoftwareTestingProject > IntroToTesting

namespace TestsNUnit.IntroToTestingTests
{
    [TestFixture]
    public class TestingFindMaxUsingParametrizedTest
    {

        private FindMax _max;

        [SetUp] // write re-usable components of susequent tests in the SetUp
        public void Setup()
        {
            // re-initialize for each test 
            _max = new FindMax();
        }



        [Test]
        [TestCase(2, 1, 2)]  // Parametrized testing case when a > b, result is a
        [TestCase(1, 3, 3)]  //Parametrized testing case when a < b, result is b
        [TestCase(3, 3, 3)]  // Parametrized testing case when a = b, result is a
        public void Max_WhenCalled_ReturnGreaterArge(int a, int b, int expectedResult)
        {
            var result = _max.Max(a, b);

            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}