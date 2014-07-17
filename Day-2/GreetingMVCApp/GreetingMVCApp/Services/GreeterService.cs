using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GreetingMVCApp.Services
{
    public interface IGreeterService
    {
        string Greet(string name);
    }

    public class GreeterService : IGreeterService
    {
        private readonly ITimeService _timeService;

        public GreeterService(ITimeService timeService)
        {
            _timeService = timeService;
        }

        public string Greet(string name)
        {
            if (_timeService.GetCurrentTime().Hour < 12)
            {
                return string.Format("Hello {0}, Good Morning!!", name);
            }
            return string.Format("Hello {0}, Good Evening!!", name);
        }
    }
}