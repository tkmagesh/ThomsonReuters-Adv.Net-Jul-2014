using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GreetingMVCApp.Controllers;

namespace GreetingMVCApp.Tests
{
    [TestClass]
    public class GreetingControllerTests
    {
        [TestMethod]
        public void When_Index_Invoked_With_Name_Before_12_MorningView_Is_Returned()
        {
            var controller = new GreetingController();

            var viewResult = controller.Index("Magesh");

            var resultMsg = viewResult.TempData["Message"];
            Assert.AreEqual("Hello Magesh, Welcome to ASP.NET MVC!", resultMsg);
        }
    }
}
