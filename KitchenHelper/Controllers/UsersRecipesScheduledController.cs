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
    public class UsersRecipesScheduledController : ControllerBase
    {
        private readonly IUsersRecipesScheduled _usersRecipesScheduled;
        private readonly IRecipes _recipes;
        private readonly IUsers _users;
        private readonly IMapper _mapper;

        public UsersRecipesScheduledController(IUsersRecipesScheduled usersRecipesScheduled, IUsers users, IRecipes recipes, IMapper mapper)
        {
            _usersRecipesScheduled = usersRecipesScheduled ?? throw new ArgumentNullException(nameof(usersRecipesScheduled));
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

            await _usersRecipesScheduled.AddAsync(scheduledRecipeToAdd);
            await _usersRecipesScheduled.SaveAsync();

            var scheduledRecipeDto = _mapper.Map<ScheduledRecipeDto>(scheduledRecipeToAdd);

            return CreatedAtRoute(
                "GetUsersRecipeSchedule",//needs to be new endpoint
                new { scheduledRecipeToAdd.UserId, scheduledRecipeToAdd.RecipeId},
                scheduledRecipeDto);
        }

        [HttpGet("{recipeId}/schedule", Name = "GetUsersRecipeSchedule")]
        public async Task<ActionResult<IEnumerable<ScheduledRecipeDto>>> GetUsersRecipeScheduleAsync([FromRoute] ScheduledRecipeForRetrieval scheduledRecipeForRetrieval)
        {
            var user = await _users.GetAsync(scheduledRecipeForRetrieval.UserId);
            if (user == null) return NotFound();

            var scheduledRecipeToRetrieve = _mapper.Map<ScheduledRecipe>(scheduledRecipeForRetrieval);

            var scheduledRecipeEntity = await _usersRecipesScheduled.GetAsync(scheduledRecipeToRetrieve);

            var scheduledRecipeDto = _mapper.Map<IEnumerable<ScheduledRecipeDto>>(scheduledRecipeEntity);
            return Ok(scheduledRecipeDto);
        }

        [HttpGet("schedule", Name = "GetUsersScheduledRecipes")]
        public async Task<ActionResult<IEnumerable<ScheduledRecipeDto>>> GetUsersScheduledRecipesAsync(int userId, [FromQuery] ResourceParameters.ScheduledRecipes scheduledRecipesResourceParameters)
        {
            var user = await _users.GetAsync(userId);
            if (user == null) return NotFound();

            var recipeEntities = await _usersRecipesScheduled.GetListAsync(userId, scheduledRecipesResourceParameters);

            var scheduledRecipeDtosList = _mapper.Map<IEnumerable<ScheduledRecipeDto>>(recipeEntities);
            return Ok(scheduledRecipeDtosList);
        }
    }
}
