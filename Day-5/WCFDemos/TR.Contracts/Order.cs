using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace TR.Contracts
{
    [DataContract]
    public class Order
    {
        [DataMember]
        public IList<OrderItem> OrderItems;
    }
}