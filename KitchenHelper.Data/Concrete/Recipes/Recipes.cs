using KitchenHelper.API.Data.Database;
using KitchenHelper.API.Data.Entities.DbEntities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KitchenHelper.API.Data.Concrete.Recipes
{
    public class Recipes : Abstract.Recipes.IRecipes
    {
        private readonly IRecipes _db;

        public Recipes(IRecipes db)
        {
            _db = db ?? throw new System.ArgumentNullException(nameof(db));
        }

        public async Task<IEnumerable<Recipe>> GetAll()
        {
            return await _db.GetAll();
        }
    }
}
