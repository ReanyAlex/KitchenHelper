using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KitchenHelper.API.Data.Entities.Parameters
{
    public class RecipeForCreation
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(2500)]
        public string Description { get; set; }

        [MaxLength(100)]
        public string Category { get; set; }

        public ICollection<RecipeIngredientInformationForCreation> Ingredients { get; set; }
            = new List<RecipeIngredientInformationForCreation>();

        public ICollection<RecipeStepForCreation> RecipeSteps { get; set; }
            = new List<RecipeStepForCreation>();
    }
}
