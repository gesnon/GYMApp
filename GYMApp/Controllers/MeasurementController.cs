using GYMApp.Services.DTO;
using GYMApp.Services.Services;
using GYMDB.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GYMApp.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class MeasurementController
    {
        private readonly IMeasurementService measurementService;

        public MeasurementController(IMeasurementService measurementService)
        {
            this.measurementService = measurementService;
        }

        [HttpPost]
        public void AddNewMeasurement([FromBody] MeasurementDTO measurementDTO)
        {
            measurementService.AddNewMeasurement(measurementDTO);

        }
        [HttpPut]
        public void UpdateMeasurement([FromBody] MeasurementUpdateDTO newMeasurementDTO)
        {
            measurementService.UpdateMeasurement(newMeasurementDTO);
        }

        [HttpDelete("{MeasurementID}")]
        public void DeleteMeasurement(int MeasurementID)
        {
            measurementService.DeleteMeasurement(MeasurementID);
        }

        [HttpGet("GetAllClientsMeasurements/{ClientID}")]
        public List<MeasurementDTO> GetAllClientsMeasurements(int ClientID)
        {
            List<MeasurementDTO> measurementDTOs = new List<MeasurementDTO>();

            return measurementService.GetAllClientsMeasurements(ClientID);
        }

        [HttpGet("GetLastClientMeasurement/{ClientID}")]
        public MeasurementDTO GetLastClientMeasurement(int ClientID)
        {
            return measurementService.GetLastClientMeasurement(ClientID);
        }
    }
}
