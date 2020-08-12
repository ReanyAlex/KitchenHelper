using KitchenHelper.API.Data.Entities.Dtos;
using System;
using System.Linq;
using Xunit;

namespace KitchenHelper.API.Data.Tests.Dtos
{
    public class RecipeDtoTests
    {
        [Fact]
        public void ClassType_RecipeDto_PropertiesCount_Returns6()
        {
            Type t = typeof(RecipeDto);
            Assert.Equal(6, t.GetProperties().Count());
        }
    }
}
