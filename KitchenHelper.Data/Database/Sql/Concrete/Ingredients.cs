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
    public class Ingredients : IIngredients, IDisposable
    {
        private KitchenHelperDbContext _context;

        public Ingredients(KitchenHelperDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task CreateAsync(Ingredient entity)
        {
            await _context.Ingredients.AddAsync(entity);
        }

        public async Task<Ingredient> GetAsync(int id)
        {
            return await _context.Ingredients
                .Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Ingredient>> GetListAsync(ResourceParameters.Ingredients resourceParameters)
        {
            ParameterChecks.CheckResourceParameters(resourceParameters);

            var collection = _context.Ingredients.AsQueryable<Ingredient>();

            if (!string.IsNullOrWhiteSpace(resourceParameters.SearchQuery))
                collection = collection.Where(i => i.Name.Contains(resourceParameters.SearchQuery.Trim()));

            if (!string.IsNullOrWhiteSpace(resourceParameters.OrderBy))
                collection = resourceParameters.SortAsc ? collection.OrderBy(i => i.Name) : collection.OrderByDescending(i => i.Name);

            return await collection.Skip((resourceParameters.PageNumber - 1) * resourceParameters.PageSize).Take(resourceParameters.PageSize).ToListAsync();
        }

        public void Update(Ingredient entity)
        {
            // No Implementation
        }

        public void Delete(Ingredient entity)
        {
            _context.Ingredients.Remove(entity);
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Ingredients
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
