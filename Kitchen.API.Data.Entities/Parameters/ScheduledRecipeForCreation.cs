using System;
using System.ComponentModel.DataAnnotations;

namespace KitchenHelper.API.Data.Entities.Parameters
{
    public class ScheduledRecipeForCreation
    {
        [Required]
        public DateTime ScheduledDate { get; set; }
    }
}
