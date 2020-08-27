using KitchenHelper.API.Data.Database.Sql.Abstract;
using KitchenHelper.API.Data.Entities.DbEntities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ResourceParameters = KitchenHelper.API.Data.Entities.ResourceParameters;

namespace KitchenHelper.API.Core.Concrete
{
    public class UsersRecipesScheduled : Abstract.IUsersRecipesScheduled
    {
        private readonly IUsersRecipesScheduled _dal;

        public UsersRecipesScheduled(IUsersRecipesScheduled dal)
        {
            _dal = dal ?? throw new ArgumentNullException(nameof(dal));
        }

        public async Task AddAsync(ScheduledRecipe entity)
        {
            await _dal.AddAsync(entity);
        }

        public async Task<IEnumerable<ScheduledRecipe>> GetAsync(ScheduledRecipe entity)
        {
            return await _dal.GetAsync(entity);
        }

        public async Task<IEnumerable<ScheduledRecipe>> GetListAsync(int userId, ResourceParameters.ScheduledRecipes resourceParameters)
        {
            return await _dal.GetListAsync(userId, resourceParameters);
        }

        public Task<ScheduledRecipe> GetScheduleAsync(int scheduleId)
        {
            throw new NotImplementedException();
        }

        public void RemoveAsync(ScheduledRecipe entity)
        {
            _dal.RemoveAsync(entity);
        }

        public async Task<bool> SaveAsync()
        {
            return await _dal.SaveAsync();
        }
    }
}
