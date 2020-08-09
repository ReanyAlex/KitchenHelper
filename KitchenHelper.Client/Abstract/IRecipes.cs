using KitchenHelper.API.Data.Entities.DbEntities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KitchenHelper.API.Core.Abstract
{
    public interface IRecipes
    {
        Task CreateAsync(Recipe recipe);

        Task<Recipe> GetAsync(int recipeId);
        Task<IEnumerable<Recipe>> GetListAsync();

        void Update(Recipe recipe);

        void Delete(Recipe recipe);

        Task<bool> ExistsAsync(int recipeId);

        Task<bool> SaveAsync();
    }
}
