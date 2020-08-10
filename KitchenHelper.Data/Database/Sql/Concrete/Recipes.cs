using KitchenHelper.API.Data.Database.Sql.Abstract;
using KitchenHelper.API.Data.Entities.DbEntities;
using KitchenHelper.API.Data.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ResourceParameters = KitchenHelper.API.Data.Entities.ResourceParameters;

namespace KitchenHelper.API.Data.Database.Sql.Concrete
{
    public class Recipes : IRecipes, IDisposable 
    {
        private KitchenHelperDbContext _context;

        public Recipes(KitchenHelperDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task CreateAsync(Recipe entity)
        {
            await _context.Recipes.AddAsync(entity);
        }

        public async Task<Recipe> GetAsync(int id)
        {
            return await _context.Recipes
                            .Include(r => r.Ingredients)
                               .ThenInclude(i => i.Measurement)
                              .Include(r => r.Ingredients)
                               .ThenInclude(i => i.Ingredient)
                            .Include(r => r.RecipeSteps)
                            .Where(i => i.Id == id)
                            .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Recipe>> GetListAsync(ResourceParameters.Recipes resourceParameters)
        {
            ParameterChecks.CheckResourceParameters(resourceParameters);

            var collection = _context.Recipes.AsQueryable<Recipe>();

            collection = collection.Include(r => r.Ingredients)
                                       .ThenInclude(i => i.Measurement)
                                      .Include(r => r.Ingredients)
                                       .ThenInclude(i => i.Ingredient)
                                    .Include(r => r.RecipeSteps);

            if (!string.IsNullOrWhiteSpace(resourceParameters.SearchQuery))
                collection = collection.Where(i => i.Name.Contains(resourceParameters.SearchQuery.Trim()));
                           
            if (!string.IsNullOrWhiteSpace(resourceParameters.OrderBy))
                collection = resourceParameters.SortAsc ? collection.OrderBy(i => i.Name) : collection.OrderByDescending(i => i.Name);

            return await collection.Skip((resourceParameters.PageNumber - 1) * resourceParameters.PageSize).Take(resourceParameters.PageSize).ToListAsync();
        }
    
        public void Update(Recipe entity)
        {
            // No Implementation
        }

        public void Delete(Recipe entity)
        {
            _context.Recipes.Remove(entity);
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Recipes
                .AnyAsync(i => i.Id == id);
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
