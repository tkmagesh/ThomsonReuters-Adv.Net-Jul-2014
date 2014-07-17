using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GreetingApp;

namespace GreetingAppTests
{
    public class FakeTimeServiceForMorning : ITimeService
    {
        public DateTime GetCurrentTime()
        {
            return new DateTime(2014,7,17,9,0,0);
        }
    }

    public class FakeTimeServiceForEvening : ITimeService
    {
        public DateTime GetCurrentTime()
        {
            return new DateTime(2014, 7, 17, 19, 0, 0);
        }
    }

    [TestClass]
    public class GreeterTests
    {
        [TestMethod]
        public void Should_Say_Good_Morning_Before_12()
        {
            //Arrange
            var morningTimeService = new FakeTimeServiceForMorning();
            var greeter = new Greeter(morningTimeService);
            var name = "Magesh";
            string expectedResult = "Hello Magesh, Good Morning!";

            //Act
            var result = greeter.Greet(name);

            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void Should_Say_Good_Evening_After_12()
        {
            //Arrange
            var eveningTimeService = new FakeTimeServiceForEvening();
            var greeter = new Greeter(eveningTimeService);
            var name = "Magesh";
            string expectedResult = "Hello Magesh, Good Evening!";

            //Act
            var result = greeter.Greet(name);

            //Assert
            Assert.AreEqual(expectedResult, result);
        }
    }
}
