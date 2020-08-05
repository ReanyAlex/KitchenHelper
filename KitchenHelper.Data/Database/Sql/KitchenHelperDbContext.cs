using KitchenHelper.API.Data.Entities.DbEntities;
using Microsoft.EntityFrameworkCore;

namespace KitchenHelper.API.Data.Database.Sql
{
    class KitchenHelperDbContext : DbContext
    {
        public KitchenHelperDbContext(DbContextOptions<KitchenHelperDbContext> options)
           : base(options)
        {
        }

        public DbSet<Recipe> Recipes { get; set; }
    }
}
