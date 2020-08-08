using KitchenHelper.API.Data.Entities.Dtos;
using System;
using System.Linq;
using Xunit;

namespace KitchenHelper.API.Data.Tests.Dtos
{
    public class RecipeDtoTests
    {
        [Fact]
        public void ClassType_RecipeDto_PropertiesCount_Returns5()
        {
            Type t = typeof(RecipeDto);
            Assert.Equal(5, t.GetProperties().Count());
        }
    }
}
