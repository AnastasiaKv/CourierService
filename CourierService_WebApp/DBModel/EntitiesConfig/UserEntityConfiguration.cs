using DBModel.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModel.EntitiesConfig
{
    public class UserEntityConfiguration: EntityTypeConfiguration<User>
    {
        public UserEntityConfiguration()
        {
            this.HasRequired<UserRole>(p => p.UserRole)
                .WithMany(p => p.Users);
        }
    }
}
