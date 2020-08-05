using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KitchenHelper.API.Data.Entities.DbEntities
{
    public class Recipe
    {   [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(2500)]
        public string Description { get; set; }

        public IEnumerable<RecipeIngredientInformation> Ingredients { get; set; }

        public IEnumerable<RecipeStep> RecipeSteps { get; set; }
    }
}
