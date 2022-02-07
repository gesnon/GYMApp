﻿using GYMApp.Services.DTO;
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

        public MeasurementService(ContextDB context)
        {
            this.context = context;
        }

        public void AddNewMeasurement(MeasurementDTO measurementDTO)
        {
            context.Measurements.Add(new Measurement
            {
                LeftArm = measurementDTO.LeftArm,
                RightArm = measurementDTO.RightArm,
                LeftLeg = measurementDTO.LeftLeg,
                RightLeg = measurementDTO.RightLeg,
                Chest = measurementDTO.Chest,
                Weight = measurementDTO.Weight,
                Height = measurementDTO.Height,
                ClientID = measurementDTO.ClientID

            });

        }

        public void UpdateMeasurement(MeasurementUpdateDTO newMeasurementDTO)
        {
            Measurement OldMeasurement = context.Measurements.FirstOrDefault(_ => _.MeasurementID == newMeasurementDTO.MeasurementID);

            OldMeasurement.LeftArm = newMeasurementDTO.LeftArm;
            OldMeasurement.RightArm = newMeasurementDTO.RightArm;
            OldMeasurement.LeftLeg = newMeasurementDTO.LeftLeg;
            OldMeasurement.RightLeg = newMeasurementDTO.RightLeg;
            OldMeasurement.Chest = newMeasurementDTO.Chest;
            OldMeasurement.Weight = newMeasurementDTO.Weight;
            OldMeasurement.Height = newMeasurementDTO.Height;
            OldMeasurement.DateOfCreation = DateTime.Now;

            context.SaveChanges();
        }

        public void DeleteMeasurement(int MeasurementID)
        {
            context.Measurements.Remove(context.Measurements.FirstOrDefault(_ => _.MeasurementID == MeasurementID));

            context.SaveChanges();
        }

        public List<MeasurementDTO> GetAllClientsMeasurements(int ClientID)
        {
            List<MeasurementDTO> measurementDTOs = new List<MeasurementDTO>();

            measurementDTOs = context.Measurements.Where(_ => _.ClientID == ClientID).Select(_ => new MeasurementDTO
            {
                LeftArm = _.LeftArm,
                RightArm = _.RightArm,
                Chest = _.Chest,
                LeftLeg = _.LeftLeg,
                RightLeg = _.RightLeg,
                Weight = _.Weight,
                Height = _.Height,
                ClientID = _.ClientID,
                DateOFCreation = _.DateOfCreation
            }).ToList();

            return measurementDTOs;
        }

        public MeasurementDTO GetLastClientMeasurement(int ClientID)
        {
            List<Measurement> measurements = context.Clients.FirstOrDefault(_ => _.ID == ClientID).Measurement;
            Measurement measurement = measurements[measurements.Count - 1];
            MeasurementDTO measurementDTO = new MeasurementDTO
            {
                LeftArm = measurement.LeftArm,
                RightArm = measurement.RightArm,
                Chest = measurement.Chest,
                LeftLeg = measurement.LeftLeg,
                RightLeg = measurement.RightLeg,
                Weight = measurement.Weight,
                Height = measurement.Height,
                ClientID = measurement.ClientID,
                DateOFCreation = measurement.DateOfCreation
            };
            return measurementDTO;                             //Выглядит стремно, 100% можно сделать проще
        }
    }
}
