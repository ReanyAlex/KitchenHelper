using KitchenHelper.API.Data.Entities.DbEntities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KitchenHelper.API.Data.Database.Sql.Abstract
{
    public interface IRecipes
    {
        Task<IEnumerable<Recipe>> GetAll();
    }
}
