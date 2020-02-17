using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace MvcTest.Models
{
    public interface IContext
    {

        DbContextConfiguration Configuration { get; }

        IDbSet<IdentityRole> Roles { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        int SaveChanges();


    }
}
