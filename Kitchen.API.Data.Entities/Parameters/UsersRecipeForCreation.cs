using System.ComponentModel.DataAnnotations;

namespace KitchenHelper.API.Data.Entities.Parameters
{
    public class UsersRecipeForCreation
    {
        [Required]
        public int RecipeId { get; set; }
    }
}
