using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using KitchenHelper.API.Data.Database.Sql.Abstract;
using KitchenHelper.API.Data.Entities.DbEntities;

namespace KitchenHelper.API.Core.Concrete
{
    public class RecipesScheduled : Abstract.IRecipesScheduled
    {
        private readonly IRecipesScheduled _dal;

        public RecipesScheduled(IRecipesScheduled dal)
        {
            _dal = dal ?? throw new ArgumentNullException(nameof(dal));
        }

        public async Task<ScheduledRecipe> GetAsync(int scheduledId)
        {
            return await _dal.GetAsync(scheduledId);
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
