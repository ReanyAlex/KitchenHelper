using KitchenHelper.API.Data.Entities.DbEntities;
using System;
using System.Linq;
using Xunit;

namespace KitchenHelper.API.Data.Tests.DbEntities
{
    public class RecipeStepDtoTests
    {
        [Fact]
        public void ClassType_RecipeStep_PropertiesCount_Returns4()
        {
            Type t = typeof(RecipeStep);
            Assert.Equal(4, t.GetProperties().Count());
        }
    }
}
