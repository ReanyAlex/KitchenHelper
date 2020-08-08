using KitchenHelper.API.Data.Entities.Dtos;
using System;
using Xunit;

namespace KitchenHelper.API.Data.Tests.Dtos
{
    public class IngredientDtoTests
    {
        [Fact]
        public void ClassType_IngredientDto_PropertiesCount_Returns1()
        {
            Type t = typeof(IngredientDto);
            Assert.Single(t.GetProperties());
        }
    }
}
