using DBModel.EntitiesConfig;
using IdentityModule.Context;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace DBModel.DbContexts
{
    public class CourierServiceContext: ApplicationDbContext
    {
        public CourierServiceContext()
        {
            Database.SetInitializer<CourierServiceContext>(null);
        }

        public System.Data.Entity.DbSet<DBModel.Entities.Order> Orders { get; set; }
        public System.Data.Entity.DbSet<DBModel.Entities.OrderItem> OrderItems { get; set; }
        public System.Data.Entity.DbSet<DBModel.Entities.LuggageType> LuggageTypes { get; set; }
        public System.Data.Entity.DbSet<DBModel.Entities.CourierTransportType> CourierTransportTypes { get; set; }
        public System.Data.Entity.DbSet<DBModel.Entities.Status> Status { get; set; }
        public System.Data.Entity.DbSet<DBModel.Entities.User> Users { get; set; }
        public System.Data.Entity.DbSet<DBModel.Entities.UserRole> UserRoles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new OrderEntityConfiguration());
            modelBuilder.Configurations.Add(new OrderItemEntityConfiguration());
            modelBuilder.Configurations.Add(new UserEntityConfiguration());
            modelBuilder.Configurations.Add(new LuggageTypeEntityConfiguration());

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            base.OnModelCreating(modelBuilder);

        }
    }
}
