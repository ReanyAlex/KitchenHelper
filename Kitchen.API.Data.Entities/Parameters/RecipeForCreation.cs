using System.Collections.Generic;

namespace KitchenHelper.API.Data.Entities.Parameters
{
    public class RecipeForCreation
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Category { get; set; }

        public ICollection<RecipeIngredientInformationForCreation> Ingredients { get; set; }
            = new List<RecipeIngredientInformationForCreation>();

        public ICollection<RecipeStepForCreation> RecipeSteps { get; set; }
            = new List<RecipeStepForCreation>();
    }
}
