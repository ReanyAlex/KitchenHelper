using DbEntities = KitchenHelper.API.Data.Entities.DbEntities;
using ResourceParameters = KitchenHelper.API.Data.Entities.ResourceParameters;

namespace KitchenHelper.API.Data.Database.Sql.Abstract
{
    public interface IMeasurements : IEntityFramework<DbEntities.Measurement, ResourceParameters.Measurements>
    {
    }
}
