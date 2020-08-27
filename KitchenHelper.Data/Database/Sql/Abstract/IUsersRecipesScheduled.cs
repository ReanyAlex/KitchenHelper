using System.Collections.Generic;
using System.Threading.Tasks;
using DbEntities = KitchenHelper.API.Data.Entities.DbEntities;
using ResourceParameters = KitchenHelper.API.Data.Entities.ResourceParameters;

namespace KitchenHelper.API.Data.Database.Sql.Abstract
{
    public interface IUsersRecipesScheduled
    {
        Task AddAsync(DbEntities.ScheduledRecipe entity);
        Task<IEnumerable<DbEntities.ScheduledRecipe>> GetAsync(DbEntities.ScheduledRecipe entity);
        Task<IEnumerable<DbEntities.ScheduledRecipe>> GetListAsync(int userId, ResourceParameters.ScheduledRecipes resourceParameters);
        Task<DbEntities.ScheduledRecipe> GetScheduleAsync(int scheduleId);
        void RemoveAsync(DbEntities.ScheduledRecipe entity);
        Task<bool> SaveAsync();
    }
}
