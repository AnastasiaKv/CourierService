using IdentityModule.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace IdentityModule.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("CourierServiceContext")
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
