using System.ComponentModel.DataAnnotations;

namespace KitchenHelper.API.Data.Entities.Parameters
{
    public class IngredientForUpdate
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
