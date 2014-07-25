using System;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace TR.Contracts
{
    [DataContract]
    public class OrderItem
    {
        [DataMember]
        public int ProductId { get; set; }

        [DataMember]
        public int Units { get; set; }

        [DataMember]
        public decimal Cost { get; set; }
    }
}
