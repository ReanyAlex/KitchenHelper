using KitchenHelper.API.Data.Entities.Dtos;
using System;
using System.Linq;
using Xunit;

namespace KitchenHelper.API.Data.Tests.Dtos
{
    public class RecipeIngredientInformationDtoTests
    {
        [Fact]
        public void ClassType_RecipeIngredientInformationDto_PropertiesCount_Returns3()
        {
            Type t = typeof(RecipeIngredientInformationDto);
            Assert.Equal(3, t.GetProperties().Count());
        }
    }
}
