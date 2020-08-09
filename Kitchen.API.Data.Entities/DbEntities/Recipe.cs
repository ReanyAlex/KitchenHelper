using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KitchenHelper.API.Data.Entities.DbEntities
{
    public class Recipe
    {   [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(2500)]
        public string Description { get; set; }

        [MaxLength(100)]
        public string Category { get; set; }

        public ICollection<RecipeIngredientInformation> Ingredients { get; set; }
            = new List<RecipeIngredientInformation>();

        public ICollection<RecipeStep> RecipeSteps { get; set; }
            = new List<RecipeStep>();
    }
}
