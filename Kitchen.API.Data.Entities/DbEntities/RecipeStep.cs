using System.ComponentModel.DataAnnotations;

namespace KitchenHelper.API.Data.Entities.DbEntities
{
    public class RecipeStep
    {   
        [Key]
        public int Id { get; set; }

        [Required]
        public int Order { get; set; }

        [Required]
        [MaxLength(2500)]
        public string Step { get; set; }

        [Required]
        public int RecipeId { get; set; }
    }
}
