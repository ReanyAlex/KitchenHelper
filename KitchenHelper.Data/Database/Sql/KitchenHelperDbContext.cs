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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Recipe>().HasData(
                new Recipe()
                {
                    Id = 1,
                    Name = "Cup of Milk",
                    Description = "A nice cold glass of milk",
                    Category = "Test"
                },
                new Recipe()
                {
                    Id = 2,
                    Name = "Cup of Milk With Cookies",
                    Description = "A nice cold glass of milk with cookies",
                    Category = "Test"
                }
            );

            modelBuilder.Entity<RecipeStep>().HasData(
                new RecipeStep()
                {
                    Id = 1,
                    Order = 1,
                    Step = "Drink Milk",
                    RecipeId = 1
                },
                new RecipeStep()
                {
                    Id = 2,
                    Order = 1,
                    Step = "Drink Milk",
                    RecipeId = 2
                },
                new RecipeStep()
                {
                    Id = 3,
                    Order = 2,
                    Step = "Eat Cookie",
                    RecipeId = 2
                }
            );


            modelBuilder.Entity<RecipeIngredientInformation>().HasData(
                new RecipeIngredientInformation()
                {
                    Id = 1,
                    Quantity = 2,
                    MeasurementId = 1,
                    IngredientId = 1,
                    RecipeId = 1
                },
                new RecipeIngredientInformation()
                {
                    Id = 2,
                    Quantity = 2,
                    MeasurementId = 1,
                    IngredientId = 1,
                    RecipeId = 2
                },
                new RecipeIngredientInformation()
                {
                    Id = 3,
                    Quantity = 4,
                    MeasurementId = 2,
                    IngredientId = 2,
                    RecipeId = 2
                }
            );


            modelBuilder.Entity<Ingredient>().HasData(
                new Ingredient()
                {
                    Id = 1,
                    Name = "Milk",
                },
                new Ingredient()
                {
                    Id = 2,
                    Name = "Cookie",
                }
            );

            modelBuilder.Entity<Measurement>().HasData(
                new Measurement()
                {
                    Id = 1,
                    Name = "Cup",
                    ShortHand = "C",
                },
                new Measurement()
                {
                    Id = 2,
                    Name = "Each",
                    ShortHand = "Each",
                }
            );
        }
    }
}
