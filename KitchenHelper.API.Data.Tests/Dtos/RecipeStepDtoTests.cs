using KitchenHelper.API.Data.Entities.Dtos;
using System;
using System.Linq;
using Xunit;

namespace KitchenHelper.API.Data.Tests.Dtos
{
    public class RecipeStepDtoTests
    {
        [Fact]
        public void ClassType_RecipeStepDto_PropertiesCount_Returns2()
        {
            Type t = typeof(RecipeStepDto);
            Assert.Equal(2, t.GetProperties().Count());
        }
    }
}
