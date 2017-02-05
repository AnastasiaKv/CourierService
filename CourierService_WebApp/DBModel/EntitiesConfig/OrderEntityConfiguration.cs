using DBModel.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModel.EntitiesConfig
{
    public class OrderEntityConfiguration: EntityTypeConfiguration<Order>
    {
        public OrderEntityConfiguration()
        {
            this.HasMany<OrderItem>(p => p.OrderItems)
                .WithRequired(p => p.Order);

            this.HasRequired<Status>(p => p.Status)
                .WithMany(p => p.Orders).WillCascadeOnDelete(false);

            this.HasRequired<User>(p => p.User)
                .WithMany(p => p.Orders);
        }
    }
}
