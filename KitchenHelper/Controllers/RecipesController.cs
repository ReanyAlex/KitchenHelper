using AutoMapper;
using KitchenHelper.API.Core.Abstract;
using KitchenHelper.API.Data.Entities.DbEntities;
using KitchenHelper.API.Data.Entities.Dtos;
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
        private readonly IMapper _mapper;

        public RecipesController(IRecipes recipes, IMapper mapper)
        {
            _recipes = recipes ?? throw new System.ArgumentNullException(nameof(recipes));
            _mapper = mapper ?? throw new System.ArgumentNullException(nameof(mapper));
        }

        [HttpGet(Name = "GetRecipes")]
        [HttpHead]
        public async Task<ActionResult<IEnumerable<Recipe>>> GetRecipes()
        {
            var recipeEntities = await _recipes.GetAll();

            return Ok(_mapper.Map<IEnumerable<RecipeDto>>(recipeEntities));
        }
    }
}
