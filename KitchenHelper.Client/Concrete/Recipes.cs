using KitchenHelper.API.Data.Entities.DbEntities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KitchenHelper.API.Core.Concrete
{
    public class Recipes : Abstract.IRecipes
    {
        private readonly Data.Database.Sql.Abstract.IRecipes _dal;

        public Recipes(Data.Database.Sql.Abstract.IRecipes dal)
        {
            _dal = dal ?? throw new System.ArgumentNullException(nameof(dal));
        }

        public async Task CreateAsync(Recipe recipe)
        {
            await _dal.CreateAsync(recipe);
        }

        public void Delete(Recipe recipe)
        {
            _dal.Delete(recipe);
        }

        public async Task<bool> ExistsAsync(int recipeId)
        {
            return await _dal.ExistsAsync(recipeId);
        }

        public async Task<Recipe> GetAsync(int recipeId)
        {
            return await _dal.GetAsync(recipeId);
        }

        public async Task<IEnumerable<Recipe>> GetListAsync()
        {
            return await _dal.GetListAsync();
        }

        public async Task<bool> SaveAsync()
        {
            return await _dal.SaveAsync();
        }

        public void Update(Recipe recipe)
        {
            _dal.Update(recipe);
        }
    }
}
