using System;
using CalculatorWithUnitTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculatorUnitTests
{
    [TestClass]
    public class CalculatorTests
    {
        [TestMethod]
        public void Should_Be_Able_To_Add_Two_Numbers()
        {
            //Arrange
            var n1 = 10;
            var n2 = 20;
            var expectedResult = 30;
            var calculator = new Calculator();
            //Act

            var result = calculator.Add(n1, n2);

            //Assert
            Assert.AreEqual<int>(expectedResult, result);
        }
    }
}
