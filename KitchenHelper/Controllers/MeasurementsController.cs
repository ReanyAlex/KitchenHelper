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

namespace KitchenHelper.API.Controllers
{
    [Route("api/measurements")]
    [ApiController]
    public class MeasurementsController : ControllerBase
    {
        private readonly IMeasurements _measurements;
        private readonly IMapper _mapper;

        public MeasurementsController(IMeasurements measurements, IMapper mapper)
        {
            _measurements = measurements ?? throw new ArgumentNullException(nameof(measurements));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ingredientForCreation"></param>
        /// <returns></returns>
        [HttpPost(Name = "CreateMeasurement")]
        public async Task<ActionResult<MeasurementDto>> CreateMeasurementAsync(MeasurementForCreation ingredientForCreation)
        {
            var ingredientToAdd = _mapper.Map<Measurement>(ingredientForCreation);
            await _measurements.CreateAsync(ingredientToAdd);
            await _measurements.SaveAsync();

            return CreatedAtRoute(
                "GetMeasurement",
                new { ingredientId = ingredientToAdd.Id },
                _mapper.Map<MeasurementDto>(ingredientToAdd));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet(Name = "GetMeasurements")]
        public async Task<ActionResult<IEnumerable<MeasurementDto>>> GetMeasurementsAsync()
        {
            var ingredientEntities = await _measurements.GetListAsync();

            var ingredientDtosList = _mapper.Map<IEnumerable<MeasurementDto>>(ingredientEntities);
            return Ok(ingredientDtosList);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ingredientId"></param>
        /// <returns></returns>
        [HttpGet("{ingredientId}", Name = "GetMeasurement")]
        public async Task<ActionResult<MeasurementDto>> GetMeasurementAsync(int ingredientId)
        {
            var ingredientFromRepo = await _measurements.GetAsync(ingredientId);

            if (ingredientFromRepo == null) return NotFound();

            var ingredientDto = _mapper.Map<MeasurementDto>(ingredientFromRepo);
            return Ok(ingredientDto);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ingredientId"></param>
        /// <param name="ingredientForUpdate"></param>
        /// <returns></returns>
        [HttpPut("{ingredientId}", Name = "UpdateMeasurement")]
        public async Task<ActionResult<MeasurementDto>> UpdateMeasurementAsync(int ingredientId, MeasurementForUpdate ingredientForUpdate)
        {
            var ingredientFromRepo = await _measurements.GetAsync(ingredientId);

            if (ingredientFromRepo == null) return NotFound();

            _mapper.Map(ingredientForUpdate, ingredientFromRepo);

            _measurements.Update(ingredientFromRepo);
            await _measurements.SaveAsync();

            return Ok(_mapper.Map<Measurement>(ingredientFromRepo));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ingredientId"></param>
        /// <returns></returns>
        [HttpDelete("{ingredientId}", Name = "DeleteMeasurement")]
        public async Task<ActionResult> DeleteMeasurementAsync(int ingredientId)
        {
            var ingredientFromRepo = await _measurements.GetAsync(ingredientId);

            if (ingredientFromRepo == null) return NotFound();

            _measurements.Delete(ingredientFromRepo);
            await _measurements.SaveAsync();

            return NoContent();
        }
    }
}
