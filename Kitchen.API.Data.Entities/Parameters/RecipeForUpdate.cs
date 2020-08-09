using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KitchenHelper.API.Data.Entities.Parameters
{
    public class RecipeForUpdate
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(2500)]
        public string Description { get; set; }

        [MaxLength(100)]
        public string Category { get; set; }

        public ICollection<RecipeIngredientInformationForUpdate> Ingredients { get; set; }
            = new List<RecipeIngredientInformationForUpdate>();

        public ICollection<RecipeStepForUpdate> RecipeSteps { get; set; }
            = new List<RecipeStepForUpdate>();
    }
}
