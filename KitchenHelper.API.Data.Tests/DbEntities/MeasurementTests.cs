using KitchenHelper.API.Data.Entities.DbEntities;
using System;
using System.Linq;
using Xunit;

namespace KitchenHelper.API.Data.Tests.DbEntities
{
    public class MeasurementDtoTests
    {
        [Fact]
        public void ClassType_Measurement_PropertiesCount_Returns3()
        {
            Type t = typeof(Measurement);
            Assert.Equal(3, t.GetProperties().Count());
        }
    }
}
