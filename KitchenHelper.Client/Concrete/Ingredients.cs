using KitchenHelper.API.Data.Database.Sql.Abstract;
using KitchenHelper.API.Data.Entities.DbEntities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KitchenHelper.API.Core.Concrete
{
    public class Ingredients : Abstract.IIngredients
    {
        private readonly IIngredients _dal;

        public Ingredients(IIngredients dal)
        {
            _dal = dal ?? throw new ArgumentNullException(nameof(dal));
        }

        public async Task CreateAsync(Ingredient ingredient)
        {
            await _dal.CreateAsync(ingredient);
        }

        public void Delete(Ingredient ingredient)
        {
            _dal.Delete(ingredient);
        }

        public async Task<bool> ExistsAsync(int ingredientId)
        {
            return await _dal.ExistsAsync(ingredientId);
        }

        public async Task<Ingredient> GetAsync(int ingredientId)
        {
            return await _dal.GetAsync(ingredientId);
        }

        public async Task<IEnumerable<Ingredient>> GetIngredientsAsync()
        {
            return await _dal.GetIngredientsAsync();
        }

        public async Task<bool> SaveAsync()
        {
            return await _dal.SaveAsync();
        }

        public void Update(Ingredient ingredient)
        {
            _dal.Update(ingredient);
        }
    }
}
