using DBModel.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModel.Entities
{
    public class Order: BaseEntity
    {
        public string Name { get; set; }
        public Guid ManagerID { get; set; }
        public Guid UserID { get; set; }
        public Guid StatusID { get; set; }
        public DateTime StartDataTime { get; set; }
        public DateTime FinishDataTime { get; set; }
        public DateTime ExpectedDataTime { get; set; }
        public decimal TotalPrice{ get; set; }
        public string Description { get; set; }

        public virtual User User { get; set; }
        public virtual Status Status { get; set; }
        public virtual ICollection<OrderItem> OrderItems{ get; set; }
    }
}
