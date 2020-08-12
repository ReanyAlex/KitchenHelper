using KitchenHelper.API.Data.Entities.DbEntities;
using Microsoft.EntityFrameworkCore;

namespace KitchenHelper.API.Data.Database.Sql
{
    public class KitchenHelperDbContext : DbContext
    {
        public KitchenHelperDbContext(DbContextOptions<KitchenHelperDbContext> options)
           : base(options)
        {
        }

        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Measurement> Measurements { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
