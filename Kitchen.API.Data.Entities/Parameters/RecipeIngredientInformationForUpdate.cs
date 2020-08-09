namespace KitchenHelper.API.Data.Entities.Parameters
{
    public class RecipeIngredientInformationForUpdate
    {
        public int Quantity { get; set; }

        public int MeasurementId { get; set; }

        public int IngredientId { get; set; }

        public int RecipeId { get; set; }
    }
}
