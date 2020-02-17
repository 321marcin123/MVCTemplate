namespace MvcTest.Models
{
    using System.Data.Entity;

    using Microsoft.AspNet.Identity.EntityFramework;

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IContext
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        //Add your model here
        // public DbSet<Event> Events { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }


    }
}