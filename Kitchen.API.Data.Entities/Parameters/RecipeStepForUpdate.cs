namespace KitchenHelper.API.Data.Entities.Parameters
{
    public class RecipeStepForUpdate
    {
        public int Order { get; set; }

        public string Step { get; set; }

        public int RecipeId { get; set; }
    }
}
