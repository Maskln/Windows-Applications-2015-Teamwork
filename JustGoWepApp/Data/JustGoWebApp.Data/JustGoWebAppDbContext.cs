namespace JustGoWebApp.Data
{
    using System.Data.Entity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;

    public class JustGoWebAppDbContext : IdentityDbContext<User>, IJustGoWebAppDbContext
    {
        public JustGoWebAppDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        
        public static JustGoWebAppDbContext Create()
        {
            return new JustGoWebAppDbContext();
        }
    }
}
