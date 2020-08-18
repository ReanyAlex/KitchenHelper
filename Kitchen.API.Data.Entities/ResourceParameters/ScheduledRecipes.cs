using System;

namespace KitchenHelper.API.Data.Entities.ResourceParameters
{
    public class ScheduledRecipes
    {
        public DateTime StartDate { get; set; } = DateTime.Now.AddDays(-1);
        public DateTime EndDate { get; set; } = DateTime.Now.AddDays(1);
    }
}
