using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TestNinja.Fundamentals;

namespace TestNonja.UnitTests
{
    [TestClass]
    public class ReservationTests
    {
        [TestMethod]
        public void CanBeCancelledBy_UserIsAdmin_ReturnsTrue()
        {
            // Triple A - arrange, act, assert

            // arrange - create a reservation object
            
            var reservation = new Reservation();

            // act -- where we act on this object like calling a method
            var result = reservation.CanBeCancelledBy(new User { IsAdmin = true});

            // assert
            Assert.IsTrue(result);
        }


        [TestMethod]
        public void CanBeCancelledBy_SameUserCancellingTheReservation_ReturnsTrue()
        {
            // arrange
            var user = new User();
            var reservation = new Reservation { MadeBy = user};

            //act
            var result = reservation.CanBeCancelledBy(user);

            //assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CanBeCancelledBy_othercases_ReturnsFalse()
        {
            // arrange
            
            var reservation = new Reservation { MadeBy = new User()};  // reservation made by a user

            //act
            var result = reservation.CanBeCancelledBy(new User());     // cancellation made by yet another user

            //assert
            Assert.IsFalse(result);
        }



    }
}
