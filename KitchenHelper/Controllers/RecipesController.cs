using KitchenHelper.API.Core.Abstract;
using KitchenHelper.API.Data.Entities.DbEntities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KitchenHelper.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        private readonly IRecipes _recipes;

        public RecipesController(IRecipes recipes)
        {
            _recipes = recipes;
        }

        [HttpGet(Name = "GetRecipes")]
        [HttpHead]
        public async Task<ActionResult<IEnumerable<Recipe>>> GetRecipes()
        {

            var recipeEntities = await _recipes.GetAll();

            return Ok(recipeEntities);
        }
    }
}
