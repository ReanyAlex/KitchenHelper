namespace KitchenHelper.API.Data.Entities.Dtos
{
    public class RecipeIngredientInformationDto
    {
        public int Quantity { get; set; }

        public MeasurementDto Measurement { get; set; }

        public IngredientDto Ingredient { get; set; }
    }
}
