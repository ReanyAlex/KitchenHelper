using KitchenHelper.API.Data.Entities.DbEntities;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using data = KitchenHelper.API.Data;


namespace KitchenHelper.API.Core.Tests.Concrete
{
    public class Recipes
    {
        private readonly static Recipe _recipe = new Recipe()
        {
            Id = 1,
            Name = "Cup of Milk",
            Description = "A nice cold glass of milk",
            Category = "Test",
            Ingredients = new List<RecipeIngredientInformation>()
            {
                new RecipeIngredientInformation()
                {
                    Id = 1,
                    Quantity = 2,
                    MeasurementId = 1,
                    Measurement =  new Measurement()
                    {
                        Id = 1,
                        Name = "Cup",
                        ShortHand = "C",
                    },
                    IngredientId = 1,
                    Ingredient = new Ingredient()
                    {
                        Id = 1,
                        Name = "Milk",
                    },
                    RecipeId = 1
                }
            },
            RecipeSteps = new List<RecipeStep>()
            {
                new RecipeStep()
                {
                    Id = 1,
                    Order = 1,
                    Step = "Drink Milk",
                }
            }
        };

        private readonly IEnumerable<Recipe> _recipeList = new List<Recipe>() { 
            _recipe
        };
        

        [Fact]
        public void GetAll_AssociateExists_ReturnIEnumerableRecipe()
        {
            // Arrange
            Mock<data.Database.Sql.Abstract.IRecipes> recipeMock = new Mock<data.Database.Sql.Abstract.IRecipes>();
            recipeMock.Setup(r => r.GetListAsync()).Returns(Task.FromResult(_recipeList));
            Core.Concrete.Recipes recipes = new Core.Concrete.Recipes(recipeMock.Object);

            // Act
            var result = recipes.GetListAsync().Result;

            // Assert
            Assert.NotNull(result);
            Assert.IsAssignableFrom<IEnumerable<Recipe>>(result);
        }
    }
}
