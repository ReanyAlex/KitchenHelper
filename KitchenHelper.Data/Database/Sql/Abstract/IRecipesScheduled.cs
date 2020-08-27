using System.Threading.Tasks;
using DbEntities = KitchenHelper.API.Data.Entities.DbEntities;

namespace KitchenHelper.API.Data.Database.Sql.Abstract
{
    public interface IRecipesScheduled
    {
        Task<DbEntities.ScheduledRecipe> GetAsync(int scheduledId);
        void RemoveAsync(DbEntities.ScheduledRecipe entity);
        Task<bool> SaveAsync();
    }
}
