using DBModel.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModel.Entities
{
    public class OrderItem: BaseEntity
    {
        public Guid OrderID{ get; set; }
        public Guid CourierID { get; set; }
        public Guid LuggageTypeID { get; set; }
        public Guid StatusID { get; set; }
        public string AddressFrom { get; set; }
        public string AddressTo { get; set; }
        public decimal Price { get; set; }

        public virtual User User { get; set; }
        public virtual Order Order { get; set; }
        public virtual Status Status { get; set; }
        public virtual LuggageType LuggageType { get; set; }
    }
}
