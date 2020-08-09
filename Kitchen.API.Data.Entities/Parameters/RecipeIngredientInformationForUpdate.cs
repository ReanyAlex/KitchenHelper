using System.ComponentModel.DataAnnotations;

namespace KitchenHelper.API.Data.Entities.Parameters
{
    public class RecipeIngredientInformationForUpdate
    {
        [Required]
        public int Quantity { get; set; }

        [Required]
        public int MeasurementId { get; set; }

        [Required]
        public int IngredientId { get; set; }

        [Required]
        public int RecipeId { get; set; }
    }
}
