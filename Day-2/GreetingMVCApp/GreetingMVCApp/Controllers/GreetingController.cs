using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GreetingMVCApp.Services;

namespace GreetingMVCApp.Controllers
{
    public class GreetingController : Controller
    {
        private readonly ITimeService _timeService;
        private readonly IGreeterService _greetService;

        public GreetingController(ITimeService timeService, IGreeterService greetService)
        {
            _timeService = timeService;
            _greetService = greetService;
        }

        public GreetingController()
        {
            _timeService = new TimeService();
            _greetService = new GreeterService(_timeService);
        }

        public ViewResult GreetInput()
        {
            return View();
        }
        //
        // GET: /Greeting/

        public ViewResult Greet(string name)
        {
            var viewName = _timeService.GetCurrentTime().Hour < 12 ? "GreetMorning" : "GreetEvening";
            var message = _greetService.Greet(name);
            TempData["Message"] = message;
            return View(viewName);
        }

    }
}
