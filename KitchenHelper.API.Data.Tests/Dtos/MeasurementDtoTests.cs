using KitchenHelper.API.Data.Entities.Dtos;
using System;
using System.Linq;
using Xunit;

namespace KitchenHelper.API.Data.Tests.Dtos
{
    public class MeasurementDtoTests
    {
        [Fact]
        public void ClassType_MeasurementDto_PropertiesCount_Returns2()
        {
            Type t = typeof(MeasurementDto);
            Assert.Equal(2, t.GetProperties().Count());
        }
    }
}
