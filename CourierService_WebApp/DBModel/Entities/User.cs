using DBModel.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModel.Entities
{
    public class User: BaseEntity
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public Guid UserRoleID { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
        public virtual UserRole UserRole { get; set; }
    }
}
