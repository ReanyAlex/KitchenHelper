using System;
using System.Linq;
using System.Threading.Tasks;
using KitchenHelper.API.Data.Database.Sql.Abstract;
using KitchenHelper.API.Data.Entities.DbEntities;
using Microsoft.EntityFrameworkCore;

namespace KitchenHelper.API.Data.Database.Sql.Concrete
{
    public class RecipesScheduled : IRecipesScheduled, IDisposable
    {
        private KitchenHelperDbContext _context;

        public RecipesScheduled(KitchenHelperDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<ScheduledRecipe> GetAsync(int scheduledId)
        {
            return await _context.ScheduledRecipes
                .Where(sr => sr.Id == scheduledId)
                .FirstOrDefaultAsync();
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
