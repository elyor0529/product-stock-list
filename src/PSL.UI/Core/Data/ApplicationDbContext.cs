using Microsoft.AspNet.Identity.EntityFramework;
using PSL.UI.Core.Data.Entities;

namespace PSL.UI.Core.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}