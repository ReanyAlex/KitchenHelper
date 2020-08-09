using AutoMapper;
using KitchenHelper.API.Core.Abstract;
using KitchenHelper.API.Data.Entities.DbEntities;
using KitchenHelper.API.Data.Entities.Dtos;
using KitchenHelper.API.Data.Entities.Parameters;
using Microsoft.AspNetCore.Http;
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

        
        [HttpPost(Name = "CreateRecipe")]
        public async Task<ActionResult<RecipeDto>> CreateRecipeAsync(RecipeForCreation ingredientForCreation)
        {
            var ingredientToAdd = _mapper.Map<Recipe>(ingredientForCreation);
            await _recipes.CreateAsync(ingredientToAdd);
            await _recipes.SaveAsync();

            return CreatedAtRoute(
                "GetRecipe",
                new { ingredientId = ingredientToAdd.Id },
                _mapper.Map<RecipeDto>(ingredientToAdd));
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet(Name = "GetRecipes")]
        [HttpHead]
        public async Task<ActionResult<IEnumerable<Recipe>>> GetRecipes()
        {
            var recipeEntities = await _recipes.GetListAsync();

            var recipeDtosList = _mapper.Map<IEnumerable<RecipeDto>>(recipeEntities);
            return Ok(recipeDtosList);
        }


        [HttpGet("{ingredientId}", Name = "GetRecipe")]
        public async Task<ActionResult<RecipeDto>> GetRecipeAsync(int ingredientId)
        {
            var ingredientFromRepo = await _recipes.GetAsync(ingredientId);

            if (ingredientFromRepo == null) return NotFound();

            var ingredientDto = _mapper.Map<RecipeDto>(ingredientFromRepo);
            return Ok(ingredientDto);
        }


        [HttpPut("{ingredientId}", Name = "UpdateRecipe")]
        public async Task<ActionResult<RecipeDto>> UpdateRecipeAsync(int ingredientId, RecipeForUpdate ingredientForUpdate)
        {
            var ingredientFromRepo = await _recipes.GetAsync(ingredientId);

            if (ingredientFromRepo == null) return NotFound();

            _mapper.Map(ingredientForUpdate, ingredientFromRepo);

            _recipes.Update(ingredientFromRepo);
            await _recipes.SaveAsync();

            return Ok(_mapper.Map<Recipe>(ingredientFromRepo));
        }

      
        [HttpDelete("{ingredientId}", Name = "DeleteRecipe")]
        public async Task<ActionResult> DeleteRecipeAsync(int ingredientId)
        {
            var ingredientFromRepo = await _recipes.GetAsync(ingredientId);

            if (ingredientFromRepo == null) return NotFound();

            _recipes.Delete(ingredientFromRepo);
            await _recipes.SaveAsync();

            return NoContent();
        }
    }
}
