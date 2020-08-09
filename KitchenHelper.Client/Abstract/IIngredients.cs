using KitchenHelper.API.Data.Entities.DbEntities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KitchenHelper.API.Core.Abstract
{
    public interface IIngredients
    {
        Task CreateAsync(Ingredient ingredient);

        Task<Ingredient> GetAsync(int ingredientId);
        Task<IEnumerable<Ingredient>> GetListAsync();

        void Update(Ingredient ingredient);

        void Delete(Ingredient ingredient);

        Task<bool> ExistsAsync(int ingredientId);

        Task<bool> SaveAsync();
    }
}
