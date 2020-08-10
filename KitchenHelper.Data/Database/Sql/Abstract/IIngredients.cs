using DbEntities = KitchenHelper.API.Data.Entities.DbEntities;
using ResourceParameters = KitchenHelper.API.Data.Entities.ResourceParameters;


namespace KitchenHelper.API.Data.Database.Sql.Abstract
{
    public interface IIngredients : IEntityFramework<DbEntities.Ingredient, ResourceParameters.Ingredients>
    {
    }
}
