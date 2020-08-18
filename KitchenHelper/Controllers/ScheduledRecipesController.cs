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
    public class ScheduledRecipesController : ControllerBase
    {
        private readonly IScheduledRecipes _scheduledRecipes;
        private readonly IRecipes _recipes;
        private readonly IUsers _users;
        private readonly IMapper _mapper;

        public ScheduledRecipesController(IScheduledRecipes scheduledRecipes, IUsers users, IRecipes recipes, IMapper mapper)
        {
            _scheduledRecipes = scheduledRecipes ?? throw new ArgumentNullException(nameof(scheduledRecipes));
            _users = users ?? throw new ArgumentNullException(nameof(users));
            _recipes = recipes ?? throw new ArgumentNullException(nameof(recipes));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }


        [HttpOptions]
        public IActionResult GetScheduledRecipesOptions()
        {
            Response.Headers.Add("Allow", "OPTIONS, GET, POST, DELETE");
            return Ok();
        }


        [HttpPost("{recipeId}/schedule", Name = "AddScheduledRecipe")]
        public async Task<ActionResult<ScheduledRecipeDto>> AddScheduledRecipeAsync(int userId,int recipeId, ScheduledRecipeForCreation scheduledRecipeForCreation)
        {
            var user = await _users.GetAsync(userId);
            if (user == null) return NotFound();

            var recipe = await _recipes.GetAsync(recipeId);
            if (recipe == null) return NotFound();

            var scheduledRecipeToAdd = _mapper.Map<ScheduledRecipe>(scheduledRecipeForCreation);
            scheduledRecipeToAdd.UserId = userId;
            scheduledRecipeToAdd.RecipeId = recipeId;

            await _scheduledRecipes.AddAsync(scheduledRecipeToAdd);
            await _scheduledRecipes.SaveAsync();

            var scheduledRecipeDto = _mapper.Map<ScheduledRecipeDto>(scheduledRecipeToAdd);

            return CreatedAtRoute(
                "GetScheduledRecipe",
                new { scheduledRecipeToAdd.UserId, scheduledRecipeToAdd.RecipeId},
                scheduledRecipeDto);
        }

        [HttpGet("schedule", Name = "GetScheduledRecipes")]
        public async Task<ActionResult<IEnumerable<ScheduledRecipeDto>>> GetScheduledRecipesAsync(int userId, [FromQuery] ResourceParameters.ScheduledRecipes scheduledRecipesResourceParameters)
        {
            var user = await _users.GetAsync(userId);
            if (user == null) return NotFound();

            var recipeEntities = await _scheduledRecipes.GetListAsync(userId, scheduledRecipesResourceParameters);

            var scheduledRecipeDtosList = _mapper.Map<IEnumerable<ScheduledRecipeDto>>(recipeEntities);
            return Ok(scheduledRecipeDtosList);
        }

        [HttpGet("{recipeId}/schedule", Name = "GetScheduledRecipe")]
        public async Task<ActionResult<ScheduledRecipeDto>> GetUsersRecipeAsync([FromRoute] ScheduledRecipeForRetrieval scheduledRecipeForRetrieval)
        {
            var user = await _users.GetAsync(scheduledRecipeForRetrieval.UserId);
            if (user == null) return NotFound();

            var scheduledRecipeToRetrieve = _mapper.Map<ScheduledRecipe>(scheduledRecipeForRetrieval);

            var scheduledRecipeEntity = await _scheduledRecipes.GetAsync(scheduledRecipeToRetrieve);

            var scheduledRecipeDto = _mapper.Map<ScheduledRecipeDto>(scheduledRecipeEntity);
            return Ok(scheduledRecipeDto);
        }


        [HttpDelete("{recipeId}/schedule", Name = "RemoveScheduledRecipe")]
        public async Task<ActionResult> RemoveScheduledRecipeAsync([FromRoute] ScheduledRecipeForDeletion scheduledRecipeForDeletion)
        {
            var scheduledRecipeToRemove = _mapper.Map<ScheduledRecipe>(scheduledRecipeForDeletion);

            var scheduledRecipeFromRepo = await _scheduledRecipes.GetAsync(scheduledRecipeToRemove);

            _scheduledRecipes.RemoveAsync(scheduledRecipeFromRepo);
            await _scheduledRecipes.SaveAsync();

            return NoContent();
        }
    }
}
