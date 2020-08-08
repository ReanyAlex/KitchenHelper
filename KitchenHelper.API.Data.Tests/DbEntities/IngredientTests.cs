using KitchenHelper.API.Data.Entities.DbEntities;
using System;
using System.Linq;
using Xunit;

namespace KitchenHelper.API.Data.Tests.DbEntities
{
    public class IngredientDtoTests
    {
        [Fact]
        public void ClassType_Ingredient_PropertiesCount_Returns2()
        {
            Type t = typeof(Ingredient);
            Assert.Equal(2, t.GetProperties().Count());
        }
    }
}
