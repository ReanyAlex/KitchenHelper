using AutoMapper;
using KitchenHelper.API.Core.Abstract;
using KitchenHelper.API.Data.Entities.DbEntities;
using KitchenHelper.API.Data.Entities.Dtos;
using KitchenHelper.API.Data.Entities.Parameters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ResourceParameters = KitchenHelper.API.Data.Entities.ResourceParameters;

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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ingredientForCreation"></param>
        /// <returns>An ActionResult of type IngredientDto</returns>
        [HttpPost(Name = "CreateIngredient")]
        public async Task<ActionResult<IngredientDto>> CreateIngredientAsync(IngredientForCreation ingredientForCreation)
        {
            var ingredientToAdd = _mapper.Map<Ingredient>(ingredientForCreation);
            await _ingredients.CreateAsync(ingredientToAdd);
            await _ingredients.SaveAsync();

            return CreatedAtRoute(
                "GetIngredient",
                new { ingredientId = ingredientToAdd.Id },
                _mapper.Map<IngredientDto>(ingredientToAdd));
        }

        /// <summary>
        /// Get Ingredient by the ingredients id
        /// </summary>
        /// <returns>An ActionResult of type IEnumerable of IngredientDto</returns>a
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet(Name = "GetIngredients")]
        public async Task<ActionResult<IEnumerable<IngredientDto>>> GetIngredientsAsync([FromQuery] ResourceParameters.Ingredients ingredientsResourceParameters)
        {
            var ingredientEntities = await _ingredients.GetListAsync(ingredientsResourceParameters);

            var ingredientDtosList = _mapper.Map<IEnumerable<IngredientDto>>(ingredientEntities);
            return Ok(ingredientDtosList);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ingredientId"></param>
        /// <returns>An ActionResult of type IngredientDto</returns>
        [HttpGet("{ingredientId}", Name = "GetIngredient")]
        public async Task<ActionResult<IngredientDto>> GetIngredientAsync(int ingredientId)
        {
            var ingredientFromRepo = await _ingredients.GetAsync(ingredientId);

            if (ingredientFromRepo == null) return NotFound();

            var ingredientDto = _mapper.Map<IngredientDto>(ingredientFromRepo);
            return Ok(ingredientDto);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ingredientId"></param>
        /// <param name="ingredientForUpdate"></param>
        /// <returns>An ActionResult of type IngredientDto</returns>
        [HttpPut("{ingredientId}", Name = "UpdateIngredient")]
        public async Task<ActionResult<IngredientDto>> UpdateIngredientAsync(int ingredientId, IngredientForUpdate ingredientForUpdate)
        {
            var ingredientFromRepo = await _ingredients.GetAsync(ingredientId);

            if (ingredientFromRepo == null) return NotFound();

            _mapper.Map(ingredientForUpdate, ingredientFromRepo);

            _ingredients.Update(ingredientFromRepo);
            await _ingredients.SaveAsync();

            return Ok(_mapper.Map<Ingredient>(ingredientFromRepo));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ingredientId"></param>
        /// <returns>No Content</returns>
        [HttpDelete("{ingredientId}", Name = "DeleteIngredient")]
        public async Task<ActionResult> DeleteIngredientAsync(int ingredientId)
        {
            var ingredientFromRepo = await _ingredients.GetAsync(ingredientId);

            if (ingredientFromRepo == null) return NotFound();

            _ingredients.Delete(ingredientFromRepo);
            await _ingredients.SaveAsync();

            return NoContent();
        }
    }
}
