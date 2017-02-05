using DBModel.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModel.Entities
{
    public class LuggageType:BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<CourierTransportType> CourierTransportTypes { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }

    }
}
