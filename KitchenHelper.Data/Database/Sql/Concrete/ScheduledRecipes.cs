using KitchenHelper.API.Data.Database.Sql.Abstract;
using KitchenHelper.API.Data.Entities.DbEntities;
using KitchenHelper.API.Data.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KitchenHelper.API.Data.Database.Sql.Concrete
{
    public class ScheduledRecipes : IScheduledRecipes, IDisposable
    {

        private KitchenHelperDbContext _context;

        public ScheduledRecipes(KitchenHelperDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task AddAsync(ScheduledRecipe entity)
        {
            await _context.ScheduledRecipes.AddAsync(entity);
        }

        public async Task<ScheduledRecipe> GetAsync(ScheduledRecipe entity)
        {
            return await _context.ScheduledRecipes
                .Include(sr => sr.Recipe)
                .Where(r => r.RecipeId == entity.RecipeId)
                .Where(r => r.UserId == entity.UserId)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<ScheduledRecipe>> GetListAsync(int userId, Entities.ResourceParameters.ScheduledRecipes resourceParameters)
        {
            ParameterChecks.CheckResourceParameters(resourceParameters);

            var collection = _context.ScheduledRecipes.AsQueryable<ScheduledRecipe>()
                .Include(sr => sr.Recipe)
                .Where(sr => sr.UserId == userId)
                .Where(sr => sr.ScheduledDate > resourceParameters.StartDate.Date
                        && sr.ScheduledDate < resourceParameters.EndDate.Date);

            return await collection.ToListAsync();
        }

        public void RemoveAsync(ScheduledRecipe entity)
        {
            _context.ScheduledRecipes.Remove(entity);
        }

        public async Task<bool> SaveAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing && _context != null)
            {
                _context.Dispose();
                _context = null;
            }
        }
    }
}
