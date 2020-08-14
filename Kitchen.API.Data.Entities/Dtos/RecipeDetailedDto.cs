using System.Collections.Generic;

namespace KitchenHelper.API.Data.Entities.Dtos
{
    public class RecipeDetailedDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Category { get; set; }

        public ICollection<RecipeIngredientInformationDto> Ingredients { get; set; }
            = new List<RecipeIngredientInformationDto>();

        public ICollection<RecipeStepDto> RecipeSteps { get; set; }
            = new List<RecipeStepDto>();
    }
}
