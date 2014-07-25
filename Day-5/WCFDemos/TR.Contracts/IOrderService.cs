using System.ServiceModel;

namespace TR.Contracts
{
    [ServiceContract]
    public interface IOrderService
    {
        [OperationContract(IsOneWay = true)]
        void Process(Order order);
    }
}