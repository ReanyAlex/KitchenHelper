using Microsoft.Extensions.DependencyInjection;

namespace KitchenHelper.API.Configuration
{
    public static class ServicesConfiguration
    {
        public static void AddRecipeService(this IServiceCollection services)
        {
            services.AddScoped<Core.Abstract.IRecipes, Core.Concrete.Recipes>();
            services.AddScoped<Data.Database.Sql.Abstract.IRecipes, Data.Database.Sql.Concrete.Recipes>();
        }

        public static void AddIngredientService(this IServiceCollection services)
        {
            services.AddScoped<Core.Abstract.IIngredients, Core.Concrete.Ingredients>();
            services.AddScoped<Data.Database.Sql.Abstract.IIngredients, Data.Database.Sql.Concrete.Ingredients>();
        }

        public static void AddMeasurementService(this IServiceCollection services)
        {
            services.AddScoped<Core.Abstract.IMeasurements, Core.Concrete.Measurements>();
            services.AddScoped<Data.Database.Sql.Abstract.IMeasurements, Data.Database.Sql.Concrete.Measurements>();
        }

        public static void AddUsersRecipesService(this IServiceCollection services)
        {
            services.AddScoped<Core.Abstract.IUsersRecipes, Core.Concrete.UsersRecipes>();
            services.AddScoped<Data.Database.Sql.Abstract.IUsersRecipes, Data.Database.Sql.Concrete.UsersRecipes>();
        }

        public static void AddUserService(this IServiceCollection services)
        {
            services.AddScoped<Core.Abstract.IUsers, Core.Concrete.Users>();
            services.AddScoped<Data.Database.Sql.Abstract.IUsers, Data.Database.Sql.Concrete.Users>();
        }
    }
}



            

            