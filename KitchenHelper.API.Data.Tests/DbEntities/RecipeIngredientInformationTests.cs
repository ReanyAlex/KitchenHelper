using KitchenHelper.API.Data.Entities.DbEntities;
using System;
using System.Linq;
using Xunit;

namespace KitchenHelper.API.Data.Tests.DbEntities
{
    public class RecipeIngredientInformationDtoTests
    {
        [Fact]
        public void ClassType_RecipeIngredientInformation_PropertiesCount_Returns7()
        {
            Type t = typeof(RecipeIngredientInformation);
            Assert.Equal(7, t.GetProperties().Count());
        }
    }
}
