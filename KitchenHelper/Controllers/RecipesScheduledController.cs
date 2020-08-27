using System;
using System.Threading.Tasks;
using AutoMapper;
using KitchenHelper.API.Data.Database.Sql.Abstract;
using KitchenHelper.API.Data.Entities.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace KitchenHelper.API.Controllers
{
    [Route("api/recipes/scheduled")]
    [ApiController]
    public class RecipesScheduledController : ControllerBase
    {
        private readonly IRecipesScheduled _recipesScheduled;
        private readonly IMapper _mapper;

        public RecipesScheduledController(IRecipesScheduled recipesScheduled, IMapper mapper)
        {
            _recipesScheduled = recipesScheduled ?? throw new ArgumentNullException(nameof(recipesScheduled));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet("{scheduleId}", Name = "GetUsersSpecificRecipeSchedule")]
        public async Task<ActionResult<ScheduledRecipeDto>> GetRecipesScheduledAsync([FromRoute] int scheduleId)
        {
            var scheduledRecipeEntity = await _recipesScheduled.GetAsync(scheduleId);
            if (scheduledRecipeEntity == null) return NotFound();

            var scheduledRecipeDto = _mapper.Map<ScheduledRecipeDto>(scheduledRecipeEntity);
            return Ok(scheduledRecipeDto);
        }


        [HttpDelete("{scheduleId}", Name = "RemoveScheduledRecipe")]
        public async Task<ActionResult> RemoveScheduledRecipeAsync([FromRoute] int scheduleId)
        {
            var scheduledRecipeToRemove = await _recipesScheduled.GetAsync(scheduleId);
            if (scheduledRecipeToRemove == null) return NotFound();

            _recipesScheduled.RemoveAsync(scheduledRecipeToRemove);
            await _recipesScheduled.SaveAsync();

            return NoContent();
        }
    }
}
