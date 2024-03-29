﻿using GYMApp.Services.DTO;
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
    [Route("API/Measurement")]
    public class MeasurementController
    {
        private readonly IMeasurementService measurementService;

        public MeasurementController(IMeasurementService measurementService)
        {
            this.measurementService = measurementService;
        }

        [HttpPost]
        public void CreateMeasurement([FromBody] MeasurementCreateDTO measurementDTO)
        {
            measurementService.CreateMeasurement(measurementDTO);

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

        [HttpGet("{ClientID}")]
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
