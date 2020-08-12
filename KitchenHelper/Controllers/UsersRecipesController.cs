using AutoMapper;
using KitchenHelper.API.Core.Abstract;
using KitchenHelper.API.Data.Entities.DbEntities;
using KitchenHelper.API.Data.Entities.Dtos;
using KitchenHelper.API.Data.Entities.Parameters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ResourceParameters = KitchenHelper.API.Data.Entities.ResourceParameters;

namespace KitchenHelper.API.Controllers
{
    [Route("api/user/{userId}/recipes")]
    [ApiController]
    public class UsersRecipesController : ControllerBase
    {
        private readonly IUsersRecipes _usersRecipes;
        private readonly IRecipes _recipes;
        private readonly IMapper _mapper;

        public UsersRecipesController(IUsersRecipes usersRecipes, IRecipes recipes, IMapper mapper)
        {
            _usersRecipes = usersRecipes ?? throw new ArgumentNullException(nameof(usersRecipes));
            _recipes = recipes ?? throw new ArgumentNullException(nameof(recipes));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        /// <summary>
        /// Allowed Actions on ingredients controller
        /// </summary>
        /// <returns></returns>
        [HttpOptions]
        public IActionResult GetUsersRecipesOptions()
        {
            Response.Headers.Add("Allow", "OPTIONS, GET, POST, DELETE");
            return Ok();
        }

        /// <summary>
        /// Add a recipe to a user
        /// </summary>
        /// <param name="userId">The id of the user</param>
        /// <param name="usersRecipeForCreation">Request body for adding a recipe to a user</param>
        /// <returns></returns>
        [HttpPost(Name = "AddUsersRecipe")]
        public async Task<ActionResult<IngredientDto>> AddUsersRecipeAsync(int userId, UsersRecipeForCreation usersRecipeForCreation)
        {
            //check if user exist (No methd for this yet)
            var recipe = await _recipes.GetAsync(usersRecipeForCreation.RecipeId);
            if (recipe == null) return NotFound();
          
            var usersRecipeToAdd = _mapper.Map<UsersRecipe>(usersRecipeForCreation);
            usersRecipeToAdd.UserId = userId;

            await _usersRecipes.AddAsync(usersRecipeToAdd);
            await _usersRecipes.SaveAsync();


            return CreatedAtRoute(
                "GetUsersRecipe", 
                new { usersRecipeToAdd.UserId, usersRecipeToAdd.RecipeId }, 
                recipe);
        }

        /// <summary>
        /// Get all recipes associated with a user
        /// </summary>
        /// <param name="userId">The id of the user</param>
        /// <param name="recipesResourceParameters"></param>
        /// <returns></returns>
        [HttpGet(Name = "GetUsersRecipes")]
        public async Task<ActionResult<IngredientDto>> GetUsersRecipesAsync(int userId, [FromQuery] ResourceParameters.Recipes recipesResourceParameters)
        {
            //check if user exist (No methd for this yet)

            var recipeEntities = await _usersRecipes.GetListAsync(userId, recipesResourceParameters);

            var recipeDtosList = _mapper.Map<IEnumerable<RecipeDto>>(recipeEntities);
            return Ok(recipeDtosList);
        }

        /// <summary>
        /// Get a recipe associated with a user
        /// </summary>
        /// <param name="usersRecipeForRetrieval"></param>
        /// <returns></returns>
        [HttpGet("{recipeId}", Name = "GetUsersRecipe")]
        public async Task<ActionResult<IngredientDto>> GetUsersRecipeAsync([FromRoute] UsersRecipeForRetrieval usersRecipeForRetrieval)
        {
            //check if user exist (No methd for this yet)
            var usersRecipeToRetrieve = _mapper.Map<UsersRecipe>(usersRecipeForRetrieval);

            var recipeEntities = await _usersRecipes.GetAsync(usersRecipeToRetrieve);

            var recipeDtosList = _mapper.Map<RecipeDto>(recipeEntities);
            return Ok(recipeDtosList);
        }

        /// <summary>
        /// Remove a recipe from a user
        /// </summary>
        /// <param name="usersRecipeForDeletion"></param>
        /// <returns></returns>
        [HttpDelete("{recipeId}", Name = "RemoveUsersRecipe")]
        public async Task<ActionResult> RemoveUsersRecipeAsync([FromRoute] UsersRecipeForDeletion usersRecipeForDeletion)
        {
            //check if user exist (No methd for this yet)
            var recipe = await _recipes.GetAsync(usersRecipeForDeletion.RecipeId);
            if (recipe == null) return NotFound();

            var usersRecipeToRemove = _mapper.Map<UsersRecipe>(usersRecipeForDeletion);

            _usersRecipes.RemoveAsync(usersRecipeToRemove);
            await _usersRecipes.SaveAsync();

            return NoContent();
        }

    }
}
