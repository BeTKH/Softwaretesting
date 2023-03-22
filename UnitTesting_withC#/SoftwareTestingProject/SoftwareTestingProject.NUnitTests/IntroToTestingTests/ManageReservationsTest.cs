using SoftwareTestingProject.IntroToTesting; // shows path to the loaction of the Class i.e. SoftwareTestingProject > IntroToTesting > ManageReservations.cs

namespace TestsNUnit.IntroToTestingTests  // shows path to the loaction of the Tests.Class i.e. TestsNUnit > IntroToTestingTests > ManageReservationsTests.cs
{
    public class ManageReservationsTests
    {
        [Test]
        public void CanBeCancelledBy_AdminCancelling_ReturnsTrue()
        {
            // Arrange
            var reservationObj = new ManageReservations();

            // Act
            var result = reservationObj.CanBeCancelledBy(new User { IsAdmin = true });

            // Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void CanBeCancelledBy_SameUserCancelling_ReturnTrue()
        {
            var user = new User();
            var reservationObj = new ManageReservations { MadeBy = user };

            var result = reservationObj.CanBeCancelledBy(user);

            Assert.IsTrue(result);
        }

        [Test]
        public void CanBeCancelledBy_AnotherUserCancelling_ReturnFalse()
        {
            var reservationObj = new ManageReservations { MadeBy = new User() };

            var result = reservationObj.CanBeCancelledBy(new User());

            Assert.IsFalse(result);
        }
    }
}