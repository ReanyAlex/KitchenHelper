using System.ComponentModel.DataAnnotations;

namespace KitchenHelper.API.Data.Entities.Parameters
{
    public class RecipeStepForUpdate
    {
        [Required]
        public int Order { get; set; }
        [Required]
        [MaxLength(2500)]
        public string Step { get; set; }
        [Required]
        public int RecipeId { get; set; }
    }
}
