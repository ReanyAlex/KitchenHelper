using System;

namespace KitchenHelper.API.Data.Entities.Dtos
{
    public class ScheduledRecipeDto
    {
        public int Id { get; set; }
        public RecipeDto Recipe { get; set; }
        public DateTime ScheduledDate { get; set; }
    }
}
