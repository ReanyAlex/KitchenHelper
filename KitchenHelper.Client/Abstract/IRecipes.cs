using KitchenHelper.API.Data.Entities.DbEntities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KitchenHelper.API.Core.Abstract
{
    public interface IRecipes
    {
        Task<IEnumerable<Recipe>> GetAll();
    }
}
