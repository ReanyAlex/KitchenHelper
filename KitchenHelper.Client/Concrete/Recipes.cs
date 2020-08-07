using KitchenHelper.API.Data.Entities.DbEntities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KitchenHelper.API.Core.Concrete
{
    public class Recipes : Abstract.IRecipes
    {
        private readonly Data.Abstract.Recipes.IRecipes _dal;

        public Recipes(Data.Abstract.Recipes.IRecipes dal)
        {
            _dal = dal ?? throw new System.ArgumentNullException(nameof(dal));
        }

        public async Task<IEnumerable<Recipe>> GetAll()
        {
            return await _dal.GetAll();
        }
    }
}
