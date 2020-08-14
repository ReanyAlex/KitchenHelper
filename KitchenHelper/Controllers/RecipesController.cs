using AutoMapper;
using KitchenHelper.API.Core.Abstract;
using KitchenHelper.API.Data.Entities.DbEntities;
using KitchenHelper.API.Data.Entities.Dtos;
using KitchenHelper.API.Data.Entities.Parameters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using ResourceParameters = KitchenHelper.API.Data.Entities.ResourceParameters;

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

        /// <summary>
        /// Allowed Actions on recipes controller
        /// </summary>
        /// <returns></returns>
        [HttpOptions]
        public IActionResult GetRecipesOptions()
        {
            Response.Headers.Add("Allow", "OPTIONS, GET, POST, PUT, DELETE");
            return Ok();
        }

        /// <summary>
        /// Create a recipe
        /// </summary>
        /// <param name="recipeForCreation">Request Body for creating a new recipe</param>
        /// <returns></returns>
        [HttpPost(Name = "CreateRecipe")]
        public async Task<ActionResult<RecipeDetailedDto>> CreateRecipeAsync(RecipeForCreation recipeForCreation)
        {
            var recipeToAdd = _mapper.Map<Recipe>(recipeForCreation);
            await _recipes.CreateAsync(recipeToAdd);
            await _recipes.SaveAsync();

            return CreatedAtRoute(
                "GetRecipe",
                new { recipeId = recipeToAdd.Id },
                _mapper.Map<RecipeDetailedDto>(recipeToAdd));
        }

        /// <summary>
        /// Get a list of recipes. Can search by recipes name
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet(Name = "GetRecipes")]
        [HttpHead]
        public async Task<ActionResult<IEnumerable<Recipe>>> GetRecipes([FromQuery] ResourceParameters.Recipes recipesResourceParameters)
        {
            var recipeEntities = await _recipes.GetListAsync(recipesResourceParameters);

            var recipeDtosList = _mapper.Map<IEnumerable<RecipeDto>>(recipeEntities);
            return Ok(recipeDtosList);
        }

        /// <summary>
        /// Get an recipe by the recipe id
        /// </summary>
        /// <param name="recipeId">The id of the recipe</param>
        /// <returns></returns>
        [HttpGet("{recipeId}", Name = "GetRecipe")]
        public async Task<ActionResult<RecipeDetailedDto>> GetRecipeAsync(int recipeId)
        {
            var recipeFromRepo = await _recipes.GetAsync(recipeId);

            if (recipeFromRepo == null) return NotFound();

            var recipeDto = _mapper.Map<RecipeDetailedDto>(recipeFromRepo);
            return Ok(recipeDto);
        }

        /// <summary>
        /// Update an recipe
        /// </summary>
        /// <param name="recipeId">The id of the recipe</param>
        /// <param name="recipeForUpdate">Request Body for updating a recipe</param>
        /// <returns></returns>
        [HttpPut("{recipeId}", Name = "UpdateRecipe")]
        public async Task<ActionResult<RecipeDto>> UpdateRecipeAsync(int recipeId, RecipeForUpdate recipeForUpdate)
        {
            var recipeFromRepo = await _recipes.GetAsync(recipeId);

            if (recipeFromRepo == null) return NotFound();

            _mapper.Map(recipeForUpdate, recipeFromRepo);

            _recipes.Update(recipeFromRepo);
            await _recipes.SaveAsync();

            return Ok(_mapper.Map<Recipe>(recipeFromRepo));
        }

        /// <summary>
        /// Partially update a recipe
        /// </summary>
        /// <param name="recipeId">The id of the recipe</param>
        /// <param name="patchDocument">The set of operations to apply to the recipe</param>
        /// <returns></returns>
        /// <remarks>
        /// Sample request (this request updates the author's first name)\
        /// [\
        ///     {\
        ///         "op": "replace",\
        ///         "path": "/name",\
        ///         "value": "new recipe name"\
        ///     }\
        /// ]
        /// </remarks>
        [HttpPatch("{recipeId}", Name = "PatchRecipe")]
        public async Task<ActionResult<RecipeDetailedDto>> UpdateRecipeAsync(int recipeId, JsonPatchDocument<RecipeForUpdate> patchDocument)
        {
            var recipeFromRepo = await _recipes.GetAsync(recipeId);

            if (recipeFromRepo == null) return NotFound();

            // map to DTO to apply the patch to
            var recipe = _mapper.Map<RecipeForUpdate>(recipeFromRepo);
            patchDocument.ApplyTo(recipe, ModelState);

            if (!ModelState.IsValid) return new UnprocessableEntityObjectResult(ModelState);
            
            _mapper.Map(recipe, recipeFromRepo);

            _recipes.Update(recipeFromRepo);
            await _recipes.SaveAsync();

            return Ok(_mapper.Map<RecipeDetailedDto>(recipeFromRepo));
        }

        /// <summary>
        /// Delete an recipe
        /// </summary>
        /// <param name="recipeId">The id of the recipe</param>
        /// <returns></returns>
        [HttpDelete("{recipeId}", Name = "DeleteRecipe")]
        public async Task<ActionResult> DeleteRecipeAsync(int recipeId)
        {
            var recipeFromRepo = await _recipes.GetAsync(recipeId);

            if (recipeFromRepo == null) return NotFound();

            _recipes.Delete(recipeFromRepo);
            await _recipes.SaveAsync();

            return NoContent();
        }
    }
}
