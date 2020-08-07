using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KitchenHelper.API.Data.Entities.DbEntities
{
    public class RecipeIngredientInformation
    {   
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int Quantity { get; set; }

        [ForeignKey("MeasurementId")]
        public Measurement Measurement { get; set; }
        public int MeasurementId { get; set; }

        [ForeignKey("IngredientId")]
        public Ingredient Ingredient { get; set; }
        public int IngredientId { get; set; }

        public int RecipeId { get; set; }

    }
}
