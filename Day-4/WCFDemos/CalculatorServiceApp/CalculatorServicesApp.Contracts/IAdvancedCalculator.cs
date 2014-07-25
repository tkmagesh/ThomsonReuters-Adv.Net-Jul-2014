using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace CalculatorServicesApp.Contracts
{
    [ServiceContract]
    public interface IAdvancedCalculator
    {
        [OperationContract]
        int Sign(int number);
    }
}
