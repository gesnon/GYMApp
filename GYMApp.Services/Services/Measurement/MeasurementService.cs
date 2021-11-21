﻿using GYMApp.Services.DTO;
using GYMDB;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace GYMApp.Services.Services.Measurement
{
    public class MeasurementService : IMeasurementService
    {
        private readonly ContextDB context;
        public GYMDB.Models.Measurement CreateMeasurement(MeasurementDTO measurementDTO)
        {
            return new GYMDB.Models.Measurement
            {  
                DateOfCreation=DateTime.Today,
                LeftArm = measurementDTO.LeftArm,
                RightArm = measurementDTO.RightArm,
                LeftLeg = measurementDTO.LeftLeg,
                RightLeg = measurementDTO.RightLeg,
                Chest = measurementDTO.Chest,
                Weight = measurementDTO.Weight,
                Height = measurementDTO.Height

            };

        }

        public void UpdateMeasurement(int ID, MeasurementDTO measurementDTO)
        {
            GYMDB.Models.Measurement OldMeasurement = context.Measurements.FirstOrDefault(_ => _.ID == ID);

            OldMeasurement.DateOfCreation = DateTime.Today;
            OldMeasurement.LeftArm = measurementDTO.LeftArm;
            OldMeasurement.RightArm = measurementDTO.RightArm;
            OldMeasurement.LeftLeg = measurementDTO.LeftLeg;
            OldMeasurement.RightLeg = measurementDTO.RightLeg;
            OldMeasurement.Chest = measurementDTO.Chest;
            OldMeasurement.Weight = measurementDTO.Weight;
            OldMeasurement.Height = measurementDTO.Height;

            this.context.SaveChanges();
        }
        

    }
}
