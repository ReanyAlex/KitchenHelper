using AutoMapper;
using KitchenHelper.API.Core.Abstract;
using KitchenHelper.API.Data.Entities.DbEntities;
using KitchenHelper.API.Data.Entities.Dtos;
using KitchenHelper.API.Data.Entities.Parameters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KitchenHelper.API.Controllers
{
    [Route("api/ingredients")]
    [ApiController]
    public class IngredientsController : ControllerBase
    {
        private readonly IIngredients _ingredients;
        private readonly IMapper _mapper;

        public IngredientsController(IIngredients ingredients, IMapper mapper)
        {
            _ingredients = ingredients ?? throw new ArgumentNullException(nameof(ingredients));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpPost(Name = "CreateIngredient")]
        [HttpHead]
        public async Task<ActionResult> CreateIngredientAsync(IngredientForCreation ingredientForCreation)
        {
            var ingredientToAdd = _mapper.Map<Ingredient>(ingredientForCreation);
            await _ingredients.CreateAsync(ingredientToAdd);
            await _ingredients.SaveAsync();

            return CreatedAtRoute(
                "GetIngredient",
                new { ingredientId = ingredientToAdd.Id },
                _mapper.Map<IngredientDto>(ingredientToAdd));
        }

        [HttpGet(Name = "GetIngredients")]
        [HttpHead]
        public async Task<ActionResult<IEnumerable<Ingredient>>> GetIngredientsAsync()
        {
            var ingredientEntities = await _ingredients.GetIngredientsAsync();

            var ingredientDtosList = _mapper.Map<IEnumerable<IngredientDto>>(ingredientEntities);
            return Ok(ingredientDtosList);
        }

        [HttpGet("{ingredientId}", Name = "GetIngredient")]
        public async Task<ActionResult<IEnumerable<Ingredient>>> GetIngredientAsync(int ingredientId)
        {
            var ingredientFromRepo = await _ingredients.GetAsync(ingredientId);

            if (ingredientFromRepo == null) return NotFound();

            var ingredientDto = _mapper.Map<IngredientDto>(ingredientFromRepo);
            return Ok(ingredientDto);
        }

        [HttpPut("{ingredientId}", Name = "UpdateIngredient")]
        [HttpHead]
        public async Task<ActionResult<Ingredient>> UpdateIngredientAsync(int ingredientId, IngredientForUpdate ingredientForUpdate)
        {
            var ingredientFromRepo = await _ingredients.GetAsync(ingredientId);

            if (ingredientFromRepo == null) return NotFound();

            _mapper.Map(ingredientForUpdate, ingredientFromRepo);

            _ingredients.Update(ingredientFromRepo);
            await _ingredients.SaveAsync();

            return Ok(_mapper.Map<Ingredient>(ingredientFromRepo));
        }

        [HttpDelete("{ingredientId}", Name = "DeleteIngredient")]
        [HttpHead]
        public async Task<ActionResult<Ingredient>> DeleteIngredientAsync(int ingredientId)
        {
            var ingredientFromRepo = await _ingredients.GetAsync(ingredientId);

            if (ingredientFromRepo == null) return NotFound();

            _ingredients.Delete(ingredientFromRepo);
            await _ingredients.SaveAsync();

            return NoContent();
        }
    }
}
