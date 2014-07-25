using System;
using System.ServiceModel;
using CalculatorServicesApp.Contracts;

namespace CalculatorServicesApp.Services
{
    [ServiceBehavior]
    public class Calculator : ICalculator, IAdvancedCalculator
    {
        [OperationBehavior]
        public int Add(int number1, int number2)
        {
            return number1 + number2;
        }

        [OperationBehavior]
        public int Subtract(int number1, int number2)
        {
            return number1 - number2;
        }

        [OperationBehavior]
        public int Divide(int number1, int number2)
        {
            return number1 / number2;
        }

        [OperationBehavior]
        public int Multiply(int number1, int number2)
        {
            return number1 * number2;
        }

        [OperationBehavior]
        public int Mod(int number1, int number2)
        {
            return number1%number2;
        }

        [OperationBehavior]
        public int Sign(int number)
        {
            return Math.Sign(number);
        }
    }
}