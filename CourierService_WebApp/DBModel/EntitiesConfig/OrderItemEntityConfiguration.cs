using DBModel.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModel.EntitiesConfig
{
    public class OrderItemEntityConfiguration: EntityTypeConfiguration<OrderItem>
    {
        public OrderItemEntityConfiguration()
        {
            this.HasRequired<LuggageType>(p => p.LuggageType)
                .WithMany(p => p.OrderItems);

            this.HasRequired<Status>(p => p.Status)
                .WithMany(p => p.OrderItems);

            this.HasRequired<User>(p => p.User)
                .WithMany(p => p.OrderItems);
        }
    }
}
