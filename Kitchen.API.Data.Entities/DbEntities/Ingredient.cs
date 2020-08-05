using System.ComponentModel.DataAnnotations;

namespace KitchenHelper.API.Data.Entities.DbEntities
{
    class Ingredient
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
