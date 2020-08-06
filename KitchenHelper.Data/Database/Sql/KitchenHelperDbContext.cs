using KitchenHelper.API.Data.Entities.DbEntities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

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
                });

            modelBuilder.Entity<RecipeStep>().HasData(
            new RecipeStep()
            {
                Id = 1,
                Order = 1,
                Step = "Drink Milk",
                RecipeId = 1
            });


            modelBuilder.Entity<RecipeIngredientInformation>().HasData(
            new RecipeIngredientInformation()
            {
                Id = 1,
                Quantity = 2,
                RecipeId = 1
            });


            modelBuilder.Entity<Ingredient>().HasData(
            new Ingredient()
            {
                Id = 1,
                Name = "Milk",
                RecipeIngredientInformationId = 1
            });

            modelBuilder.Entity<Measurement>().HasData(
            new Measurement()
            {
                Id = 1,
                Name = "Cup",
                ShortHand = "C",
                RecipeIngredientInformationId = 1
            });
        }
    }
}
