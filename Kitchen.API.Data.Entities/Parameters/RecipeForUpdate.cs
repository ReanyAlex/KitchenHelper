using System.Collections.Generic;

namespace KitchenHelper.API.Data.Entities.Parameters
{
    public class RecipeForUpdate
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Category { get; set; }

        public ICollection<RecipeIngredientInformationForUpdate> Ingredients { get; set; }
            = new List<RecipeIngredientInformationForUpdate>();

        public ICollection<RecipeStepForUpdate> RecipeSteps { get; set; }
            = new List<RecipeStepForUpdate>();
    }
}
