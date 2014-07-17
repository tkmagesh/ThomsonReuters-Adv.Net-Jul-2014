using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GreetingMVCApp.Controllers
{
    public class GreetingController : Controller
    {
        public ViewResult GreetInput()
        {
            return View();
        }
        //
        // GET: /Greeting/

        public ViewResult Index(string name)
        {
            var message = string.Format("Hello {0}, Welcome to ASP.NET MVC!", name);
            /*
            var tempData = new TempDataDictionary();
            tempData.Add("Message", message);

            return new ViewResult {
                ViewName = "Index", 
                TempData = tempData
            };
             */
            TempData["Message"] = message;
            return View("Index");
        }

    }
}
