namespace KitchenHelper.API.Data.Entities.DbEntities
{
    public class RecipeIngredientInformation
    {
        public int Quantity { get; set; }

        public int MeasurmentId { get; set; }
        public Measurement Measurement { get; set; }

        public int IngredientId { get; set; }
        public Ingredient Ingredient { get; set; }
    }
}
