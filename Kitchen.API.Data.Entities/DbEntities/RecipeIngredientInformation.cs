using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KitchenHelper.API.Data.Entities.DbEntities
{
    public class RecipeIngredientInformation
    {   
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int Quantity { get; set; }

        [ForeignKey("MeasurementId")]
        public Measurement Measurement { get; set; }

        [Required]
        public int MeasurementId { get; set; }

        [ForeignKey("IngredientId")]
        public Ingredient Ingredient { get; set; }

        [Required]
        public int IngredientId { get; set; }

        [Required]
        public int RecipeId { get; set; }

    }
}
