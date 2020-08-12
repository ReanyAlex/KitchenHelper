using System.ComponentModel.DataAnnotations;

namespace KitchenHelper.API.Data.Entities.Parameters
{
    public class UsersRecipeForRetrieval
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public int RecipeId { get; set; }
    }
}
