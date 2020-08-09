using KitchenHelper.API.Data.Database.Sql.Abstract;
using KitchenHelper.API.Data.Entities.DbEntities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KitchenHelper.API.Core.Concrete
{
    public class Measurements : Abstract.IMeasurements
    {

        private readonly IMeasurements _dal;

        public Measurements(IMeasurements dal)
        {
            _dal = dal ?? throw new ArgumentNullException(nameof(dal));
        }

        public async Task CreateAsync(Measurement measurement)
        {
            await _dal.CreateAsync(measurement);
        }

        public void Delete(Measurement measurement)
        {
            _dal.Delete(measurement);
        }

        public async Task<bool> ExistsAsync(int measurementId)
        {
            return await _dal.ExistsAsync(measurementId);
        }

        public async Task<Measurement> GetAsync(int measurementId)
        {
            return await _dal.GetAsync(measurementId);
        }

        public async Task<IEnumerable<Measurement>> GetListAsync()
        {
            return await _dal.GetListAsync();
        }

        public async Task<bool> SaveAsync()
        {
            return await _dal.SaveAsync();
        }

        public void Update(Measurement measurement)
        {
            _dal.Update(measurement);
        }
    }
}
