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

        //public Measurement CreateMeasurement(MeasurementDTO measurementDTO)
        //{
        //    return measurementService.CreateMeasurement(measurementDTO);
        //}

        //public void UpdateMeasurement(int ID, MeasurementDTO measurementDTO)
        //{
        //    measurementService.UpdateMeasurement(ID, measurementDTO);
        //}

        //public void DeleteMeasurement(int MeasurementID)
        //{
        //    measurementService.DeleteMeasurement(MeasurementID);
        //}
    }
}
