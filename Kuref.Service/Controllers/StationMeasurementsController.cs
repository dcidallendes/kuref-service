using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kuref.Service.Data;
using Kuref.Service.Dto;
using Kuref.Service.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kuref.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StationMeasurementsController : ControllerBase
    {

        private readonly KurefContext context;

        public StationMeasurementsController(KurefContext context)
        {
            this.context = context;
        }



        /// <summary>
        /// Creates measure registers for a given station and measurement types
        /// </summary>
        /// <param name="stationMeasurements">Measurements to be registered</param>
        /// <returns></returns>
        /// <response code="400">Station id or measuretment type(s) not found</response>
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpPost]
        [Authorize]
        public async Task<ActionResult> PostStationMeasurements([FromBody] StationMeasurementsDto stationMeasurements)
        {
            int stationId = stationMeasurements.StationId;
            List<int> measurementTypes = stationMeasurements.Measurements.Select(m => m.MeasurementTypeId).Distinct().ToList();

            if (context.Stations.Count(s => s.Id == stationId) == 0)
            {
                return ValidationProblem("Station id not found", stationId.ToString());
            }

            if(context.MeasurementTypes.Count(s => measurementTypes.Contains(s.Id)) < measurementTypes.Count)
            {
                return ValidationProblem("One or more measurement types not found");
            }

            DateTime currentTime = DateTime.UtcNow;

            
            foreach(MeasurementDto measurement in stationMeasurements.Measurements)
            {
                Measurement dbMeasurement = new Measurement
                {
                    StationId = stationId,
                    MeasurementTypeId = measurement.MeasurementTypeId,
                    Value = measurement.Value,
                    MeasurementTime = measurement.MeasurementTime,
                    RegistrationTime = currentTime
                };

                await context.AddAsync(dbMeasurement);
            }
            await context.SaveChangesAsync();

            return Ok();
        }
    }
}