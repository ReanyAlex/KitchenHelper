using KitchenHelper.API.Data.Entities.DbEntities;
using System;
using System.Linq;
using Xunit;

namespace KitchenHelper.API.Data.Tests.DbEntities
{
    public class RecipeDtoTests
    {
        [Fact]
        public void ClassType_Recipe_PropertiesCount_Returns6()
        {
            Type t = typeof(Recipe);
            Assert.Equal(6, t.GetProperties().Count());
        }
    }
}
