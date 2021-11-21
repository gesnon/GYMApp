using GYMApp.Services.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace GYMApp.Services.Services.Measurement
{
    public interface IMeasurementService
    {
        public GYMDB.Models.Measurement CreateMeasurement(MeasurementDTO measurementDTO);

        public void UpdateMeasurement(int ID, MeasurementDTO measurementDTO); 

    }
}
