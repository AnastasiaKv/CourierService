using DBModel.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModel.EntitiesConfig
{
    public class LuggageTypeEntityConfiguration : EntityTypeConfiguration<LuggageType>
    {
        public LuggageTypeEntityConfiguration()
        {
            this.HasMany<CourierTransportType>(p => p.CourierTransportTypes)
                .WithMany(s => s.LuggageTypes)
                .Map(ps =>
                {
                    ps.MapLeftKey("LuggageId");
                    ps.MapRightKey("CourierTransportId");
                    ps.ToTable("CourierLuggage");
                });
        }
    }
}
