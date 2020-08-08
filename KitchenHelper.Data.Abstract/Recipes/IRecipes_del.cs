using KitchenHelper.API.Data.Entities.DbEntities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KitchenHelper.API.Data.Abstract.Recipes
{
    public interface IRecipes
    {
        Task<IEnumerable<Recipe>> GetAll();
    }
}
