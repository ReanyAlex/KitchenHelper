using KitchenHelper.API.Data.Database.Sql.Abstract;
using KitchenHelper.API.Data.Entities.DbEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KitchenHelper.API.Data.Database.Sql.Concrete
{
    public class Recipes : IRecipes, IDisposable 
    {
        private KitchenHelperDbContext _context;

        public Recipes(KitchenHelperDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Recipe>> GetAll()
        {
            return await _context.Recipes
                            .Include(r => r.Ingredients)
                               .ThenInclude(i => i.Measurement)
                              .Include(r => r.Ingredients)
                               .ThenInclude(i => i.Ingredient)
                            .Include(r => r.RecipeSteps)
                            .ToListAsync();
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
