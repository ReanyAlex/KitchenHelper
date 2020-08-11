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
        /// Allowed Actions on measurements controller
        /// </summary>
        /// <returns></returns>
        [HttpOptions]
        public IActionResult GetMeasurementsOptions()
        {
            Response.Headers.Add("Allow", "OPTIONS, GET, POST, PUT, DELETE");
            return Ok();
        }

        /// <summary>
        /// Create an measurement
        /// </summary>
        /// <param name="measurementForCreation">Request Body for Creating a new measurement</param>
        /// <returns></returns>
        [HttpPost(Name = "CreateMeasurement")]
        public async Task<ActionResult<MeasurementDto>> CreateMeasurementAsync(MeasurementForCreation measurementForCreation)
        {
            var measurementToAdd = _mapper.Map<Measurement>(measurementForCreation);
            await _measurements.CreateAsync(measurementToAdd);
            await _measurements.SaveAsync();

            return CreatedAtRoute(
                "GetMeasurement",
                new { measurementId = measurementToAdd.Id },
                _mapper.Map<MeasurementDto>(measurementToAdd));
        }

        /// <summary>
        /// Get a list of measurements. Can search by measurements name
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet(Name = "GetMeasurements")]
        public async Task<ActionResult<IEnumerable<MeasurementDto>>> GetMeasurementsAsync([FromQuery] ResourceParameters.Measurements measurementsResourceParameters)
        {
            var measurementEntities = await _measurements.GetListAsync(measurementsResourceParameters);

            var measurementDtosList = _mapper.Map<IEnumerable<MeasurementDto>>(measurementEntities);
            return Ok(measurementDtosList);
        }

        /// <summary>
        /// Get an measurement by the measurement id
        /// </summary>
        /// <param name="measurementId">The id of the measurement</param>
        /// <returns></returns>
        [HttpGet("{measurementId}", Name = "GetMeasurement")]
        public async Task<ActionResult<MeasurementDto>> GetMeasurementAsync(int measurementId)
        {
            var measurementFromRepo = await _measurements.GetAsync(measurementId);

            if (measurementFromRepo == null) return NotFound();

            var measurementDto = _mapper.Map<MeasurementDto>(measurementFromRepo);
            return Ok(measurementDto);
        }

        /// <summary>
        /// Update a measurement
        /// </summary>
        /// <param name="measurementId">The id of the measurement</param>
        /// <param name="measurementForUpdate">Request Body for updating a measurement</param>
        /// <returns></returns>
        [HttpPut("{measurementId}", Name = "UpdateMeasurement")]
        public async Task<ActionResult<MeasurementDto>> UpdateMeasurementAsync(int measurementId, MeasurementForUpdate measurementForUpdate)
        {
            var measurementFromRepo = await _measurements.GetAsync(measurementId);

            if (measurementFromRepo == null) return NotFound();

            _mapper.Map(measurementForUpdate, measurementFromRepo);

            _measurements.Update(measurementFromRepo);
            await _measurements.SaveAsync();

            return Ok(_mapper.Map<Measurement>(measurementFromRepo));
        }

        /// <summary>
        /// Delete a measurement
        /// </summary>
        /// <param name="measurementId">The id of the measurement</param>
        /// <returns></returns>
        [HttpDelete("{measurementId}", Name = "DeleteMeasurement")]
        public async Task<ActionResult> DeleteMeasurementAsync(int measurementId)
        {
            var measurementFromRepo = await _measurements.GetAsync(measurementId);

            if (measurementFromRepo == null) return NotFound();

            _measurements.Delete(measurementFromRepo);
            await _measurements.SaveAsync();

            return NoContent();
        }
    }
}
