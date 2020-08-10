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
    public class Measurements : IMeasurements, IDisposable
    {
        private KitchenHelperDbContext _context;

        public Measurements(KitchenHelperDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task CreateAsync(Measurement entity)
        {
            await _context.Measurements.AddAsync(entity);
        }

        public async Task<Measurement> GetAsync(int id)
        {
            return await _context.Measurements
                .Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Measurement>> GetListAsync(ResourceParameters.Measurements resourceParameters)
        {
            ParameterChecks.CheckResourceParameters(resourceParameters);

            var collection = _context.Measurements.AsQueryable<Measurement>();

            if (!string.IsNullOrWhiteSpace(resourceParameters.SearchQuery))
                collection = collection.Where(i => i.Name.Contains(resourceParameters.SearchQuery.Trim()));

            if (!string.IsNullOrWhiteSpace(resourceParameters.OrderBy))
                collection = resourceParameters.SortAsc ? collection.OrderBy(i => i.Name) : collection.OrderByDescending(i => i.Name);

            return await collection.Skip((resourceParameters.PageNumber - 1) * resourceParameters.PageSize).Take(resourceParameters.PageSize).ToListAsync();
        }

        public void Update(Measurement entity)
        {
            // No Implementation
        }

        public void Delete(Measurement entity)
        {
            _context.Measurements.Remove(entity);
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Measurements
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
