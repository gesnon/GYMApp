using GYMApp.Services.DTO;
using GYMDB;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using GYMDB.Models;

namespace GYMApp.Services.Services
{
    public class MeasurementService : IMeasurementService
    {
        private readonly ContextDB context;

        public MeasurementService (ContextDB context)
        {
            this.context = context;
        }

        public Measurement CreateMeasurement(MeasurementDTO measurementDTO)
        {
            return new Measurement
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
            Measurement OldMeasurement = context.Measurements.FirstOrDefault(_ => _.ID == ID);

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
            
        public void DeleteMeasurement(int MeasurementID)
        {
            context.Measurements.Remove(context.Measurements.FirstOrDefault(_ => _.ID == MeasurementID));

            context.SaveChanges();
        }

    }
}
