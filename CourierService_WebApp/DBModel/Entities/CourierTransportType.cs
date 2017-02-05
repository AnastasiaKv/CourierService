using DBModel.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModel.Entities
{
    public class CourierTransportType: BaseEntity
    {
        public string Name { get; set; }
        public string Capicity { get; set; }
        public string Description { get; set; }
        public virtual ICollection<LuggageType> LuggageTypes { get; set; }
    }
}
