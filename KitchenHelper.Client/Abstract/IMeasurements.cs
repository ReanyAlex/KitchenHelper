using KitchenHelper.API.Data.Entities.DbEntities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KitchenHelper.API.Core.Abstract
{
    public interface IMeasurements
    {
        Task CreateAsync(Measurement measurement);

        Task<Measurement> GetAsync(int measurementId);
        Task<IEnumerable<Measurement>> GetListAsync();

        void Update(Measurement measurement);

        void Delete(Measurement measurement);

        Task<bool> ExistsAsync(int measurementId);

        Task<bool> SaveAsync();
    }
}
