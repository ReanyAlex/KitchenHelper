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
        public DbSet<UsersRecipe> UsersRecipes { get; set; }
        public DbSet<ScheduledRecipe> ScheduledRecipes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UsersRecipe>()
                .HasKey(r => new {r.UserId, r.RecipeId });

            modelBuilder.Entity<RecipeIngredientInformation>()
                .Property(r => r.Quantity).HasColumnType("decimal(16, 4)");

        }
    }
}
