using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KitchenHelper.API.Data.Entities.DbEntities
{
    public class ScheduledRecipe
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
        [Required]
        public int UserId { get; set; }

        [ForeignKey("RecipeId")]
        public Recipe Recipe { get; set; }
        [Required]
        public int RecipeId { get; set; }

        [Required]
        public DateTime ScheduledDate { get; set; }
    }
}
