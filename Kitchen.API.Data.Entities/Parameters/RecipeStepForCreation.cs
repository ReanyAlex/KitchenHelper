namespace KitchenHelper.API.Data.Entities.Parameters
{
    public class RecipeStepForCreation
    {
        public int Order { get; set; }

        public string Step { get; set; }

        public int RecipeId { get; set; }
    }
}
