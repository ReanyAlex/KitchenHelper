using KitchenHelper.API.Data.Entities.DbEntities;
using System.Collections.Generic;
using System.Threading.Tasks;
using ResourceParameters = KitchenHelper.API.Data.Entities.ResourceParameters;

namespace KitchenHelper.API.Core.Abstract
{
    public interface IRecipes
    {
        Task CreateAsync(Recipe recipe);

        Task<Recipe> GetAsync(int recipeId);
        Task<IEnumerable<Recipe>> GetListAsync(ResourceParameters.Recipes recipesResourceParameters);

        void Update(Recipe recipe);

        void Delete(Recipe recipe);

        Task<bool> ExistsAsync(int recipeId);

        Task<bool> SaveAsync();
    }
}
